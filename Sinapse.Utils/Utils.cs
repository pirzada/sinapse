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
        /// Returns all types in the current AppDomain implementing the interface. 
        /// </summary>
        public static Type[] GetTypesImplementingInterface(Assembly assembly, Type baseType)
        {
            List<Type> childTypes = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
               /* foreach (Type interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.Equals(baseType))
                    {
                        childTypes.Add(type);
                    }
                }
                */
                if (baseType.IsAssignableFrom(type))
                    childTypes.Add(type);
            }

            return childTypes.ToArray();
        }
/*
        /// <summary>
        /// Returns all types in the current AppDomain inheriting the type. 
        /// </summary>
        public static Type[] GetTypesInheritingFrom(Assembly assembly, Type baseType)
        {
            List<Type> childTypes = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (baseType.IsAssignableFrom(type))
                        childTypes.Add(type);
            }

            return childTypes.ToArray();
        }
*/
        public static string GetExtension(string path, bool multidotted)
        {
            if (multidotted)
            {
                int dot = path.Length;
                for (int i = path.Length - 1; i >= 0; i--)
                {
                    if (path[i].Equals(Path.DirectorySeparatorChar) ||
                        path[i].Equals(Path.AltDirectorySeparatorChar))
                    {
                        break; //TODO: revision needed
                    }

                    if (path[i] == '.')
                        dot = i;
                }

                return path.Substring(dot);
            }
            else return Path.GetExtension(path);
        }

        public static void CopyDirectory(string source, string destination, bool overwrite)
        {
            // Create the destination folder if missing.
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            DirectoryInfo dirInfo = new DirectoryInfo(source);

            // Copy all files.
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
                fileInfo.CopyTo(Path.Combine(destination, fileInfo.Name), overwrite);

            // Recursively copy all sub-directories.
            foreach (DirectoryInfo subDirectoryInfo in dirInfo.GetDirectories())
                CopyDirectory(subDirectoryInfo.FullName, Path.Combine(destination, subDirectoryInfo.Name), overwrite);
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
