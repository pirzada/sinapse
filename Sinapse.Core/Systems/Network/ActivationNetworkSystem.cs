using System;
using System.Collections.Generic;
using System.Text;

using AForge.Neuro;

namespace Sinapse.Core.Systems
{
    public class ActivationNetworkSystem : NetworkSystem, ISerializableObject<ActivationNetworkSystem>
    {
        private SerializableObject<ActivationNetworkSystem> serializableObject;



        public ActivationNetworkSystem(IActivationFunction function, int inputsCount, params int[] neuronsCount)
        {
            Network = new ActivationNetwork(function, inputsCount, neuronsCount);
        }

        public ActivationNetworkSystem()
        {
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

        public string Remarks
        {
            get { return serializableObject.Remarks; }
            set { serializableObject.Remarks = value; }
        }



        public string FileName
        {
            get { return serializableObject.FileName; }
            set { serializableObject.FileName = value; }
        }

        public string FilePath
        {
            get { return serializableObject.FilePath; }
            set { serializableObject.FilePath = value; }
        }

        public string DefaultExtension
        {
            get { return "sann"; }
        }

        public bool HasChanges
        {
            get { return serializableObject.HasChanges; }
            set { serializableObject.HasChanges = value; }
        }



        public string FullPath
        {
            get { return serializableObject.FullPath; }
        }


        public bool Save(string path)
        {
            return serializableObject.Save(path);
        }

        public bool Save()
        {
            return serializableObject.Save();
        }

        public static ActivationNetworkSystem Open(string path)
        {
            return SerializableObject<ActivationNetworkSystem>.Open(path);
        }

        #endregion
    }
}
