using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

using Sinapse.Core.Filters;


namespace Sinapse.Core.Systems
{
    [Serializable]
    [DocumentDescription(".system.ann")]
    public class ActivationNetworkSystem : NetworkSystem, ISinapseDocument, ISerializableObject
    {
        


/*
        public ActivationNetworkSystem(IActivationFunction function, int inputsCount, params int[] neuronsCount)
        {
            Network = new ActivationNetwork(function, inputsCount, neuronsCount);
            Preprocess = new FilterCollection(false);
            Postprocess = new FilterCollection(true);
        }
*/

 
        public ActivationNetworkSystem(string name, System.IO.FileInfo info)
        {
            serializableObject = new SerializableObject<ActivationNetworkSystem>(this);
            sinapseDocument = new SinapseDocument(name, info);

            Preprocess = new FilterCollection(false);
            Postprocess = new FilterCollection(true);

            this.Name = name;
            this.HasChanges = true;
        }





        public new ActivationNetwork Network
        {
            get { return network as ActivationNetwork; }
            set { network = value; }
        }

        public override string Type
        {
            get { return "Activation Network"; }
        }

        public string Function
        {
            get { return this.Network[0][0].ActivationFunction.GetType().Name; }
        }







        public override object[][] Compute(params object[][] args)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override object[] Test(object[] input, object[] desiredOutput, out double[] rawOutput, out double[] deviation)
        {
            throw new Exception("The method or operation is not implemented.");
        }






        #region ISerializableObject<ActivationNetworkSystem> Members
        private SerializableObject<ActivationNetworkSystem> serializableObject;

        public bool Save(string path)
        {
            bool success = serializableObject.Save(path);
            if (success) this.HasChanges = false;
            return success;
        }

        public bool Save()
        {
            bool success = serializableObject.Save(File.FullName);
            if (success) this.HasChanges = false;
            return success;
        }

        public static ActivationNetworkSystem Open(string path)
        {
            return SerializableObject<ActivationNetworkSystem>.Open(path);
        }

        public event EventHandler FileSaved
        {
            add { serializableObject.FileSaved += value; }
            remove { serializableObject.FileSaved -= value; }
        }
        #endregion



        #region IWorkplaceComponent Members
        private SinapseDocument sinapseDocument;

        public string Name
        {
            get { return sinapseDocument.Name; }
            set { sinapseDocument.Name = value; }
        }

        public string Description
        {
            get { return sinapseDocument.Description; }
            set { sinapseDocument.Description = value; }
        }

        public string Remarks
        {
            get { return sinapseDocument.Remarks; }
            set { sinapseDocument.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return sinapseDocument.HasChanges; }
            protected set { sinapseDocument.HasChanges = value; }
        }

        public System.IO.FileInfo File
        {
            get { return sinapseDocument.File; }
        }

        public event EventHandler DocumentChanged;
        public event EventHandler FilepathChanged;
        public event EventHandler Closed;

        #endregion
    }
}
