using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Sinapse.Core
{

    [Serializable]
    public class WorkplaceContent
    {
        private string fileName;
        private string filePath; // Relative Path
        private bool included;
        Type type;


        public WorkplaceContent(string name, Type type)
        {

            if (!typeof(ISerializableObject<>).IsAssignableFrom(type))
                throw new ArgumentOutOfRangeException("type",
                    "The type passed as parameter must implement the ISerializableObject interface");

            type = type;
            fileName = name;
        }


        public string FileName
        {
            get { return fileName; }
            set
            {
                System.IO.File.Move(System.IO.Path.Combine(filePath, fileName),
              System.IO.Path.Combine(filePath, value));
                fileName = value;
            }
        }

        public string FullPath
        {
            get { return System.IO.Path.GetFullPath(filePath); }
        }

        public Type Type
        {
            get { return type; }
        }

        public object Open()
        {
            // Create the method info for the static method SerializableObject<T>.Open
            MethodInfo methodOpen = typeof(SerializableObject<>).GetMethod("Open", System.Reflection.BindingFlags.Static | BindingFlags.Public);

            // Binding the method info to its generic arguments
            MethodInfo genericOpen = methodOpen.MakeGenericMethod(type);

            // Simply invoking the method and passing parameters
            // The null parameter is the object to call the method from. Since the method is
            // static, pass null. The parameter for the Open method is the path for the file.
            return genericOpen.Invoke(null, new object[] { FullPath });
        }
    }
}
