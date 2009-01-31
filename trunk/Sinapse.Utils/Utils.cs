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

        /// <summary>
        ///   Gets the relative path of the file in relation to a given directory.
        /// </summary>
        /// <param name="file">The file which will have its relative path computed.</param>
        /// <param name="directory">The directory which will be the base for the relative path.</param>
        /// <returns>The relative path.</returns>
        public static string GetRelativePath(this FileInfo file, string directory)
        {
            string[] firstPathParts = directory.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = file.FullName.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (!firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return file.FullName;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }
    }
}
