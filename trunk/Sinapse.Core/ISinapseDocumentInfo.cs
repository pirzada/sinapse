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
        private bool relative;

        private bool missing;
        private Type type;




        #region Constructors
        public SinapseDocumentInfo(string path, bool relative)
        {
            initialize(path, relative);
        }


        public SinapseDocumentInfo(string filePath, bool relative, Type type)
        {
            initialize(filePath, relative, type);
        }

        private void initialize(string filePath, bool relative)
        {
            Type type = SinapseDocument.GetType(Utils.GetExtension(filePath, true));
            initialize(filePath, relative, type);
        }

        private void initialize(string filePath, bool relative, Type type)
        {
            if (!typeof(ISinapseDocument).IsAssignableFrom(type))
                throw new ArgumentException(
                    "The type must implement the ISinapseDocument interface",
                    "type");

            this.filePath = filePath;
            this.relative = relative;
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
                if (relative)
                    return System.IO.Path.Combine(Workplace.Active.Root.FullName, filePath);
                else return filePath;
            }
        }


        /// <summary>
        ///   Gets or sets a boolean value indicating whether the Path for
        ///   the Document file is relative to the active Workplace or not.
        /// </summary>
        public bool Relative
        {
            get { return relative; }
            set { relative = value; }
        }


        public Type Type
        {
            get { return type; }
        }



        public void Create()
        {
            File.Create(FullName);
        }

        public void Move(string newPath)
        {
            string oldName = this.FullName;
            this.Path = newPath;
            File.Move(oldName, FullName);
        }

        public void Copy(string newPath)
        {
            if (relative)
                File.Copy(FullName, System.IO.Path.Combine(Workplace.Active.Root.FullName, newPath));
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
            ISinapseDocument document = null;

            // First we check if file exists,
            if (File.Exists(FullName))
            {
                // Create the method info for the static method SerializableObject<T>.Open
                MethodInfo methodOpen = type.GetMethod("Open",
                    BindingFlags.Static | BindingFlags.Public);

                // Call the Open method passing the FullPath as its first parameter
                document = (ISinapseDocument)methodOpen.Invoke(null, new object[] { FullName });
            }
            else
            {
                // The file does not exists, so we create a new instance.
                //  component = (ISinapseComponent)Activator.CreateInstance(type);
                throw new InvalidOperationException();
            }

            // Now we register the FileChanged event to keep track on name changes
            EventInfo e = type.GetEvent("FilepathChanged");
            e.AddEventHandler(document, new EventHandler(document_FilepathChanged));


            return document;
        }


        protected void document_FilepathChanged(object sender, EventArgs e)
        {
            // TODO: handle file changed event here
        }



        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }



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
}
