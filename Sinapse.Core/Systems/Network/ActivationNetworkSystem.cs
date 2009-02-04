using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using AForge.Neuro;

using Sinapse.Core.Filters;
using Sinapse.Core.Documents;


namespace Sinapse.Core.Systems
{
    [Serializable]
    [DocumentDescription("Activation Network System",
        DefaultName="activationNetwork",
        Description="Activation Neural Network",
        Extension=".system.ann",
        IconPath="Resources/System.ico")]
    public class ActivationNetworkSystem : NetworkSystem, ISinapseDocument
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
            ActivationNetworkSystem doc = SerializableObject<ActivationNetworkSystem>.Open(path);
            doc.File = new System.IO.FileInfo(path);
            return doc;
        }

        public event EventHandler FileSaved
        {
            add { serializableObject.FileSaved += value; }
            remove { serializableObject.FileSaved -= value; }
        }
        #endregion



        #region ISinapseDocument Members
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
            set { sinapseDocument.File = value; }
        }

        public Workplace Owner
        {
            get { return sinapseDocument.Owner; }
            set { sinapseDocument.Owner = value; }
        }

        public event EventHandler SavepathChanged
        {
            add { sinapseDocument.SavepathChanged += value; }
            remove { sinapseDocument.SavepathChanged -= value; }
        }

        public event EventHandler ContentChanged
        {
            add { sinapseDocument.ContentChanged += value; }
            remove { sinapseDocument.ContentChanged -= value; }
        }

        #endregion

    }
}
