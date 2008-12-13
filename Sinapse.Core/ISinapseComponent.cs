using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core
{
    public interface ISinapseComponent //: IDisposable
    {
        string Name { get; set;}
        string Description { get; set;}
        string Remarks { get; set;}

        bool HasChanges { get; }
        //   void Close();

        event EventHandler Changed;
 //       event EventHandler Closed;

    }

    [Serializable]
    internal sealed class SinapseComponent : ISinapseComponent
    {
        private string name;
        private string description;
        private string remarks;
        private bool hasChanges;

        [field: NonSerialized]
        public event EventHandler Changed;

        [field: NonSerialized]
        public event EventHandler Closed;


        public SinapseComponent()
        {
            this.name = String.Empty;
            this.description = String.Empty;
            this.remarks = String.Empty;
        }


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                hasChanges = true;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                hasChanges = true;
            }
        }

        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                hasChanges = true;
            }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set { hasChanges = value; }
        }

    }
}
