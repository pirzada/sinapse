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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Forms.Dialogs;

namespace Sinapse.Controls.NetworkDataTab
{

    internal sealed partial class TabPageTesting : TabPageBase
    {

        //----------------------------------------


        #region Constructor
        public TabPageTesting()
        {
            InitializeComponent();
            SetUp(NetworkSet.Testing, "Testing Set");
        }
        #endregion


        //----------------------------------------


        #region Properties
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnCurrentDatabaseChanged()
        {
            base.OnCurrentDatabaseChanged();

            this.Enabled = (this.NetworkDatabase != null);

            if (this.NetworkDatabase != null)
            {
                DataGridViewColumn column;

                foreach (String colName in this.NetworkDatabase.Schema.OutputColumns)
                {
                    column = new DataGridViewColumn();
                    column.DataPropertyName = NetworkDatabase.ColumnComputedPrefix + colName;
                    column.HeaderText = "Network: " + colName;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.DefaultCellStyle.BackColor = SystemColors.Window;
                    this.dataGridView.Columns.Add(column);
                }
            }
        }

        protected override void OnCurrentNetworkChanged()
        {
            base.OnCurrentNetworkChanged();

            btnCompare.Enabled = (this.NetworkContainer != null);
            btnQuery.Enabled = (this.NetworkContainer != null);
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.ComputeTable(this.NetworkContainer, true);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            new PerformanceDialog(this.NetworkContainer, this.NetworkDatabase.DataTable).ShowDialog(this);
        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.Round(true);
        }
        #endregion



        //----------------------------------------


        #region Private Methods



        #endregion


    }
}
