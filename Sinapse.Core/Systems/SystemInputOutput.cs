using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using  System.ComponentModel;

namespace Sinapse.Core.Systems
{


    public enum SystemDataType { Nummeric, Category, Boolean, Time };
    public enum InputOutput { None = 0, Input = 1, Output = 2 };

    /// <summary>
    /// SystemInputOutput provides a description for a Input or Output of a System.
    /// It stores the name, description and type of the input or output.
    /// </summary>
    [Serializable]
    public class SystemInputOutput
    {

        private string description;
        private string name;
        private string caption;
        private SystemDataType dataType;
        private InputOutput inputOutput;
        private int index;

        public SystemInputOutput(string name, SystemDataType type, InputOutput role)
        {
            this.name = name;
            this.dataType = type;
            this.inputOutput = role;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Caption
        {
            get { return caption; }
            set { caption = value; }
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

        public InputOutput Role
        {
            get { return inputOutput; }
            set { inputOutput = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

    }


    [Serializable]
    public class SystemInputOutputCollection : BindingList<SystemInputOutput>, IBindingList
    {

        public SystemInputOutputCollection()
        {
            this.AllowEdit = true;
            this.AllowNew = true;
            this.AllowRemove = true;
        }

        public string[] GetNames(InputOutput role)
        {
            string[] names = new string[GetCount(role)];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = this[role, i].Name;
            }

            return names;
        }

        public int GetCount(InputOutput role)
        {
            int count = 0;
            foreach (SystemInputOutput io in this)
            {
                if (io.Role == role)
                    count++;
            }
            return count;
        }

        public SystemInputOutput this[InputOutput role, int index]
        {
            get
            {
                foreach (SystemInputOutput io in this)
                {
                    if (io.Role == role && io.Index == index)
                    return io;
                }
                throw new InvalidOperationException();
            }
        }



        #region IBindingList Members
        object IBindingList.AddNew()
        {
            SystemInputOutput s = new SystemInputOutput(String.Empty, SystemDataType.Nummeric, InputOutput.Input);
            this.Add(s);
            return s;
        }
        #endregion

    }

}
