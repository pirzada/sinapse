using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.IO;


namespace Sinapse.Core
{
    public interface ISinapseDocument : ISerializableObject
    {
        string Name { get; set;}
        string Description { get; set;}
        string Remarks { get; set;}

        /// <summary>
        ///   The File path of this Document. If left null, it should be
        ///   specified when the document is first saved.
        /// </summary>
        FileInfo File { get; set; }

        /// <summary>
        ///   The Workplace Owner of this Document. If left null, the
        ///   document will be treated as a standalone file. Some features
        ///   may not be available.
        /// </summary>
        Workplace Owner { get; set; } // Should be optional / can be null

        //bool Save(string path);
        bool Save();

        bool HasChanges { get; }

        event EventHandler SavepathChanged;
        event EventHandler ContentChanged;
    }

    [Serializable]
    public sealed class SinapseDocument : ISinapseDocument
    {
        
        private String name;
        private String description;
        private String remarks;

        [NonSerialized]
        private FileInfo fileInfo;

        [field: NonSerialized]
        private Workplace owner;


        [field: NonSerialized]
        private bool hasChanges;

        [field: NonSerialized]
        public event EventHandler ContentChanged;

        [field: NonSerialized]
        public event EventHandler SavepathChanged;



        #region Constructors
        /// <summary>
        ///   Creates a new SinapseDocument.
        /// </summary>
        /// <param name="name">
        ///   The name of the document.
        /// </param>
        /// <param name="fileInfo">
        ///   The path where it should be stored. If left null, the
        ///   path will have to be passed whenever Save() is called.
        /// </param>
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
        #endregion


        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    HasChanges = true;
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
                    HasChanges = true;
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
                    HasChanges = true;
                }
            }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set
            {
                if (value)
                {
                    if (hasChanges != value)
                    {
                        OnContentChanged(EventArgs.Empty);
                        hasChanges = value;
                        return;
                    }
                }
                else
                {
                    hasChanges = false;
                }
            }
        }

        public FileInfo File
        {
            get { return fileInfo; }
            set { fileInfo = value; }
        }

        public Workplace Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        #endregion



        private void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null)
                ContentChanged.Invoke(this, e);
        }

        private void OnSavepathChanged(EventArgs e)
        {
            if (SavepathChanged != null)
                SavepathChanged.Invoke(this, e);
        }


        #region ISinapseDocument Members
        public event EventHandler FileSaved
        {
            add { throw new InvalidOperationException(); }
            remove { throw new InvalidOperationException(); }
        }

        public bool Save(string path)
        {
            throw new InvalidOperationException();
        }

        public bool Save()
        {
            throw new InvalidOperationException();
        }
        #endregion



        // ----------------------------------------------------------


    }



   
}
