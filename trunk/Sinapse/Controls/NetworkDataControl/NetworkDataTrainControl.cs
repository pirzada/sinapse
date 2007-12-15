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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Controls
{
    sealed internal partial class NetworkDataTrainControl : Sinapse.Controls.NetworkDataControl
    {

        #region Constant Definitions
        private readonly Color testingColor = SystemColors.Control;
        private readonly Color validationColor = Color.Gainsboro;
        private readonly string validationTag  = "Validation";       
        #endregion

        //---------------------------------------------


        #region Constructor
        public NetworkDataTrainControl()
        {
            InitializeComponent();

            this.panelValidationCaption.BackColor = validationColor;
            this.dataGridView.ContextMenuStrip = this.contextMenu;
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


        //---------------------------------------------


        #region Private Methods
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
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            shuffleTable(this.m_networkData.DataTable, this.m_networkData.DataTable.Rows.Count * 3);
            ((DataTable)this.dataGridView.DataSource).DefaultView.Sort = String.Empty;
        }


        private void MenuValidationAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                row.Tag = validationTag;
                row.DefaultCellStyle.BackColor = validationColor;
            }
        }

        private void MenuValidationRem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                row.Tag = String.Empty;
                row.DefaultCellStyle.BackColor = testingColor;
            }
        }
        #endregion
    }
}

