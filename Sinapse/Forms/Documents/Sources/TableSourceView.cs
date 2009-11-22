using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;


using Sinapse.Core;
using Sinapse.Core.Documents;
using Sinapse.Core.Sources;
using Sinapse.Databases;

using Sinapse.WinForms.Dialogs;

//using Sinapse.WinForms.Editors.DataSources;

using Sinapse.WinForms.Core;

namespace Sinapse.WinForms.Documents
{
    [DocumentViewer(".source.tds")]
    internal partial class TableSourceView : SinapseDocumentView
    {
        public TableSourceView(Workbench workbench, ISinapseDocument document)
            : base(workbench, document)
        {
            InitializeComponent();

        }


        TableDataSource TableDataSource
        {
            get { return this.Document as TableDataSource; }
        }

        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.cbDataSet.ComboBox.DataSource = Enum.GetNames(typeof(DataSourceSet));
            this.dataGridView1.DataSource = TableDataSource.GetView(DataSourceSet.None);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string extension = Path.GetExtension(filename);
                if (extension == ".xls" || extension == ".xlsx")
                {
                    Excel db = new Excel(filename, true, false);
                    TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

                    if (t.ShowDialog(this) == DialogResult.OK)
                    {
                        this.TableDataSource.Import(db.GetWorksheet(t.Selection));
                    }
                }
                else if (extension == ".xml")
                {
                    DataTable dataTableAnalysisSource = new DataTable();
                    dataTableAnalysisSource.ReadXml(openFileDialog.FileName);

                    this.TableDataSource.Import(dataTableAnalysisSource);
                }
            }
        }






    }
}
