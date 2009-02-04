using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;

using Sinapse.Core.Documents;

namespace Sinapse.Core.Documents
{

    /// <summary>
    ///   The SinapseDocumentInfo class describes a content of a Workplace, such
    ///   as a DataSource, an AdaptiveSystem or a TrainingSession. It contains
    ///   information related to disk location and keeps track of the current
    ///   instantiated reference to the object.
    /// </summary>
    /// <remarks>
    ///   It is necessary to at least display some properties on the property grid
    ///   whenever a Workplace Explorer item is selected.
    /// </remarks>
    [Serializable]
    public class SinapseDocumentInfo : INotifyPropertyChanged
    {

        /// <summary>
        ///   The relative or absolute file path, including filename,
        ///   extension and directory information.
        /// </summary>
        private string filePath;
        private Workplace owner; // if null, then the file has absolute path
        private Type type;





        #region Constructors
        /// <summary>
        ///   Creates a new SinapseDocumentInfo.
        /// </summary>
        /// <param name="path">
        ///    The path to the SinapseDocument. If workplace is specified, the given
        ///    path should be relative to this workplace. Otherwise, it should be absolute.
        /// </param>
        /// <param name="workplace">
        ///   The Workplace to which the path is relative to.
        /// </param>
        public SinapseDocumentInfo(string filePath, Workplace workplace)
        {
            initialize(filePath, workplace);
        }

        /// <summary>
        ///   Creates a new SinapseDocumentInfo.
        /// </summary>
        /// <param name="path">
        ///    The path to the SinapseDocument. If workplace is specified, the given
        ///    path should be relative to this workplace. Otherwise, it should be absolute.
        /// </param>
        /// <param name="workplace">
        ///   The Workplace to which the path is relative to.
        /// </param>
        /// <param name="type">
        ///   The type of the Document being referenced. It should be one of the ISinapseDocument
        ///   types or null. Any other types will be treated as null.
        /// </param>
        public SinapseDocumentInfo(string filePath, Workplace workplace, Type type)
        {
            initialize(filePath, workplace, type);
        }


        private void initialize(string filePath, Workplace workplace)
        {
            Type type = DocumentManager.GetType(Utils.GetExtension(filePath, true));
            initialize(filePath, workplace, type);
        }

        private void initialize(string filePath, Workplace workplace, Type type)
        {
            if (!typeof(ISinapseDocument).IsAssignableFrom(type))
            {
                this.type = null;
            }

            this.filePath = filePath;
            this.owner = workplace;
            this.type = type;
        }
        #endregion



        /// <summary>
        ///   The path for the file referenced by this SinapseDocumentInfo. It
        ///   can be absolute or relative to the Workplace owner, depending if
        ///   the Owner property was set or not. 
        /// </summary>
        public String Path
        {
            get { return filePath; }
            set
            {
                if (value != filePath)
                {
                    filePath = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged.Invoke(this,
                            new PropertyChangedEventArgs("Path"));
                    }
                }
            }
        }

        /// <summary>
        ///   Gets the filename (including its extension) of the current file
        ///   referenced by this SinapseDocumentInfo.
        /// </summary>
        public String Name
        {
            get { return System.IO.Path.GetFileName(filePath); }
        }

        /// <summary>
        ///   Gets the directory where the file referenced by this SinapseDocumentInfo
        ///   is located.
        /// </summary>
        public String Directory
        {
            get { return System.IO.Path.GetDirectoryName(filePath); }
        }

        /// <summary>
        ///   Gets the Full Name of the file referenced by this SinapseDocumentInfo.
        ///   The Full Name is always an absolute path.
        /// </summary>
        public String FullName
        {
            get
            {
                if (owner != null)
                    return System.IO.Path.Combine(owner.Root.FullName, filePath);
                else return filePath;
            }
        }

        /// <summary>
        ///   Gets or sets the Workplace to which relative address correspond. If
        ///   null, the paths will be considered absolute.
        /// </summary>
        public Workplace Workplace
        {
            get { return owner; }
            set { owner = value; }
        }


        /// <summary>
        ///   Gets or sets a boolean value indicating whether the Path for
        ///   the Document file is relative to the active Workplace or not.
        /// </summary>
        public bool IsPathRelative
        {
            get { return (owner != null); }
        }


        /// <summary>
        ///   Gets the type of the document referenced by this SinapseDocumentInfo.
        /// </summary>
        public Type Type
        {
            get { return type; }
        }



        /// <summary>
        ///   Saves the SinapseDocument referenced by this SinapseDocumentInfo to the disk.
        ///   If type is null, only creates an empty file.
        /// </summary>
        public void Create()
        {
            if (type == null)
            {
                File.Create(FullName);
            }
            else
            {
                ISinapseDocument doc = Activator.CreateInstance(type, new object[] { Name, new FileInfo(FullName) }) as ISinapseDocument;
                doc.Save(FullName);
            }
        }

        public void Rename(string newName)
        {
            Move(System.IO.Path.Combine(this.Directory, newName));
        }

        public void Move(string newPath)
        {
            string oldName = this.FullName;
            this.Path = newPath;
            File.Move(oldName, FullName);
        }

        public void Copy(string newPath)
        {
            if (owner != null)
                File.Copy(FullName, System.IO.Path.Combine(owner.Root.FullName, newPath));
            else File.Copy(FullName, newPath);
        }

        public void Delete()
        {
            File.Delete(FullName);
        }

        /// <summary>
        ///   Opens (instantiates) the referenced SinapseDocument.
        /// </summary>
        public ISinapseDocument Open()
        {
            return DocumentManager.Open(FullName);
        }



        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }


/*
    [Serializable]
    public class SinapseDocumentInfoCollection : BindingList<SinapseDocumentInfo>
    {


        internal SinapseDocumentInfoCollection()
        {

        }

        public new void Add(string fullName, bool relative)
        {
            this.Add(new SinapseDocumentInfo(fullName, relative));
        }

        public SinapseDocumentInfo[] Select(Type type)
        {
            List<SinapseDocumentInfo> documents = new List<SinapseDocumentInfo>();
            foreach (SinapseDocumentInfo doc in this)
            {
                if (doc.GetType().IsAssignableFrom(type))
                    documents.Add(doc);
            }
            return documents.ToArray();
        }
    }
 */ 
}
