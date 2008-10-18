/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Diagnostics;

using AForge.Neuro;


namespace Sinapse.Data.Network
{

    /// <summary>
    /// Wraps additional information around a classic Neural Network
    /// </summary>
    [Serializable]
    internal sealed class NetworkContainer : SerializableObject<NetworkContainer>
    {

        private NetworkSchema m_networkSchema;
        private ActivationNetwork m_activationNetwork;
        private string m_networkName;
        private string m_networkDescription;
        private string m_networkInformation;
        private double m_networkPrecision;
        private double m_networkDeviation;
        private DateTime m_creationTime;


        private NetworkSavepointCollection m_savepointCollection;
       
        [NonSerialized]
        private bool m_hasUnsavedChanges;

        [NonSerialized]
        public EventHandler NetworkChanged;
 

        //---------------------------------------------


        #region Constructor
        public NetworkContainer(string networkName, NetworkSchema schema, IActivationFunction function, params int[] hiddenLayersNeuronCount)
        {
            this.m_networkSchema = schema;
            this.m_networkName = networkName;

            /*
            int[] neuronsCount = new int[hiddenLayersNeuronCount.Length + 2];
            neuronsCount[0] = schema.InputColumns.Length;
            neuronsCount[hiddenLayersNeuronCount.Length + 1] = schema.OutputColumns.Length;
            hiddenLayersNeuronCount.CopyTo(neuronsCount, 1); 
             */

            int[] neuronsCount = new int[hiddenLayersNeuronCount.Length + 1];
            neuronsCount[hiddenLayersNeuronCount.Length] = schema.OutputColumns.Length;
            hiddenLayersNeuronCount.CopyTo(neuronsCount, 0);
            this.m_activationNetwork = new ActivationNetwork(function, schema.InputColumns.Length, neuronsCount);

            this.m_creationTime = DateTime.Now;
            
            this.m_savepointCollection = new NetworkSavepointCollection(this);
            this.WireUpEvents();
        }

        public NetworkContainer(NetworkSchema schema, IActivationFunction function, params int[] hiddenLayersNeuronCount)
            : this(String.Empty, schema, function, hiddenLayersNeuronCount)
        {
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// The neural network held by this Network Container
        /// </summary>
        public ActivationNetwork ActivationNetwork
        {
            get { return this.m_activationNetwork; }
        }

        /// <summary>
        /// The data schema attached to the inner neural network
        /// </summary>
        public NetworkSchema Schema
        {
            get { return this.m_networkSchema; }
        }

        public NetworkSavepointCollection Savepoints
        {
            get { return this.m_savepointCollection; }
        }

        public string Type
        {
            get { return this.m_activationNetwork.GetType().Name; }
        }

        public string Function
        {
            get { return this.m_activationNetwork[0][0].ActivationFunction.GetType().Name; }
        }

        /// <summary>
        /// Gives the layout of the network (layer organization) as a hifen seperated string
        /// </summary>
        public string Layout
        {
            get
            {

                string layout = String.Empty;

                for (int i = 0; i < this.m_activationNetwork.LayersCount; ++i)
                {
                    layout += this.m_activationNetwork[i].NeuronsCount;

                    if (i < this.m_activationNetwork.LayersCount - 1)
                        layout += "-";
                }

                return layout;
            }
        }

        /// <summary>
        /// The associated name of the neural network
        /// </summary>
        public string Name
        {
            get { return this.m_networkName; }
            set
            {
                this.m_networkName = value;
                this.OnNetworkChanged();
            }
        }

        /// <summary>
        /// Network description
        /// </summary>
        public string Description
        {
            get { return this.m_networkDescription; }
            set
            {
                this.m_networkDescription = value;
                this.OnNetworkChanged();
            }
        }

        /// <summary>
        /// Network usage and additional information
        /// </summary>
        public string Information
        {
            get { return this.m_networkInformation; }
            set { this.m_networkInformation = value; }
        }

        /// <summary>
        /// Training precision
        /// </summary>
        public double Precision
        {
            get { return m_networkPrecision; }
            set
            {
                this.m_networkPrecision = value;
                this.OnNetworkChanged();
            }
        }

        /// <summary>
        /// Deviation of the last performance measurement on a testing set
        /// </summary>
        public double Deviation
        {
            get { return this.m_networkDeviation; }
            set
            {
                this.m_networkDeviation = value;
                this.OnNetworkChanged();
            }
        }

        public bool HasUnsavedChanges
        {
            get { return this.m_hasUnsavedChanges; }
        }

        /// <summary>
        /// The date of creation for this neural network
        /// </summary>
        public DateTime CreationTime
        {
            get { return this.m_creationTime; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void WireUpEvents()
        {
            this.m_savepointCollection.SavepointRestored += savepointCollection_SavepointRestored;
        }
        #endregion


        //---------------------------------------------


        #region Object Events
        private void OnNetworkChanged()
        {
            if (this.NetworkChanged != null)
                this.NetworkChanged.Invoke(this, EventArgs.Empty);

            this.m_hasUnsavedChanges = true;
        }

        private void savepointCollection_SavepointRestored(object sender, EventArgs e)
        {
            this.m_activationNetwork = m_savepointCollection.CurrentSavepoint.ActivationNetwork;
            this.m_networkPrecision = m_savepointCollection.CurrentSavepoint.ErrorTraining;
            this.OnNetworkChanged();
        }

        private void savepointCollection_SavepointRegistered(object sender, EventArgs e)
        {

        }
        #endregion


        //---------------------------------------------


        #region Import & Export
        /// <summary>
        /// Imports a network saved in .xml format using Soap formatter
        /// </summary>
        /// <param name="path">The full path of the file to be open</param>
        public void XmlImport(string path)
        {
          /*  XmlTextReader xmlReader = new XmlTextReader(path);
            XmlSerializer xs = new XmlSerializer(typeof(AForge.Neuro.ActivationNetwork));
            this.m_activationNetwork = (AForge.Neuro.ActivationNetwork)xs.Deserialize(xmlReader);
            xmlReader.Close();
           */

            FileStream fileStream = new FileStream(path, FileMode.Open);
            SoapFormatter sf = new SoapFormatter();
            this.m_activationNetwork = (ActivationNetwork)sf.Deserialize(fileStream);
            fileStream.Close();
        }

        /// <summary>
        /// Exports the network as a .xml file using Soap formatter
        /// </summary>
        /// <param name="path">The full path of the file to be written</param>
        public void XmlExport(string path)
        {
            /*
            XmlTextWriter xmlWriter = new XmlTextWriter(path, Encoding.UTF8);
            XmlSerializer xs = new XmlSerializer(typeof(AForge.Neuro.ActivationNetwork));
            xs.Serialize(xmlWriter, this.ActivationNetwork);
            xmlWriter.Close();
            */

            FileStream fileStream = new FileStream(path, FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fileStream, this.m_activationNetwork);
            fileStream.Close();
        }

        /// <summary>
        /// Exports the network as a human friendly text file 
        /// </summary>
        /// <param name="path"></param>
        public void TxtExport(string path)
        {
            TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8);

            textWriter.WriteLine("FUNCTION {0}", this.Function);

            for (int i = 0; i < this.ActivationNetwork.LayersCount; ++i)
            {
                textWriter.WriteLine("LAYER {0} {1}", i, this.ActivationNetwork[i].NeuronsCount);

                for (int j = 0; j < this.ActivationNetwork[i].NeuronsCount; ++j)
                {
                    textWriter.WriteLine(" NEURON {0} {1} {2}", i, this.ActivationNetwork[i].InputsCount, this.ActivationNetwork[i][j].Threshold);

                    for (int k = 0; k < this.ActivationNetwork[i][j].InputsCount; ++k)
                    {
                        textWriter.WriteLine("  WEIGHT {0} {1}", i, this.ActivationNetwork[i][j][k]);
                    }
                }
            }

            textWriter.Close();
        }
        #endregion

    }
}
