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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Data;
using System.IO;

using Sinapse.Data;
using Sinapse.Data.Reporting;


namespace Sinapse.Data.Network
{

    [Serializable]
    internal sealed class NetworkWorkplace
    {

        private List<WorkplaceEntry> m_entryList;

        [NonSerialized]
        internal FileSystemEventHandler WorkplaceSaved;

        [NonSerialized]
        private string m_lastSavePath;

        //----------------------------------------


        #region Constructor
        internal NetworkWorkplace()
        {
            this.m_entryList = new List<WorkplaceEntry>();
        }
        #endregion


        //----------------------------------------


        #region Object Events
        private void OnWorkplaceSaved(FileSystemEventArgs e)
        {
            if (this.WorkplaceSaved != null)
                this.WorkplaceSaved.Invoke(this, e);
        }
        #endregion


        //----------------------------------------


        #region Static Methods
        public static void Serialize(NetworkWorkplace networkWorkplace, string path)
        {
            FileStream fileStream = null;
            bool success = true;

            try
            {
                fileStream = new FileStream(path, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, networkWorkplace);
            }
            catch (DirectoryNotFoundException e)
            {
                Debug.WriteLine("Directory not found during workplace serialization");
                success = false;
                throw e;
            }
            catch (SerializationException e)
            {
                Debug.WriteLine("Error occured during workplace serialization");
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
                    networkWorkplace.m_lastSavePath = path;
            }
        }

        public static NetworkWorkplace Deserialize(string path)
        {
            NetworkWorkplace nwp = null;
            FileStream fileStream = null;
            bool success = true;

            try
            {
                fileStream = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                nwp = (NetworkWorkplace)bf.Deserialize(fileStream);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("File not found during workplace deserialization");
                success = false;
                throw e;
            }
            catch (SerializationException e)
            {
                Debug.WriteLine("Error occured during workplace deserialization");
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
                    nwp.m_lastSavePath = path;
                    nwp.OnWorkplaceSaved(new FileSystemEventArgs(WatcherChangeTypes.Created, Path.GetDirectoryName(path), Path.GetFileName(path)));
                }
            }

            return nwp;
        }

        #endregion


    }

    [Serializable]
    internal sealed class WorkplaceEntry
    {

        private NetworkContainer m_networkContainer;
        private NetworkPerformance m_networkPerformance;
        private NetworkDatabase m_networkDatabase;
        
        public WorkplaceEntry(NetworkContainer networkContainer, NetworkDatabase networkDatabase, NetworkPerformance networkPerformance)
        {
            this.m_networkContainer = networkContainer;
            this.m_networkDatabase = networkDatabase;
            this.m_networkPerformance = networkPerformance;
        }
    }

}
