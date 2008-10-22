using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core
{

    public enum SystemInputOutputDataType { Nummeric, Category, Boolean, Time };

    public class SystemInputOutput
    {
        public string Description
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public SystemInputOutput DataType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int NodeIndex
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }


    public class SystemInputOutputCollection : System.ComponentModel.BindingList<SystemInputOutput>
    {
    }
}
