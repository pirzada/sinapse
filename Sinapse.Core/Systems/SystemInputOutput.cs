using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Systems
{


    public enum SystemDataType { Nummeric, Category, Boolean, Time };

    /// <summary>
    /// SystemInputOutput provides a description for a Input or Output of a System.
    /// It stores the name, description and type of the input or output.
    /// </summary>
    public class SystemInputOutput
    {

        private string description;
        private string name;
        private SystemDataType dataType;

        public SystemInputOutput(string name, SystemDataType type)
        {
            this.name = name;
            this.dataType = type;
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


        public SystemDataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

    }


    public class SystemInputOutputCollection : System.ComponentModel.BindingList<SystemInputOutput>
    {
    }

}
