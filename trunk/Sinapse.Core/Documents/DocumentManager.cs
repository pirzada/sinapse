using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Sinapse.Core.Documents
{

    public enum DocumentCategory
    {
        None = 0,
        System = 1,
        Source = 2,
        Session = 3,
        Other = 4,
    }

    public static class DocumentManager
    {

        private static Dictionary<String, Type> cacheByExtension = null; // <extension, type>
        


        public static Type GetType(string extension)
        {
            if (cacheByExtension == null) BuildCache();
            if (cacheByExtension.ContainsKey(extension))
                return cacheByExtension[extension];
            else return null;
        }

        public static String GetExtension(Type type)
        {
            return GetDescription(type).Extension;
        }


        public static DocumentDescription GetDescription(Type type)
        {
            object[] attr = type.GetCustomAttributes(typeof(DocumentDescription), false);
            if (attr.Length > 0) return (attr[0] as DocumentDescription);
            throw new ArgumentException("", "type");
        }

        public static Type[] TypeList
        {
            get
            {
                return Sinapse.Utils.GetTypesImplementingInterface(
              Assembly.GetAssembly(typeof(ISinapseDocument)), typeof(ISinapseDocument));
            }
        }

        public static String[] Extensions
        {
            get {String[] array = new String[cacheByExtension.Keys.Count];
            cacheByExtension.Keys.CopyTo(array, 0);
            return array;
            }
        }


        public static void BuildCache()
        {
            cacheByExtension = new Dictionary<String, Type>();

            foreach (Type type in TypeList)
            {
                object[] attr = type.GetCustomAttributes(typeof(DocumentDescription), false);
                if (attr.Length > 0)
                {
                    cacheByExtension.Add((attr[0] as DocumentDescription).Extension, type);
                }
            }
        }



        public static ISinapseDocument Open(string fullName)
        {
            ISinapseDocument document = null;

            // First we check if file exists,
            if (System.IO.File.Exists(fullName))
            {
                // Determine the type of the document being open
                Type type = DocumentManager.GetType(Utils.GetExtension(fullName, true));

                // Create the method info for the static method SerializableObject<T>.Open
                MethodInfo methodOpen = type.GetMethod("Open",
                    BindingFlags.Static | BindingFlags.Public);

                // Call the Open method passing the FullPath as its first parameter
                document = (ISinapseDocument)methodOpen.Invoke(null, new object[] { fullName });
            }
            else
            {
                throw new FileNotFoundException("The file could not be found", fullName);
            }

            return document;
        }

        public static ISinapseDocument Create(string name, string fullName, Type type)
        {
            // Creates a new instance, then save it to the disk.
            ISinapseDocument doc = Activator.CreateInstance(type, new object[] { name, new FileInfo(fullName) }) as ISinapseDocument;
            doc.Save(fullName);
            return doc;
        }
    }
}
