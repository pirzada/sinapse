/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
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

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Databases.Csv;


namespace Sinapse.WinForms.Dialogs
{

    internal sealed partial class ImportWizard : Form
    {

        private DataTable dataTable;
        private TableDataSourceColumnCollection columns;

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
        public DataTable GetTable()
        {
            return dataTable;
        }

        public TableDataSourceColumnCollection GetColumns()
        {
            return this.columns;
        }
        #endregion


        //---------------------------------------------


        #region Wizard Events
        private void wizardControl_NextButtonClick(WizardControl sender, WizardNextButtonClickEventArgs e)
        {
            switch (wizardControl.CurrentStepIndex)
            {
                case 0:
                    dataTable = null;
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
            this.dataTable = null;
            this.Close();
        }


        private void wizardControl_FinishButtonClick(object sender, EventArgs e)
        {
            columns = new TableDataSourceColumnCollection(dataTable);
            TableDataSourceColumn col = null;

            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                col = new TableDataSourceColumn(dataColumn);
              //  col.Role = InputOutput.None;
                col.Visible = false;
                col.DataType = SystemDataType.Nummeric;
                columns.Add(col);
            }

            foreach (string strColumn in clbInput.CheckedItems)
            {
                col = columns[strColumn];
             //   col.Role = InputOutput.Input;
                col.Visible = true;
            }

            foreach (string strColumn in clbOutput.CheckedItems)
            {
                col = columns[strColumn];
           //     col.Role = InputOutput.Output;
                col.Visible = true;
            }

            foreach (string strColumn in clbString.CheckedItems)
            {
                columns[strColumn].DataType = SystemDataType.Category;
            }

 
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
                this.dataTable = CsvParser.Parse(tbDatapath.Text, Encoding.Default, true, (CsvDelimiter)cbDelimiter.SelectedValue);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "Error opening file. Please ensure no other process is using that file and try again.");
#if DEBUG
                throw;
#else
                return false;
#endif
            }
            return true;
        }

        private void loadInputCombobox()
        {
            clbInput.Items.Clear();
            //         clbString.Items.Clear();
            foreach (DataColumn col in dataTable.Columns)
            {
                clbInput.Items.Add(col.ColumnName, false);
                //           clbString.Items.Add(col.ColumnName, false);
            }
        }

        private void loadOutputCombobox()
        {
            clbOutput.Items.Clear();
            foreach (DataColumn col in dataTable.Columns)
            {
                if (!clbInput.CheckedItems.Contains(col.ColumnName))
                    clbOutput.Items.Add(col.ColumnName, false);
            }
        }

        private void loadStringCombobox()
        {
            clbString.Items.Clear();
            foreach (DataColumn col in dataTable.Columns)
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
            openFileDialog.ShowDialog(this);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            tbDatapath.Text = openFileDialog.FileName;
            this.autoDetectFieldDelimiter(tbDatapath.Text);
        }

        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            if (tbDatapath.Text.Length > 0 && File.Exists(tbDatapath.Text))
            {
                this.autoDetectFieldDelimiter(tbDatapath.Text);
            }
            else
            {
                MessageBox.Show("Invalid path specified");
            }
        }
        #endregion


        //---------------------------------------------



        #region Private Methods
        private void autoDetectFieldDelimiter(string path)
        {
            cbDelimiter.SelectedItem = CsvUtils.DetectFieldDelimiterChar(tbDatapath.Text, Encoding.Default);
        }
        #endregion

    }
}