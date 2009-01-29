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
    [Serializable]
    public class SinapseDocumentInfo
    {

        private Workplace owner;
        private string relativeName; // Must be relative because the user should be
        private Type type;           //  able to move workplaces around without breaking
        private bool missing;        //  the directory structure.



        internal SinapseDocumentInfo(Workplace owner, string relativeName, Type type)
        {

            if (!typeof(ISinapseDocument).IsAssignableFrom(type))
                throw new ArgumentException(
                    "The type should implement the ISinapseDocument interface",
                    "type");

            this.owner = owner;
            this.relativeName = relativeName;
            this.missing = File.Exists(FullName);
            this.type = type;
        }

        public String RelativeName
        {
            get { return relativeName; }
            set { relativeName = value; }
        }

        public String FullName
        {
            get { return Path.Combine(owner.Root.FullName, relativeName); }
        }

        public String Name
        {
            get { return Path.GetFileNameWithoutExtension(relativeName); }
        }

        public Type Type
        {
            get { return type; }
        }
       


        /// <summary>
        ///   Opens (instantiates) a 
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
/*
            // Now we register the FileChanged event to keep track on name changes
            EventInfo e = type.GetEvent("FileChanged");
            e.AddEventHandler(component, new EventHandler(document_FileChanged));
*/

            return document;
        }


        protected void document_FileChanged(object sender, EventArgs e)
        {
            // TODO: handle file changed event here
        }
    }



    [Serializable]
    public class SinapseDocumentInfoCollection : BindingList<SinapseDocumentInfo>
    {
        [NonSerialized]
        Workplace workplaceOwner;

        internal SinapseDocumentInfoCollection(Workplace owner)
        {
            this.workplaceOwner = owner;
        }

        public new void Add(string relativePath, Type type)
        {
            this.Add(new SinapseDocumentInfo(workplaceOwner, relativePath, type));
        }

        public SinapseDocumentInfo[] Select(string ext)
        {
            List<SinapseDocumentInfo> documents = new List<SinapseDocumentInfo>();
            foreach (SinapseDocumentInfo d in this)
            {
                if (Path.GetExtension(d.RelativeName).StartsWith(ext, StringComparison.OrdinalIgnoreCase))
                    documents.Add(d);
            }
            return documents.ToArray();
        }
    }
}
