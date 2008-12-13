using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Sinapse.Core
{

    [Serializable]
    public class WorkplaceContent
    {
        private Workplace workplace; // For resolving relative paths

        private string fileName;
        private string relativePath; // Relative Path inside the workplace
        private bool included;
    //    object openDocument;
        Type type;


        public WorkplaceContent(Workplace owner, string name, Type type)
        {
/*
            if (!type.IsAssignableFrom(typeof(ISerializableObject<>)))
                throw new ArgumentOutOfRangeException("type",
                    "The type passed as parameter must implement the ISerializableObject interface");
*/
            this.workplace = owner;
            this.type = type;
            this.relativePath = String.Empty;
            this.fileName = name;
        }


        /// <summary>
        ///   Gets or sets the relative filepath for the file
        ///   associated with this WorkplaceContent
        /// </summary>
        public string RelativePath
        {
            get { return relativePath; }
            set { relativePath = value; }
        }

        /// <summary>
        ///   Gets or sets the filename for the file associated
        ///   with this WorkplaceContent
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        ///   Gets the full path for the file associated with this
        ///   WorkplaceContent using the full Workplace path and
        ///   the associated file relative path.
        /// </summary>
        public string FullPath
        {
            get { return Path.Combine(workplace.FilePath, relativePath); }
        }

        public Type Type
        {
            get { return type; }
        }

        /// <summary>
        ///   Gets or sets a boolean flag indicating if the file
        ///   associated with this WorplaceContent is included on
        ///   the active workplace.
        /// </summary>
        public bool Included
        {
            get { return included; }
            set { included = value; }
        }



        public void Move()
        {
            throw new NotImplementedException();
        }
        public void Rename()
        {
            throw new NotImplementedException();
        }
        public void Copy()
        {
            throw new NotImplementedException();
        }



        public object Open()
        {
            // First we check if file exists,
            if (File.Exists(FullPath))
            {
                // Create the method info for the static method SerializableObject<T>.Open
                MethodInfo methodOpen = type.GetMethod("Open",
                    BindingFlags.Static | BindingFlags.Public);

                // Binding the method info to its generic arguments
                //MethodInfo genericOpen = methodOpen.MakeGenericMethod(type);
                 return methodOpen.Invoke(null, new object[] { FullPath });

                // Simply invoking the method and passing parameters
                // The null parameter is the object to call the method from. Since the method is
                // static, pass null. The parameter for the Open method is the path for the file.
                //return genericOpen.Invoke(null, new object[] { FullPath });
            }
            else
            {
                // The file does not exists, so we create a new instance.
                return Activator.CreateInstance(type);
            }
        }
    }
}
