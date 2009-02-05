using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;


using Sinapse.Core;
using Sinapse.Core.Documents;
using Sinapse.Core.Sources;

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

        private DataSourceSet currentSet
        {
            get { return (DataSourceSet)this.cbDataSet.ComboBox.SelectedValue; }
        }
        


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.cbDataSet.ComboBox.DataSource = Enum.GetNames(typeof(DataSourceSet));
            this.dataGridView1.DataSource = TableDataSource.GetView(currentSet);
        }






    }
}
