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

    public interface ISerializableObject
    {
        bool Save(string path);

        event EventHandler FileSaved;
    }

    [Serializable]
    public class SerializableObject<T> : ISerializableObject
        where T : ISerializableObject
    {

        private T owner;


        [field: NonSerialized]
        public event EventHandler FileSaved;



        public SerializableObject(T owner)
        {
            this.owner = owner;
        }



        protected void OnFileSaved(EventArgs e)
        {
            if (FileSaved != null)
                FileSaved.Invoke(this, e);
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
                fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                gzipStream = new GZipStream(fileStream, CompressionMode.Compress);

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                binaryFormatter.Serialize(gzipStream, owner);

                success = true;
                OnFileSaved(EventArgs.Empty);
            }
            catch (Exception ex)
            {
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
            }
            catch (Exception ex)
            {
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
