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

using Dotnetrix.Controls;
using Sinapse.Data.Network;
using Sinapse.Data.CsvParser;
                         

namespace Sinapse.Controls.MainTabControl.Base
{
    internal partial class TabPageDataControlBase : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkContainer m_networkContainer;
        private NetworkDatabase m_networkDatabase;
        
        private NetworkSet m_networkSet;


        public EventHandler DataSelectionChanged;

       
        //----------------------------------------


        #region Constructor
        protected TabPageDataControlBase()
        {
            InitializeComponent();

         
              this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer,
        //      ControlStyles.ResizeRedraw,
              true);
          
        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkContainer NetworkContainer
        {
            get { return this.m_networkContainer; }
            set
            {
                this.m_networkContainer = value;
                this.OnCurrentNetworkChanged();
            }
        }

        internal NetworkDatabase NetworkDatabase
        {
            get { return this.m_networkDatabase; }
            set
            {
                this.m_networkDatabase = value;
                this.OnCurrentDatabaseChanged();
            }
        }

        internal int ItemCount
        {
            get { return this.BindingSource.Count; }
        }

        internal int SelectedItemCount
        {
            get { return this.dataGridView.SelectedRows.Count; }
        }
        #endregion


        //----------------------------------------


        #region Virtual Methods
        protected virtual void OnDataImported(DataTable table)
        {
            this.NetworkDatabase.ImportData(table, GetNetworkSet(), 0);
        }

        protected virtual void OnCurrentDatabaseChanged()
        {
            if (this.NetworkDatabase != null)
            {
                DataView dv = new DataView(this.NetworkDatabase.DataTable);
                dv.RowFilter = this.GetFilterString();

                this.BindingSource.DataSource = dv;
            }
            else
            {
                this.BindingSource.DataSource = null;
            }

            this.setColumns();

            this.UpdateTitle();

        }

        protected virtual void OnCurrentNetworkChanged()
        {
            
        }

        protected virtual void OnRowValidating(DataRowView row)
        {
            row.Row[NetworkDatabase.ColumnRoleId] = (ushort)m_networkSet;
        }

        protected virtual void OnSelectionChanged()
        {
            if (this.DataSelectionChanged != null)
                this.DataSelectionChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected NetworkSet GetNetworkSet()
        {
            return this.m_networkSet;
        }

        protected string GetFilterString()
        {
            return String.Format("{0}='{1}'", NetworkDatabase.ColumnRoleId, (ushort)this.m_networkSet);
        }

        protected void SetUp(NetworkSet networkSet, string displayName)
        {
            this.m_networkSet = networkSet;
            this.TabPageName = displayName;
            this.lbSetTitle.Text = displayName;
            this.UpdateTitle();

            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = this.BindingSource;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
            this.dataGridView.Rows.CollectionChanged += new CollectionChangeEventHandler(dataGridView_CollectionChanged);

        }

        protected override void UpdateTitle()
        {
            if (this.getTabPage() != null)
                this.getTabPage().Text = String.Format("{0} [{1}]", this.TabPageName, ItemCount);
        }

        protected DataGridViewColumn CreateColumn(string columnName, string propertyName, Color color)
        {
            DataGridViewColumn column;

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = propertyName;
            column.HeaderText = columnName;
            column.DefaultCellStyle.Format = "G5";
            column.DefaultCellStyle.BackColor = color;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            return column;
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            this.UpdateTitle();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void copySelections(NetworkSet networkSet)
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                this.copyCurrent(this.dataGridView.CurrentRow, networkSet);
            }
            else
            {
                foreach (DataGridViewRow viewRow in this.dataGridView.SelectedRows)
                {
                    this.copyCurrent(viewRow, networkSet);
                }
            }

            this.BindingSource.ResetBindings(false);
        }


        private void copyCurrent(DataGridViewRow viewRow, NetworkSet networkSet)
        {
            DataRow row = (viewRow.DataBoundItem as DataRowView).Row;
            
            if (row != null)
            {
                DataRow newRow = row.Table.NewRow();
                foreach (DataColumn col in row.Table.Columns)
                {
                    newRow[col] = row[col];
                }

                newRow[NetworkDatabase.ColumnRoleId] = (ushort)networkSet;
                row.Table.Rows.Add(newRow);
            }
        }

        private void moveSelections(NetworkSet networkSet, int trainingLayer)
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                this.moveCurrent(this.dataGridView.CurrentRow, networkSet, trainingLayer);
            }
            else
            {
                foreach (DataGridViewRow viewRow in this.dataGridView.SelectedRows)
                {
                    this.moveCurrent(viewRow, networkSet, trainingLayer);
                }
            }

            this.BindingSource.ResetBindings(false);
        }

        private void moveCurrent(DataGridViewRow viewRow, NetworkSet networkSet, int trainingLayer)
        {
            DataRow row = (viewRow.DataBoundItem as DataRowView).Row;
            if (row != null)
            {
                row[NetworkDatabase.ColumnRoleId] = networkSet;
                row[NetworkDatabase.ColumnTrainingLayerId] = trainingLayer;
            }
        }

        private void setColumns()
        {
            this.dataGridView.Columns.Clear();

            if (this.NetworkDatabase == null)
                return;

            DataGridViewColumn column;

            foreach (String colName in this.NetworkDatabase.Schema.InputColumns)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.DefaultCellStyle.BackColor = panelInputCaption.BackColor;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.NetworkDatabase.Schema.OutputColumns)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.DefaultCellStyle.BackColor = panelOutputCaption.BackColor;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.NetworkDatabase.Schema.StringColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].HeaderText = dataGridView.Columns[colName].DataPropertyName + " [C]";
            }

#if SHOW_HIDDEN_COLUMNS
            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnRoleId;
            column.HeaderText = NetworkDatabase.ColumnRoleId;
            column.CellTemplate = new DataGridViewTextBoxCell();
            this.dataGridView.Columns.Add(column);

            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnTrainingLayerId;
            column.HeaderText = NetworkDatabase.ColumnTrainingLayerId;
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


        #region DataGridView Menu Move
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

            this.MenuTraining.DropDownItems.Clear();
            this.MenuTraining.DropDownItems.AddRange(items);

        }

        private void layerMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item.Tag is int)
            {
                this.moveSelections(NetworkSet.Training, (int)item.Tag);
            }
        }

        private void MenuTraining_Click(object sender, EventArgs e)
        {
            this.moveSelections(NetworkSet.Training, 1);
        }

        private void MenuValidation_Click(object sender, EventArgs e)
        {
            this.moveSelections(NetworkSet.Validation, 0);
        }

        private void MenuTesting_Click(object sender, EventArgs e)
        {
            this.moveSelections(NetworkSet.Testing, 0);
        }
        #endregion


        //----------------------------------------


        #region DataGridView Menu Copy
        private void MenuCopyTraining_Click(object sender, EventArgs e)
        {
            this.copySelections(NetworkSet.Training);
        }

        private void MenuCopyValidation_Click(object sender, EventArgs e)
        {
            this.copySelections(NetworkSet.Validation);
        }

        private void MenuCopyTesting_Click(object sender, EventArgs e)
        {
            this.copySelections(NetworkSet.Testing);
        }

        private void MenuCopyQuery_Click(object sender, EventArgs e)
        {
            this.copySelections(NetworkSet.Query);
        }

        private void MenuCopyClipboard_Click(object sender, EventArgs e)
        {
            this.dataGridView.CopyToClipboard();
        }

        private void MenuPaste_Click(object sender, EventArgs e)
        {
            this.dataGridView.PasteFromClipboard();
        }
        #endregion


        //----------------------------------------


        #region DataGridView Events
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged();
        }

        private void dataGridView_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            this.UpdateTitle();
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataRowView row = this.dataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (row != null)
                    this.OnRowValidating(row);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
#if DEBUG

#endif
            }
        }

        #endregion


    }
}
