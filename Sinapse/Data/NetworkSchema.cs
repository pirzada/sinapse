using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using AForge.Neuro;
using AForge;

namespace Sinapse.Data
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

    }
}
