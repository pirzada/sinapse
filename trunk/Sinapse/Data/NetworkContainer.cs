/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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

namespace Sinapse.Data
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

        [NonSerialized]
        private string m_lastSavePath;

        [NonSerialized]
        internal EventHandler OnNetworkChanged;

        [NonSerialized]
        internal EventHandler OnSavePathChanged;


        //---------------------------------------------


        #region Constructor & Destructor
        public NetworkContainer(string networkName, NetworkSchema schema, IActivationFunction function, int hiddenLayer)
        {
            this.m_networkSchema = schema;
            this.m_networkName = networkName;
            this.m_activationNetwork = new ActivationNetwork(function, schema.InputColumns.Length, schema.InputColumns.Length, hiddenLayer, schema.OutputColumns.Length);

            this.m_creationTime = DateTime.Now;
            this.LastSavePath = String.Empty;
        }

        public NetworkContainer(NetworkSchema schema, IActivationFunction function, int hiddenLayer)
            : this(String.Empty, schema, function, hiddenLayer)
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

        internal string Name
        {
            get { return this.m_networkName; }
            set
            {
                this.m_networkName = value;

                if (this.OnNetworkChanged != null)
                    this.OnNetworkChanged.Invoke(this, EventArgs.Empty);
            }
        }

        internal string Description
        {
            get { return m_networkDescription; }
            set
            {
                this.m_networkDescription = value;

                if (this.OnNetworkChanged != null)
                    this.OnNetworkChanged.Invoke(this, EventArgs.Empty);
            }
        }

        internal double Precision
        {
            get { return m_networkPrecision; }
            set
            {
                this.m_networkPrecision = value;

                if (this.OnNetworkChanged != null)
                    this.OnNetworkChanged.Invoke(this, EventArgs.Empty);
            }
        }

        internal string LastSavePath
        {
            get { return m_lastSavePath; }
            set
            {
                this.m_lastSavePath = value;

                if (this.OnSavePathChanged != null)
                    this.OnSavePathChanged.Invoke(this, EventArgs.Empty);
            }
        }

        internal DateTime CreationTime
        {
            get { return m_creationTime; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public string GetLayoutString()
        {
            string layout = String.Empty;

            for (int i = 0; i < this.m_activationNetwork.LayersCount; i++)
            {
                layout += this.m_activationNetwork[i].NeuronsCount;

                if (i < this.m_activationNetwork.LayersCount - 1)
                    layout += "-";
            }

            return layout;
        }
        #endregion


        //---------------------------------------------


        #region Static Methods
        public static void Serialize(NetworkContainer network, string path)
        {
            FileStream fs = null;
            bool success = true;

            try
            {
                fs = new FileStream(path, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, network);
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
                if (fs != null)
                    fs.Close();

                if (success)
                    network.LastSavePath = path;
            }
        }

        public static NetworkContainer Deserialize(string path)
        {

            NetworkContainer nn = null;
            FileStream fs = null;
            bool success = true;

            try
            {
                fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                nn = (NetworkContainer)bf.Deserialize(fs);
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
                if (fs != null)
                    fs.Close();

                if (success)
                    nn.LastSavePath = path;
            }

            return nn;
        }
        #endregion

    }
}
