using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core
{
    public class SerializableObject<T> : ISerializableObject<T>
    {

        private string name;
        private string description;
        private string location;
     // private DateTime creation;
        private bool hasChanges;


        public SerializableObject()
        {
            name = String.Empty;
            description = String.Empty;
            location = String.Empty;
         // creation = DateTime.Now;
            hasChanges = false;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Remarks
        {
            get { return Remarks; }
            set { Remarks = value; }
        }

        public bool HasChanges
        {
            get { return hasChanges; }
            set { hasChanges = value; }
        }


        public bool Save(string path)
        {
            throw new NotImplementedException();
            hasChanges = false;
        }

        public bool Save()
        {
            return Save(location);
        }

        public static T Open(string path)
        {
            throw new NotImplementedException();
        }

    }
}
