using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Sinapse.Core
{
    public interface ISinapseDocument : ISerializableObject
    {
        string Name { get; set;}
        string Description { get; set;}
        string Remarks { get; set;}
        FileInfo File { get; }

        bool Save(string path);
        bool Save();

        bool HasChanges { get; }

        event EventHandler DocumentChanged;
        event EventHandler FilepathChanged;
    }

    [Serializable]
    public sealed class SinapseDocument
    {
        
        private string name;
        private string description;
        private string remarks;
        private FileInfo fileInfo;

        [NonSerialized]
        private bool hasChanges;

        


        public SinapseDocument(String name, FileInfo fileInfo)
        {
            this.name = name;
            this.fileInfo = fileInfo;
            this.remarks = String.Empty;
            this.description = String.Empty;
        }

        public SinapseDocument(string name) : this(name, null)
        {
        }


        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    hasChanges = true;
                    OnDocumentChanged(EventArgs.Empty);
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
                    OnDocumentChanged(EventArgs.Empty);
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
                    OnDocumentChanged(EventArgs.Empty);
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
        #endregion



        [field: NonSerialized]
        public event EventHandler DocumentChanged;

        [field: NonSerialized]
        public event EventHandler FilepathChanged;


        private void OnDocumentChanged(EventArgs e)
        {
            if (DocumentChanged != null)
                DocumentChanged.Invoke(this, e);
        }

        private void OnFilepathChanged(EventArgs e)
        {
            if (FilepathChanged != null)
                FilepathChanged.Invoke(this, e);
        }



        #region Static Methods
        public static ISinapseDocument Open(string fullName)
        {
            ISinapseDocument document = null;

            // First we check if file exists,
            if (System.IO.File.Exists(fullName))
            {
                // Determine the type of the document being open
                Type type = DocumentCache.GetType(Utils.GetExtension(fullName, true));
                
                // Create the method info for the static method SerializableObject<T>.Open
                MethodInfo methodOpen = type.GetMethod("Open",
                    BindingFlags.Static | BindingFlags.Public);

                // Call the Open method passing the FullPath as its first parameter
                document = (ISinapseDocument)methodOpen.Invoke(null, new object[] { fullName });
            }
            else
            {
                // The file does not exists, so we create a new instance.
                //  component = (ISinapseComponent)Activator.CreateInstance(type);
                throw new InvalidOperationException();
            }

            return document;
        }
        #endregion

    }



    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DocumentDescription : Attribute
    {
        private string name;
        private string extension;
        private string description;
        private string defaultName;

        private string smallIconPath;
        private string largeIconPath;
        private int smallIconIndex;
        private int largeIconIndex;



        public DocumentDescription(string name)
        {
            this.name = name;
        }

        public String Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String DefaultName
        {
            get { return defaultName; }
            set { defaultName = value; }
        }

        public String SmallIconPath
        {
            get { return smallIconPath; }
            set { smallIconPath = value; }
        }

        public Int32 SmallIconIndex
        {
            get { return smallIconIndex; }
            set { smallIconIndex = value; }
        }

        public String LargeIconPath
        {
            get { return largeIconPath; }
            set { largeIconPath = value; }
        }

        public Int32 LargeIconIndex
        {
            get { return largeIconIndex; }
            set { largeIconIndex = value; }
        }

    }

    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DocumentViewer : Attribute
    {
        private readonly Type type;

        public DocumentViewer(Type documentType)
        {
           if (!type.IsAssignableFrom(typeof(ISinapseDocument)))
           {
               throw new ArgumentException(
                   "The type must implement ISinapseDocument interface",
                   "documentType");
           }
            this.type = documentType;
        }

        public Type DocumentType
        {
            get { return type; }
        }

    }
}
