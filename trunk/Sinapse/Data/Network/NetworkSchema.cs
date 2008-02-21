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
using System.Data;

using AForge.Neuro;
using AForge;


namespace Sinapse.Data.Network
{
    [Serializable]
    internal sealed class NetworkSchema
    {

        private NetworkCaptions dataCategories;
        private NetworkRanges dataRanges;

        private string[] inputColumns;
        private string[] outputColumns;
        private string[] stringColumns;
        
        
        // --------------------------------------


        #region Constructor
        public NetworkSchema(string[] inputColumns, string[] outputColumns, string[] stringColumns)
        {
            this.inputColumns = inputColumns;
            this.outputColumns = outputColumns;
            this.stringColumns = stringColumns;

            this.dataCategories = new NetworkCaptions(this.stringColumns);
            this.dataRanges = new NetworkRanges(this.AllColumns, this.stringColumns);

        }
        #endregion


        // --------------------------------------


        #region Properties
        public string[] InputColumns
        {
            get { return this.inputColumns; }
        }

        public string[] OutputColumns
        {
            get { return this.outputColumns; }
        }

        public string[] StringColumns
        {
            get { return this.stringColumns; }
        }

        public string[] AllColumns
        {
            get
            {
                string[] columns = new string[inputColumns.Length + outputColumns.Length];
                inputColumns.CopyTo(columns, 0);
                outputColumns.CopyTo(columns, inputColumns.Length);
                return columns;
            }
        }

        public NetworkRanges DataRanges
        {
            get { return this.dataRanges; }
        }

        public NetworkCaptions DataCategories
        {
            get { return dataCategories; }
        }

        #endregion


        // --------------------------------------


        #region Public Methods
        internal bool IsCategory(string columnName)
        {
            return Array.IndexOf(this.StringColumns, columnName) == -1;
        }
        #endregion

    }
}
