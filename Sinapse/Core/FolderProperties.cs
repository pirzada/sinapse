using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sinapse.WinForms.Core
{
    public class FolderProperties : FileSystemProperties
    {

        public FolderProperties(string filePath, string rootPath)
            : base(filePath, rootPath)
        {

        }

        public FolderProperties(string filePath)
            : base(filePath, String.Empty)
        {

        }

        public DirectoryInfo DirectoryInfo
        {
            get { return new DirectoryInfo(FullName); }
        }

        public String FolderName
        {
            get { return Path.GetDirectoryName(base.filePath); }
        }

        

        public override void Rename(string newName)
        {
            MoveTo(Path.Combine(Directory.GetParent(filePath).FullName, newName));
        }

        public override void MoveTo(string newPath)
        {
            string oldName = this.FullName;
            base.filePath = newPath;
            File.Move(oldName, FullName);
        }

        public override void CopyTo(string newPath)
        {
            if (IsRelative)
                Utils.CopyDirectory(FullName, Path.Combine(rootPath, newPath), false);
            else Utils.CopyDirectory(FullName, newPath, false);
        }

    }
}
