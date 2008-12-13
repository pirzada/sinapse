using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Sources;
using Sinapse.Forms.Dialogs;

namespace Sinapse.Windows.Documents
{
    public partial class TableDataSourceEditor : DockContent, IWorkplaceDocument
    {

        private TableDataSource tableSource;
        private DataSourceSet currentSet;


        public TableDataSourceEditor(TableDataSource source)
        {
            tableSource = source;

            InitializeComponent();

            tableSource.Changed += new EventHandler(tableSource_Changed);
        }



        #region Table Data Source Events
        private void tableSource_Changed(object sender, EventArgs e)
        {
            updateName();
        }
        #endregion




        #region Form Events
        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            updateName();
            updateDataBindings();
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
                tableSource.Import(import);
            }
        }
        #endregion




        #region GUI Update
        private void updateName()
        {
            this.Text = String.Format("{0} - Data Source Editor", this.tableSource.Name);
        }

        private void updateDataBindings()
        {
            if (this.tableSource != null)
            {
                this.dgvTable.DataSource = this.tableSource.GetView(currentSet);
                this.dgvColumns.DataSource = this.tableSource.Columns;
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
        #endregion





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




        #region IDocument Members

        public void Save()
        {
            if (tableSource.FullPath == String.Empty)
                SaveAs();
            else tableSource.Save();
        }

        public void SaveAs()
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
            //    saveFileDialog.DefaultExt = tableSource.DefaultExtension;
                tableSource.Save(saveFileDialog.FileName);
            }
        }

        public ToolStripMenuItem[] MenuItems
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public ToolStrip[] ToolStrips
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion


        private void btnTrainingSet_Click(object sender, EventArgs e)
        {
            currentSet = DataSourceSet.Training;
            updateDataBindings();
        }

        private void btnValidationSet_Click(object sender, EventArgs e)
        {
            currentSet = DataSourceSet.Validation;
            updateDataBindings();
        }

        private void btnTestingSet_Click(object sender, EventArgs e)
        {
            currentSet = DataSourceSet.Testing;
            updateDataBindings();
        }





    }
}
