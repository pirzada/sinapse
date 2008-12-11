using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Sinapse.Core.Filters;

namespace Sinapse.Core.Systems
{
    /// <summary>
    /// A AdaptiveSystem is a model which accepts an Input, processes the information and then produces out an Output, while being able to respond to environmental changes or changes in its interacting parts.
    /// </summary>
    /// <remarks>This is an abstract class and cannot be instantiated.</remarks>
    public abstract class AdaptiveSystem : Sinapse.Core.ISerializableObject<AdaptiveSystem>
    {
        private SerializableObject<AdaptiveSystem> serializableObject;

        private IList<SystemInputOutput> inputs;
        private IList<SystemInputOutput> outputs;
        private IFilterCollection preprocess;
        private IFilterCollection postprocess;


        public IList<SystemInputOutput> Inputs
        {
            get { return inputs; }
        }

        public IList<SystemInputOutput> Outputs
        {
            get { return outputs; }
        }

        public IFilterCollection Preprocess
        {
            get { return preprocess; }
        }

        public IFilterCollection Postprocess
        {
            get { return postprocess; }
        }


        public String Name
        {
            get { return serializableObject.Name; }
            set { serializableObject.Name = value; }
        }

        public String Description
        {
            get { return serializableObject.Description; }
            set { serializableObject.Description = value; }
        }

        public String Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }

        public string Location
        {
            get { return serializableObject.Location; }
            set { serializableObject.Location = value; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
            set { serializableObject.HasChanges = value; }
        }

        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static AdaptiveSystem Open(string path)
        {
            return SerializableObject<AdaptiveSystem>.Open(path);
        }


        public abstract object[] Compute(params object[] args);
    }
}
