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
using Sinapse.Data.CsvParser;

namespace Sinapse.Controls.NetworkDataTab
{
    internal partial class TabPageBase : UserControl
    {

        private NetworkDataTabControl m_parentControl;
        private NetworkSet m_networkSet;

        //----------------------------------------


        #region Constructor
        protected TabPageBase()
        {
            InitializeComponent();
        }

        protected TabPageBase(NetworkDataTabControl parentControl)
        {
            this.m_parentControl = parentControl;
            this.m_parentControl.DatabaseLoaded += new EventHandler(parentControl_DatabaseLoaded);

            InitializeComponent();
        }
        #endregion



        //----------------------------------------


        #region Properties
        internal int ItemCount
        {
            get { return this.dataGridView.Rows.Count; }
        }

        internal int SelectedItemCount
        {
            get { return this.dataGridView.SelectedRows.Count; }
        }
        internal NetworkDataTabControl ParentControl
        {
            get { return this.m_parentControl; }
        }
        #endregion


        //----------------------------------------


        #region Virtual Methods
        protected virtual void OnDataImported(DataTable table)
        {
            this.m_parentControl.NetworkData.ImportData(table, GetNetworkSet(), 0);
        }

        protected virtual void OnDatabaseLoaded()
        {
            if (this.m_parentControl.NetworkData != null)
            {
                DataView dv = new DataView(this.m_parentControl.NetworkData.DataTable);
                dv.RowFilter = this.getFilterString();
                this.BindingSource.DataSource = dv;
                this.setColumns();
            }
        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        internal protected NetworkSet GetNetworkSet()
        {
            return this.m_networkSet;
        }

        protected void SetUp(NetworkSet networkSet)
        {
            this.m_networkSet = networkSet;
        }
        #endregion


        //----------------------------------------


        #region Control Events
        private void TabPageBase_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.dataGridView.AutoGenerateColumns = false;
                this.dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
                this.dataGridView.DataSource = this.BindingSource;
            }
        }

        private void parentControl_DatabaseLoaded(object sender, EventArgs e)
        {
            this.OnDatabaseLoaded();
        }



        #endregion


        //----------------------------------------


        #region Private Methods
        private string getFilterString()
        {
            return String.Format("{0}='{1}'", NetworkDatabase.ColumnRoleId, (ushort)this.m_networkSet);
        }

        private void setSelections(NetworkSet networkSet, int trainingLayer)
        {
            foreach (DataGridViewRow viewRow in this.dataGridView.SelectedRows)
            {
                DataRow row = (viewRow.DataBoundItem as DataRowView).Row;
                row[NetworkDatabase.ColumnRoleId] = networkSet;
                row[NetworkDatabase.ColumnTrainingLayerId] = trainingLayer;
            }
        }

        private void setColumns()
        {

            DataGridViewColumn column;

            foreach (String colName in this.m_parentControl.NetworkData.Schema.InputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelInputCaption.BackColor;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.m_parentControl.NetworkData.Schema.OutputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelOutputCaption.BackColor;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.m_parentControl.NetworkData.Schema.StringColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].HeaderText = dataGridView.Columns[colName].DataPropertyName + " [C]";
            }

#if DEBUG
            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnRoleId;
            column.HeaderText = "@Role";
            column.CellTemplate = new DataGridViewTextBoxCell();
            this.dataGridView.Columns.Add(column);

            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnTrainingLayerId;
            column.HeaderText = "@Training Set";
            column.CellTemplate = new DataGridViewTextBoxCell();
            this.dataGridView.Columns.Add(column);
#endif
        }
        #endregion


        //----------------------------------------


        #region Data Import
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.OnDataImported(CsvParser.Parse(openFileDialog.FileName, Encoding.Default, true, CsvDelimiter.Tabulation));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file");
                throw ex;
            }

        }
        #endregion


        //----------------------------------------


        #region DataGridView Menus
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

            DataRowView drv = (BindingSource.Current as DataRowView);

            if (drv == null)
                return;

            this.MenuTesting.Checked = false;
            this.MenuTraining.Checked = false;
            this.MenuValidation.Checked = false;

            
                if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Testing)
                    this.MenuTesting.Checked = true;
                else if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Training)
                    this.MenuTraining.Checked = true;
                else if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Validation)
                    this.MenuValidation.Checked = true;
            

            //Populate Training Menu
            ToolStripMenuItem[] items = new ToolStripMenuItem[5];
            int layerNumber;

            for (int i = 0; i < items.Length; ++i)
            {
                layerNumber = (UInt16)(i + 1);
                items[i] = new ToolStripMenuItem();
                items[i].Checked = drv.Row[NetworkDatabase.ColumnTrainingLayerId].Equals(layerNumber);
                items[i].Text = layerNumber.ToString();
                items[i].Tag = layerNumber;
                items[i].Click += new EventHandler(layerMenuItem_Click);
            }

            this.MenuTraining.DropDownItems.AddRange(items);

        }

        private void layerMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item.Tag is int)
            {
                this.setSelections(NetworkSet.Training, (int)item.Tag);
            }
        }

        private void MenuTraining_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Training, 1);
        }

        private void MenuValidation_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Validation, 0);
        }

        private void MenuTesting_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Testing, 0);
        }
        #endregion


        #region DataGridView Events
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.ParentControl.SelectionChanged != null)
                this.ParentControl.SelectionChanged.Invoke(sender, e);
        }

        /// <summary>
        /// Provides paste support for the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dataGridView.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = dataGridView.CurrentCell.RowIndex;
                int col = dataGridView.CurrentCell.ColumnIndex;

                foreach (string line in lines)
                {

                    if (row < dataGridView.RowCount && line.Length > 0)
                    {
                        string[] cells = line.Split('\t');

                        for (int i = 0; i < cells.GetLength(0); i++)
                        {
                            if (col + i < this.dataGridView.ColumnCount)
                            {
                                dataGridView[col + i, row].Value = Convert.ChangeType(cells[i], dataGridView[col + i, row].ValueType);
                            }
                        }
                        ++row;
                    }
                }
            }
        }
        #endregion


    }
}
