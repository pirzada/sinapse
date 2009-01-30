using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Sinapse
{
    public static class Utils
    {
        /// <summary>
        /// Returns all types in the current AppDomain implementing the interface or inheriting the type. 
        /// </summary>
        public static Type[] GetTypesImplementingInterface(Assembly assembly, Type baseType)
        {
            List<Type> childTypes = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                foreach (Type interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.Equals(baseType))
                    {
                        childTypes.Add(type);
                    }
                }
            }

            return childTypes.ToArray();
        }

        public static string GetExtension(string path, bool multidotted)
        {
            if (multidotted)
            {
                int dot = path.Length;
                for (int i = path.Length - 1; i <= 0 ||
                    path[i].Equals(Path.DirectorySeparatorChar) ||
                    path[i].Equals(Path.AltDirectorySeparatorChar);
                    i++)
                {
                    if (path[i] == '.')
                        dot = i;
                }

                return path.Substring(dot);
            }
            else return Path.GetExtension(path);
        }
    }
}
