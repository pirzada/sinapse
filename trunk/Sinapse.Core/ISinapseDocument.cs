using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        private static Dictionary<String, Type> extensions;
        private static Dictionary<Type, String> icons;

        public static Type GetType(string extension)
        {
            return extensions[extension];
        }

        public static String GetIcon(Type type)
        {
            return icons[type];
        }

        public static String GetExtension(Type type)
        {
            extensions.
        }
        #endregion

    }
}
