using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Data.CsvParser;

namespace Sinapse.Controls.TrainingTabs
{
    public partial class TrainingTabBase : UserControl
    {

        private NetworkData m_networkData;

        //----------------------------------------


        #region Constructor
        public TrainingTabBase()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkData NetworkData
        {
            get
            {
                return this.m_networkData;
            }
            set
            {
                if (this.m_networkData != value)
                {
                    this.dataGridView.SuspendLayout();

                    this.m_networkData = value;

                    if (this.m_networkData != null)
                    {
                        this.Enabled = true;
                        this.setColumns();
                        this.dataGridView.DataSource = this.m_networkData.DataTable;
                    }
                    else
                    {
                        this.Enabled = false;
                        this.dataGridView.Columns.Clear();
                        this.dataGridView.DataSource = null;
                    }


                    this.dataGridView.ResumeLayout();

                }
            }
        }

        internal NetworkSchema Schema
        {
            get { return m_networkData.NetworkSchema; }
        }

        internal int ItemCount
        {
            get { return this.m_networkData.DataTable.Rows.Count; }
        }
        #endregion



        #region Control Events
        /// <summary>
        /// Provides paste support for the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGridView_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
      //      if (OnSelectionChanged != null)
      //          OnSelectionChanged.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
     //       if (OnDataChanged != null)
     //           OnDataChanged.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
     //       if (OnDataChanged != null)
     //           OnDataChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void setColumns()
        {
            DataGridViewColumn column;

            foreach (String colName in this.m_networkData.NetworkSchema.InputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelInputCaption.BackColor;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.m_networkData.NetworkSchema.OutputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelOutputCaption.BackColor;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.m_networkData.NetworkSchema.StringColumns)
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
            /*CsvFileParserOptions options = new CsvFileParserOptions(openFileDialog.FileName);
            options.AutoDetectCsvDelimiter = true;
            options.HeadersAction = HeadersAction.UseAsColumnNames;*/

            try
            {
                //DataTable table = CsvParser.Parse(options);
                DataTable table = CsvParser.Parse(openFileDialog.FileName, Encoding.Default, true, CsvDelimiter.Tabulation);

                /*
                                foreach (DataRow row in table.Rows)
                                {
                                    DataRow newRow = this.m_networkData.DataTable.NewRow();
                                    foreach (DataColumn col in table.Columns)
                                    {
                                        if (newRow.Table.Columns.Contains(col.ColumnName))
                                        {
                                            newRow[col.ColumnName] = row[col.ColumnName];
                                        }
                                    }
                                    //newRow.EndEdit();
                                    this.m_networkData.DataTable.Rows.Add(newRow);
                                }
                                */

                //  this.m_networkData.DataTable.Clear();
                this.m_networkData.DataTable.Merge(table, false, MissingSchemaAction.Ignore);
            }
            catch
            {
                MessageBox.Show("Error opening file");
            }
        }
        #endregion
    }
}
