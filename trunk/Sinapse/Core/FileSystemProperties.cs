using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sinapse.WinForms.Core
{
    public abstract class FileSystemProperties
    {
        protected string filePath; // relative or absolute file path
        protected string rootPath; // if empty, filePath is absolute


        public FileSystemProperties(String filePath, string rootPath)
        {
            this.filePath = filePath;
            this.rootPath = rootPath;
        }

        public FileSystemProperties(String filePath)
            : this(filePath, String.Empty)
        {
        }

        public String FullName
        {
            get { return Path.Combine(rootPath, filePath); }
        }

        public string RootPath
        {
            get { return rootPath; }
        }

        public bool IsRelative
        {
            get { return ((rootPath == null) || (rootPath.Length == 0)); }
        }


        public abstract void MoveTo(string dest);
        public abstract void CopyTo(string dest);
        public abstract void Rename(string newName);
        
        public void Delete()
        {
            File.Delete(FullName);
        }

    }
}
