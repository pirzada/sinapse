using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Sinapse.Core
{
    public interface ISinapseDocument
    {
        string Name { get; set;}
        string Description { get; set;}
        string Remarks { get; set;}
        FileInfo File { get; }

        bool HasChanges { get; }

        event EventHandler Changed;
    }

    [Serializable]
    internal class SinapseDocument : ISinapseDocument
    {
               
        
        private string name;
        private string description;
        private string remarks;
        private FileInfo fileInfo;

        [NonSerialized]
        private bool hasChanges;

        [field: NonSerialized]
        public event EventHandler Changed;



        public SinapseDocument(String name, FileInfo fileInfo)
        {
            this.name = name;
            this.fileInfo = fileInfo;
            this.remarks = String.Empty;
            this.description = String.Empty;
        }

        

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (name != value)
                {
                    name = value;
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
                }
            }
        }

        public string Remarks
        {
            get { return remarks; }
            set
            {
                if (remarks != value)
                {
                    remarks = value;
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
                }
            }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set
            {
                if (hasChanges != value)
                {
                    hasChanges = value;
                }
            }
        }

        public FileInfo File
        {
            get { return fileInfo; }
        }





        protected void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed.Invoke(this, e);
        }



        #region Static Methods - Extensions & Icons
        public static Type GetType(string extension)
        {
            Type[] types = Sinapse.Utils.GetTypesImplementingInterface(
                Assembly.GetAssembly(typeof(ISinapseDocument)), typeof(ISinapseDocument));
            
            foreach (Type type in types)
            {
                object[] attr = type.GetCustomAttributes(typeof(DefaultExtension), false);
                if (attr.Length > 0)
                {
                    if ((attr[0] as DefaultExtension).Extension.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                      return type;
                }
            }

            return null;
        }

        public static String GetExtension(Type type)
        {
            object[] attr = type.GetCustomAttributes(typeof(DefaultExtension), false);
            if (attr.Length > 0) return (attr[0] as DefaultExtension).Extension;
            throw new ArgumentException("", "type");
        }
        #endregion

    }



    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class DefaultExtension : Attribute
    {
        readonly string extension;

        // This is a positional argument
        public DefaultExtension(string extension)
        {
            this.extension = extension;
        }

        public String Extension
        {
            get { return extension; }
            //set { extension = value; }
        }

    }
}
