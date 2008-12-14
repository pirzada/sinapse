using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace Sinapse.Core
{

    /// <summary>
    ///   The WorkplaceContent class describes a content of a Workplace, such
    ///   as a DataSource, an AdaptiveSystem or a TrainingSession. It contains
    ///   information related to disk location and keeps track of the current
    ///   instantiated reference to the object.
    /// </summary>
    [Serializable]
    public class WorkplaceItem
    {
 //       [NonSerialized]
        private Workplace workplace; // For resolving relative paths

        private string fileName;
        private string relativePath; // Relative Path inside the workplace
        private bool included;
        Type type;



        internal WorkplaceItem(Workplace owner, string fileName, Type type)
        {

            if (!typeof(ISinapseComponent).IsAssignableFrom(type))
                throw new ArgumentException(
                    "The type should implement the IWorkplaceComponent interface",
                    "type");

            this.workplace = owner;
            this.type = type;
            this.relativePath = String.Empty;
            this.fileName = fileName;
            this.included = true;
        }

/*
        internal Workplace Owner
        {
            get { return workplace; }
            set { workplace = value; }
        }
*/
        /// <summary>
        ///   Gets or sets the relative filepath for the file associated
        ///   with this WorkplaceContent. Does not include the filename.
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
            get
            {
                return Path.Combine(workplace.FilePath,
                Path.Combine(relativePath, fileName));
            }
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


        /// <summary>
        ///   Opens (instantiates) a 
        /// </summary>
        /// <param name="newObject"></param>
        /// <returns></returns>
        public ISinapseComponent Open()
        {
            ISinapseComponent component = null;

            // First we check if file exists,
            if (File.Exists(FullPath))
            {
                // Create the method info for the static method SerializableObject<T>.Open
                MethodInfo methodOpen = type.GetMethod("Open",
                    BindingFlags.Static | BindingFlags.Public);

                component = (ISinapseComponent)methodOpen.Invoke(null, new object[] { FullPath });
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

            return component;
        }


        protected void document_FileChanged(object sender, EventArgs e)
        {
            // TODO: handle file changed event here
        }
    }



    [Serializable]
    public class WorkplaceItemCollection : BindingList<WorkplaceItem>
    {
   //     [NonSerialized]
        Workplace workplaceOwner;

        internal WorkplaceItemCollection(Workplace owner)
        {
            this.workplaceOwner = owner;
        }

        public new void Add(string filename, Type type)
        {
            this.Add(new WorkplaceItem(workplaceOwner, filename, type));
        }
/*
        internal Workplace Owner
        {
            get { return workplaceOwner; }
            set
            {
                workplaceOwner = value;

                foreach (WorkplaceItem item in this)
                {
                    item.Owner = value;
                }
            }
        }
 */ 
    }
}