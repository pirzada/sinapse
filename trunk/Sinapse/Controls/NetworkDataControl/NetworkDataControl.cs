using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Dialogs;

namespace Sinapse.Controls
{
    internal partial class NetworkDataControl : UserControl
    {

        #region Colors Definition
        private readonly Color inputColor = Color.Honeydew;
        private readonly Color outputColor = Color.AliceBlue;
        #endregion

        protected NetworkData m_networkData;

        public EventHandler OnSelectionChanged;
        public EventHandler OnSchemaChanged;
        public EventHandler OnDataChanged;


        //----------------------------------------

        #region Constructor
        public NetworkDataControl()
        {
            this.InitializeComponent();
            this.panelInputCaption.BackColor = inputColor;
            this.panelOutputCaption.BackColor = outputColor;
           
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
                    this.m_networkData = value;

                    if (this.m_networkData != null)
                    {
                        this.Enabled = true;
                        this.dataGridView.DataSource = this.m_networkData.DataTable;
                        this.setHeaderColors();
                    }
                    else
                    {
                        this.Enabled = false;
                        this.dataGridView.DataSource = null;
                    }

                    if (this.OnSchemaChanged != null)
                        this.OnSchemaChanged.Invoke(this, EventArgs.Empty);

                    if (this.OnDataChanged != null)
                        this.OnDataChanged.Invoke(this, EventArgs.Empty);
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

        //----------------------------------------

        #region Public Methods
        public void GetNetworkData(out double[][] input, out double[][] output)
        {
            this.m_networkData.CreateVectors(out input, out output);
        }
        #endregion

        //----------------------------------------

        #region Control Events
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
                        row++;
                    }
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OnSelectionChanged != null)
                OnSelectionChanged.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (OnDataChanged != null)
                OnDataChanged.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (OnDataChanged != null)
                OnDataChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion

        //----------------------------------------

        #region Private Methods
        private void setHeaderColors()
        {
            foreach (String colName in this.m_networkData.NetworkSchema.InputColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].DefaultCellStyle.BackColor = inputColor;
            }

            foreach (String colName in this.m_networkData.NetworkSchema.OutputColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].DefaultCellStyle.BackColor = outputColor;
            }

            foreach (String colName in this.m_networkData.NetworkSchema.StringColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].HeaderText = dataGridView.Columns[colName].DataPropertyName + " [C]";
            }
        }
        #endregion

    }
}
