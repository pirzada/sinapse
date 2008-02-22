/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

using AForge.Neuro;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkContainer
    {

        private NetworkSchema m_networkSchema;
        private ActivationNetwork m_activationNetwork;
        private string m_networkName;
        private string m_networkDescription;
        private double m_networkPrecision;
        private DateTime m_creationTime;

        private NetworkSavepointCollection m_savepointCollection;

        [NonSerialized]
        private string m_lastSavePath;

        [NonSerialized]
        internal EventHandler NetworkChanged;

   /*     [NonSerialized]
        internal EventHandler NetworkLoaded;
   */    
        [NonSerialized]
        internal FileSystemEventHandler NetworkSaved;      


        //---------------------------------------------


        #region Constructor
        public NetworkContainer(string networkName, NetworkSchema schema, IActivationFunction function, params int[] hiddenLayersNeuronCount)
        {
            this.m_networkSchema = schema;
            this.m_networkName = networkName;

            int[] neuronsCount = new int[hiddenLayersNeuronCount.Length + 2];
            neuronsCount[0] = schema.InputColumns.Length;
            neuronsCount[hiddenLayersNeuronCount.Length + 1] = schema.OutputColumns.Length;
            hiddenLayersNeuronCount.CopyTo(neuronsCount, 1); 

            this.m_activationNetwork = new ActivationNetwork(function, schema.InputColumns.Length, neuronsCount);

            this.m_creationTime = DateTime.Now;
            this.m_lastSavePath = String.Empty;
            
            this.m_savepointCollection = new NetworkSavepointCollection(this);
            this.m_savepointCollection.SavepointRestored += savepointCollection_SavepointRestored;

        }

        public NetworkContainer(NetworkSchema schema, IActivationFunction function, params int[] hiddenLayersNeuronCount)
            : this(String.Empty, schema, function, hiddenLayersNeuronCount)
        {
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal ActivationNetwork ActivationNetwork
        {
            get { return this.m_activationNetwork; }
        }

        internal NetworkSchema Schema
        {
            get { return this.m_networkSchema; }
        }

        internal NetworkSavepointCollection Savepoints
        {
            get { return this.m_savepointCollection; }
        }

        internal string Name
        {
            get { return this.m_networkName; }
            set
            {
                this.m_networkName = value;
                this.OnNetworkChanged();
            }
        }

        internal string Description
        {
            get { return m_networkDescription; }
            set
            {
                this.m_networkDescription = value;
                this.OnNetworkChanged();
            }
        }

        internal double Precision
        {
            get { return m_networkPrecision; }
            set
            {
                this.m_networkPrecision = value;
                this.OnNetworkChanged();
            }
        }

        internal string LastSavePath
        {
            get { return m_lastSavePath; }
        }

        internal bool IsSaved
        {
            get { return (m_lastSavePath != null && m_lastSavePath.Length > 0); }
        }

        internal DateTime CreationTime
        {
            get { return m_creationTime; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal string GetLayoutString()
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
        #endregion


        //---------------------------------------------


        #region Object Events
        private void OnNetworkSaved(FileSystemEventArgs e)
        {
            if (this.NetworkSaved != null)
                this.NetworkSaved.Invoke(this, e);
        }

   /*     private void OnNetworkLoaded()
        {
            if (this.NetworkLoaded != null)
                this.NetworkLoaded.Invoke(this, EventArgs.Empty);
        }
   */
        private void OnNetworkChanged()
        {
            if (this.NetworkChanged != null)
                this.NetworkChanged.Invoke(this, EventArgs.Empty);
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


        #region Static Methods
        public static void Serialize(NetworkContainer network, string path)
        {
            FileStream fileStream = null;
            bool success = true;

            try
            {
                fileStream = new FileStream(path, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, network);
            }
            catch (DirectoryNotFoundException e)
            {
                Debug.WriteLine("Directory not found during network serialization");
                success = false;
                throw e;
            }
            catch (SerializationException e)
            {
                Debug.WriteLine("Error occured during serialization");
                success = false;
                throw e;
            }
            catch (Exception e)
            {
                success = false;
                throw e;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();

                if (success)
                {
                    network.m_lastSavePath = path;
                    network.OnNetworkSaved(new FileSystemEventArgs(WatcherChangeTypes.Created, Path.GetDirectoryName(path), Path.GetFileName(path)));
                }
            }
        }

        public static NetworkContainer Deserialize(string path)
        {

            NetworkContainer nn = null;
            FileStream fileStream = null;
            bool success = true;

            try
            {
                fileStream = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                nn = (NetworkContainer)bf.Deserialize(fileStream);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("File not found during network deserialization");
                success = false;
                throw e;
            }
            catch (SerializationException e)
            {
                Debug.WriteLine("Error occured during deserialization");
                success = false;
                throw e;
            }
            catch (Exception e)
            {
                success = false;
                throw e;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();

                if (success)
                    nn.m_lastSavePath = path;
            }

            return nn;
        }
        #endregion


    }
}
