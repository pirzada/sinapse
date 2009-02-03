using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace Sinapse.Core
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

        private string filePath;
        private Workplace owner; // if null, then the file has absolute path

        private bool missing;
        private Type type;

     //   private FileInfo fileInfo; // can be null




        #region Constructors
        public SinapseDocumentInfo(string path, Workplace workplace)
        {
            initialize(path, workplace);
        }


        public SinapseDocumentInfo(string filePath, Workplace workplace, Type type)
        {
            initialize(filePath, workplace, type);
        }

        private void initialize(string filePath, Workplace workplace)
        {
            Type type = DocumentCache.GetType(Utils.GetExtension(filePath, true));
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

            this.missing = File.Exists(FullName);
        }
        #endregion




        public String Path
        {
            get { return filePath; }
            private set
            {
                if (value != filePath)
                {
                    filePath = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged.Invoke(this,
                            new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }

        public String Name
        {
            get { return System.IO.Path.GetFileName(filePath); }
        }

        public String Directory
        {
            get { return System.IO.Path.GetDirectoryName(filePath); }
        }

        public String FullName
        {
            get
            {
                if (owner != null)
                    return System.IO.Path.Combine(owner.Root.FullName, filePath);
                else return filePath;
            }
        }

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
            get { return (owner == null); }
        }


        public Type Type
        {
            get { return type; }
        }



        public void Create()
        {
            ISinapseDocument doc = Activator.CreateInstance(type, new object[] {Name, new FileInfo(FullName)}) as ISinapseDocument;
            doc.Save(FullName);
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
        ///   Opens (instantiates) a Document
        /// </summary>
        /// <param name="newObject"></param>
        /// <returns></returns>
        public ISinapseDocument Open()
        {
            return SinapseDocument.Open(FullName);
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
