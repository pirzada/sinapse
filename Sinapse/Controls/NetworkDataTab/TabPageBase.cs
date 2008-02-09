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
        internal virtual NetworkSet GetNetworkSet()
        {
            if (!this.DesignMode)
                throw new Exception("Method \"GetNetworkSet()\" should be properly implemented");
            else return NetworkSet.Training;
        }

        protected virtual void OnDataImported(DataTable table)
        {
            this.m_parentControl.NetworkData.ImportData(table, GetNetworkSet(), 0);
        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected string getFilterStrBase()
        {
            return NetworkDatabase.ColumnRoleId + " = " + (ushort)this.GetNetworkSet();
        }
        #endregion


        //----------------------------------------


        #region Control Events
        private void TabPageBase_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.BindingSource.Filter = getFilterStrBase();

                this.dataGridView.AutoGenerateColumns = false;
                this.dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
                this.dataGridView.DataSource = this.BindingSource;
            }
        }

        private void parentControl_DatabaseLoaded(object sender, EventArgs e)
        {
            this.BindingSource.DataSource = this.m_parentControl.NetworkData;
        }

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


        //----------------------------------------


        #region Private Methods
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


    }
}
