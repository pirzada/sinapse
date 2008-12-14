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

        [NonSerialized]
        private bool hasChanges;

        [field: NonSerialized]
        public event EventHandler Changed;



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
                if (name != value)
                {
                    name = value;
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
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
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
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
                    hasChanges = true;
                    OnChanged(EventArgs.Empty);
                }
            }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set
            {
                if (hasChanges != value)
                {
                    hasChanges = value;
                }
            }
        }


        protected void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed.Invoke(this, e);
        }
    }
}
