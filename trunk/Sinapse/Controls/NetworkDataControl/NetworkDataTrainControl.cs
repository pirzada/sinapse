using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Controls
{
    sealed internal partial class NetworkDataTrainControl : Sinapse.Controls.NetworkDataControl
    {
        #region Color Definitions
        private readonly Color validationColor = Color.Gainsboro;
        private readonly Color testingColor = SystemColors.Control;
        #endregion

        //---------------------------------------------

        #region Constructor
        public NetworkDataTrainControl()
        {
            InitializeComponent();

            this.panelValidationCaption.BackColor = validationColor;
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal int ValidationItemCount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        internal int TrainingItemCount
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        internal int SelectedItemCount
        {
            get { return this.dataGridView.SelectedRows.Count; }
        }
        #endregion

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            shuffleTable(this.m_networkData.DataTable,this.m_networkData.DataTable.Rows.Count*3);
            ((DataTable)this.dataGridView.DataSource).DefaultView.Sort = String.Empty;
        }

        /// <summary>
        /// Randomizes the order of the rows in a DataTable by pulling out a single row and moving it to the end for
        /// shuffleIterations iterations.
        /// </summary>
        /// <param name="inputTable"></param>
        /// <param name="shuffleIterations"></param>
        /// <returns></returns>
        public void shuffleTable(DataTable inputTable, int shuffleIterations)
        {
            int index;
            System.Random rnd = new Random();

            // Remove and throw to the end random rows until we have done so n*3 times (shuffles the dataset)
            for (int i = 0; i < shuffleIterations; i++)
            {
                index = rnd.Next(0, inputTable.Rows.Count - 1);
                inputTable.Rows.Add(inputTable.Rows[index].ItemArray);
                inputTable.Rows.RemoveAt(index);
            }
        }

    }
}

