using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Sinapse.Core
{
    public static class DocumentCache
    {

        private static Dictionary<String, Type> cacheByExtension = null; // <extension, type>
        


        public static Type GetType(string extension)
        {
            if (cacheByExtension == null) Build();
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


        public static void Build()
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
    }
}
