using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sinapse.WinForms.Core
{
    public class FileProperties : FileSystemProperties
    {

        public FileProperties(string filePath, string rootPath)
            : base(filePath, rootPath)
    {
    }

        public FileInfo FileInfo
        {
            get { return new FileInfo(this.FullName); }
        }

        public String FileName
        {
            get { return Path.GetFileName(base.filePath); }
        }

        public override void MoveTo(string dest)
        {
            throw new NotImplementedException();
        }

        public override void CopyTo(string dest)
        {
            throw new NotImplementedException();
        }

        public override void Rename(string newName)
        {
            throw new NotImplementedException();
        }

    }
}
