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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WizardBase;

using Sinapse.Data.Network;
using Sinapse.Data.CsvParser;


namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class ImportWizard : Form
    {

        private DataTable m_dataTable;
        private NetworkSchema m_networkSchema;

        //---------------------------------------------


        #region Constructor
        public ImportWizard()
        {
            InitializeComponent();
            cbDelimiter.DataSource = Enum.GetValues(typeof(CsvDelimiter));
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal NetworkDatabase GetNetworkData()
        {
            return new NetworkDatabase(m_networkSchema, m_dataTable);
        }

        internal DataTable GetDataTable()
        {
            return m_dataTable;
        }

        internal NetworkSchema GetSchema()
        {
            return m_networkSchema;
        }
        #endregion


        //---------------------------------------------


        #region Wizard Events
        private void wizardControl_NextButtonClick(WizardControl sender, WizardNextButtonClickEventArgs e)
        {
            switch (wizardControl.CurrentStepIndex)
            {
                case 0:
                    m_dataTable = null;
                    break;

                case 1:
                    if (File.Exists(tbDatapath.Text) && loadDataTable())
                    {
                        loadInputCombobox();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;

                case 2:
                    loadOutputCombobox();
                    break;

                case 3:
                    loadStringCombobox();
                    break;

                default:
                    break;
            }
        }


        private void wizardControl_CancelButtonClick(object sender, EventArgs e)
        {
            this.m_dataTable = null;
            this.Close();
        }


        private void wizardControl_FinishButtonClick(object sender, EventArgs e)
        {

            List<String> inputColumns = new List<String>();
            foreach (string strColumn in clbInput.CheckedItems)
                inputColumns.Add(strColumn);

            List<String> outputColumns = new List<String>();
            foreach (string strColumn in clbOutput.CheckedItems)
                outputColumns.Add(strColumn);

            List<String> stringColumns = new List<String>();
            foreach (string strColumn in clbString.CheckedItems)
                stringColumns.Add(strColumn);


            //Remove unusable columns
            List<DataColumn> removeCols = new List<DataColumn>();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                if (!inputColumns.Contains(col.ColumnName) &&
                    !outputColumns.Contains(col.ColumnName))
                    removeCols.Add(col);
            }

            foreach(DataColumn col in removeCols)
                m_dataTable.Columns.Remove(col);
            

            //Create Network Schema
            this.m_networkSchema = new NetworkSchema(
                inputColumns.ToArray(),
                outputColumns.ToArray(),
                stringColumns.ToArray());
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion


        //---------------------------------------------


        #region Load Controls
        private bool loadDataTable()
        {
            try
            {
                this.m_dataTable = CsvParser.Parse(tbDatapath.Text, Encoding.Default, true, (CsvDelimiter)cbDelimiter.SelectedValue);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Error opening file. Please ensure no other process is using that file and try again.");
                return false;
            }
            return true;
        }

        private void loadInputCombobox()
        {
            clbInput.Items.Clear();
   //         clbString.Items.Clear();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                clbInput.Items.Add(col.ColumnName, false);
     //           clbString.Items.Add(col.ColumnName, false);
            }
        }

        private void loadOutputCombobox()
        {
            clbOutput.Items.Clear();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                if (!clbInput.CheckedItems.Contains(col.ColumnName))
                    clbOutput.Items.Add(col.ColumnName, false);
            }
        }

        private void loadStringCombobox()
        {
            clbString.Items.Clear();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                if (clbInput.CheckedItems.Contains(col.ColumnName) ||
                    clbOutput.CheckedItems.Contains(col.ColumnName))
                {
                    clbString.Items.Add(col.ColumnName, false);
                }
            }
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tbDatapath.Text = openFileDialog.FileName;
        }

        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            if (tbDatapath.Text.Length > 0 && File.Exists(tbDatapath.Text))
            {
                cbDelimiter.SelectedItem = CsvUtils.DetectFieldDelimiterChar(tbDatapath.Text, Encoding.Default);
            }
            else
            {
                MessageBox.Show("Invalid path specified");
            }
        }
        #endregion


    }
}