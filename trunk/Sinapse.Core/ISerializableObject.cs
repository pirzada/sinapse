using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace Sinapse.Core
{

    public interface ISerializableObject<T>
    {
        // Metadata associated
        string Name { get; set;}
        string Description { get; set;}
        string Remarks { get; set;}

        // IO Data
        string FilePath { get; set; }
        string FileName { get; set; }
        string FullPath { get; }
        string DefaultExtension { get; }

        bool HasChanges { get; set; }

        // DateTime Creation { get; }

        bool Save(string path);
        bool Save();

    }

    [Serializable]
    public class SerializableObject<T> : ISerializableObject<T>
        where T : ISerializableObject<T>
    {

        private string name;
        private string description;
        private string remarks;

        [NonSerialized]
        private string filename;
        [NonSerialized]
        private string filepath;
        [NonSerialized]
        private bool hasChanges;

        private T owner;



        public SerializableObject(T owner)
        {
            this.owner = owner;
            this.name = String.Empty;
            this.description = String.Empty;
            this.remarks = String.Empty;
            this.filepath = String.Empty;
            this.filename = String.Empty;
            this.hasChanges = false;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }







        /// <summary>
        ///   Gets the full path for this object, excluding its filename.
        /// </summary>
        public string FilePath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        /// <summary>
        ///   Gets the filename for this object.
        /// </summary>
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary>
        ///   Gets the default extension for this object.
        /// </summary>
        public string DefaultExtension
        {
            get { return owner.DefaultExtension; }
        }

        /// <summary>
        ///   Gets the full path for this object, including its filename.
        /// </summary>
        public string FullPath
        {
            get { return Path.Combine(FilePath, FileName); }
        }


        public bool HasChanges
        {
            get { return hasChanges; }
            set { hasChanges = value; }
        }




        /// <summary>
        ///   Saves the object.
        /// </summary>
        /// <returns>
        ///   Returns true for success, false otherwise.
        /// </returns>
        public bool Save()
        {
            return Save(FullPath);
        }


        /// <summary>
        ///   Saves the object.
        /// </summary>
        /// <param name="path">
        ///   The full path where to save the file.
        /// </param>
        /// <returns>
        ///   Returns true for success, false otherwise.
        /// </returns>
        public bool Save(string path)
        {
            bool success = false;
            FileStream fileStream = null;
            GZipStream gzipStream = null;

            try
            {
                this.filename = Path.GetFileNameWithoutExtension(path);
                this.filepath = Path.GetDirectoryName(path);

                //string fullpath = Path.Combine(path, name + "." + extension);
                fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                gzipStream = new GZipStream(fileStream, CompressionMode.Compress);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                binaryFormatter.Serialize(gzipStream, owner);

                hasChanges = false;
                success = true;
            }
            catch (SerializationException exception)
            {
                // TODO: Add exception handling here
                success = false;
                throw;
            }
            catch (IOException exception)
            {
                // TODO: Add exception handling here
                success = false;
                throw;
            }
            catch (Exception exception)
            {
                // TODO: Add exception handling here
                success = false;
                throw;
            }
            finally
            {
                if (gzipStream != null) gzipStream.Close();
                if (fileStream != null) fileStream.Close();
            }

            return success;
        }



        /// <summary>
        ///   Opens an object.
        /// </summary>
        /// <param name="path">
        ///   The full path for the object to be open.
        /// </param>
        /// <returns>
        ///   The loaded object.
        /// </returns>
        public static T Open(string path)
        {
            T obj = default(T);
            FileStream fileStream = null;
            GZipStream gzipStream = null;

            try
            {
                fileStream = new FileStream(path, FileMode.Open);
                gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                binaryFormatter.Binder = new AnyVersionObjectBinder();
                obj = (T)binaryFormatter.Deserialize(gzipStream);

                obj.FilePath = Path.GetDirectoryName(path);
                obj.FileName = Path.GetFileNameWithoutExtension(path);
            }
            catch (FileNotFoundException e)
            {
                // TODO: Add exception handling here
                throw;
            }
            catch (SerializationException e)
            {
                // TODO: Add exception handling here
                throw;
            }
            catch (IOException e)
            {
                // TODO: Add exception handling here
                throw;
            }
            catch (Exception e)
            {
                // TODO: Add exception handling here
                throw;
            }
            finally
            {
                if (gzipStream != null) gzipStream.Close();
                if (fileStream != null) fileStream.Close();
            }

            return obj;
        }






        private sealed class AnyVersionObjectBinder : SerializationBinder
        {
            // TODO: Remove the need for this ugly hack.
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type type = null;

                if (assemblyName.Contains("Sinapse") || typeName.Contains("Sinapse"))
                {
                    type = System.Type.GetType(typeName.Replace("0.0.0.2", "0.0.0.3"));

                    Debug.WriteLine("Loading Assembly: " + assemblyName);
                    Debug.WriteLine("Loading Type: " + typeName);
                    //Debug.WriteLine("Match type: " + type.Name);
                }

                return type;
            }
        }


    }
}
