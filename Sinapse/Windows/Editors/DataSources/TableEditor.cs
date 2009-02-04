using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Sources;
using Sinapse.WinForms.Dialogs;


namespace Sinapse.WinForms.Editors.DataSources
{
    public partial class TableEditor : DockContent
    {

        private TableDataSource tableSource;
        private DataSourceSet currentSet = DataSourceSet.Training;



        public TableEditor()
        {
            InitializeComponent();
        }



        public TableDataSource TableSource
        {
            get { return tableSource; }
            set
            {
                tableSource = value;
                if (tableSource != null)
                {
                    tableSource.Changed += new EventHandler(tableSource_Changed);
                    tableSource.Columns.ListChanged += new ListChangedEventHandler(Columns_ListChanged);
                }
                updateBinding();
                updateColumns();
            }
        }





        public DataSourceSet Set
        {
            get { return currentSet; }
            set
            {
                currentSet = value;
                updateBinding();

                btnTrainingSet.Checked = false;
                btnValidationSet.Checked = false;
                btnTestingSet.Checked = false;

                switch (value)
                {
                    case DataSourceSet.Training:
                        btnTrainingSet.Checked = true;
                        break;
                    case DataSourceSet.Validation:
                        btnValidationSet.Checked = true;
                        break;
                    case DataSourceSet.Testing:
                        btnTestingSet.Checked = true;
                        break;
                }
            }
        }





        void tableSource_Changed(object sender, EventArgs e)
        {
          //
        }

        void Columns_ListChanged(object sender, ListChangedEventArgs e)
        {
            this.updateColumns();
        }





        private void updateBinding()
        {
            if (tableSource != null)
            {
                dgvTable.DataSource = tableSource.GetView(currentSet);
            }
        }

        private void updateColumns()
        {
            foreach (DataGridViewColumn viewColumn in dgvTable.Columns)
            {
                TableDataSourceColumn col = tableSource.Columns[viewColumn.Name];

                if (col.Role == DataSourceRole.Input)
                    viewColumn.DefaultCellStyle.BackColor = inputCaption.Color;
                else if (col.Role == DataSourceRole.Output)
                    viewColumn.DefaultCellStyle.BackColor = outputCaption.Color;

                viewColumn.Visible = col.Visible;
            }
        }

        private void btnWizard_Click(object sender, EventArgs e)
        {
            ImportWizard wizard = new ImportWizard();
            if (wizard.ShowDialog(this) == DialogResult.OK)
            {
                tableSource.Import(wizard.GetTable(), wizard.GetColumns());
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (importDialog.ShowDialog(this) == DialogResult.OK)
            {
                DataTable import = Sinapse.Databases.Csv.
                    CsvParser.Parse(importDialog.FileName, Encoding.Default,
                    true, Sinapse.Databases.Csv.CsvDelimiter.Tabulation);
                tableSource.Import(import, currentSet);
            }
        }


        private void btnTrainingSet_Click(object sender, EventArgs e)
        {
            this.Set = DataSourceSet.Training;
        }

        private void btnValidationSet_Click(object sender, EventArgs e)
        {
            this.Set = DataSourceSet.Validation;
        }

        private void btnTestingSet_Click(object sender, EventArgs e)
        {
            this.Set = DataSourceSet.Testing;
        }



        #region Copy & Move Operations
        private void copySelection(DataSourceSet set)
        {
            // If none is selected, we copy only the current
            if (dgvTable.SelectedRows.Count == 0)
            {
                copySelection(dgvTable.CurrentRow, set);
            }
            else
            {
                // Otherwise we copy all the selected rows.
                foreach (DataGridViewRow viewRow in dgvTable.SelectedRows)
                {
                    copySelection(viewRow, set);
                }
            }

            //this.BindingSource.ResetBindings(false);
        }

        private void copySelection(DataGridViewRow viewRow, DataSourceSet set)
        {
            DataRow row = (viewRow.DataBoundItem as DataRowView).Row;

            if (row != null)
                tableSource.CopyRowToSet(row, set);
        }

        private void moveSelection(DataSourceSet set, int subset)
        {
            // If none is selected, we move only the current
            if (dgvTable.SelectedRows.Count == 0)
            {
                moveSelection(dgvTable.CurrentRow, set, subset);
            }
            else
            {
                foreach (DataGridViewRow viewRow in dgvTable.SelectedRows)
                {
                    moveSelection(viewRow, set, subset);
                }
            }

            //        this.BindingSource.ResetBindings(false);
        }

        private void moveSelection(DataGridViewRow viewRow, DataSourceSet set, int subset)
        {
            DataRow row = (viewRow.DataBoundItem as DataRowView).Row;
            if (row != null)
                tableSource.MoveRowToSubset(row, set, subset);
        }
        #endregion


    }
}