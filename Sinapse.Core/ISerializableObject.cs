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
        string Name { get; set;}

        string Description { get; set;}

        string Location { get; set; }

        string Remarks { get; set;}

        bool HasChanges { get; set; }

        // DateTime Creation { get; }

        bool Save(string path);
        bool Save();

    }


    public class SerializableObject<T> : ISerializableObject<T>
        where T : ISerializableObject<T>
    {

        private string name;
        private string description;
        private string location;
        private bool hasChanges;


        public SerializableObject()
        {
            name = String.Empty;
            description = String.Empty;
            location = String.Empty;
            hasChanges = false;
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

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Remarks
        {
            get { return Remarks; }
            set { Remarks = value; }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set { hasChanges = value; }
        }


        public bool Save()
        {
            return Save(location);
        }

        public bool Save(string path)
        {
            bool success = false;
            FileStream fileStream = null;
            GZipStream gzipStream = null;


            try
            {
                fileStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.None);
                gzipStream = new GZipStream(fileStream, CompressionMode.Compress);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                binaryFormatter.Serialize(gzipStream, this);

                location = path;
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

                obj.Location = path;
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
