using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.IO;

namespace Sinapse.Core
{
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DocumentDescription : Attribute
    {
        private string name;
        private string extension;
        private string description;
        private string defaultName;
        private string category;

        private string iconPath;
        private int smallIconIndex;
        private int largeIconIndex;


        public DocumentDescription(string name)
        {
            this.name = name;
        }

        /// <summary>
        ///   The default extension for the document file, including
        ///   the first dot in the filename (e.g. Extension=".txt")
        /// </summary>
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

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public String IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        public Int32 SmallIconIndex
        {
            get { return smallIconIndex; }
            set { smallIconIndex = value; }
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
        private readonly String extension;

        public DocumentViewer(String extension)
        {
            this.extension = extension;
        }

        public String Extension
        {
            get { return extension; }
        }
    }

    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class FilterEditor : Attribute
    {
        private readonly Type filter;

        public FilterEditor(Type filter)
        {
            this.filter = filter;
        }

        public Type Filter
        {
            get { return filter; }
        }
    }
}
