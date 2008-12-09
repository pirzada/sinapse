using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Systems
{
    /// <summary>
    /// A AdaptiveSystem is a model which accepts an Input, processes the information and then produces out an Output, while being able to respond to environmental changes or changes in its interacting parts.
    /// </summary>
    /// <remarks>This is an abstract class and cannot be instantiated.</remarks>
    public abstract class AdaptiveSystem : Sinapse.Core.ISerializableObject<System.Object>
    {
        private List<SystemInputOutput> inputs;
        private List<SystemInputOutput> outputs;
    
        public List<SystemInputOutput> Inputs
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<SystemInputOutput> Outputs
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Sinapse.Core.Filters.IFilterCollection Preprocess
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Sinapse.Core.Filters.IFilterCollection Postprocess
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime Creation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String Description
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Remarks
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

        public void Compute(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        #region ISerializableObject<object> Members


        public string Location
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool HasChanges
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool Save(string path)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object Open(string path)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
