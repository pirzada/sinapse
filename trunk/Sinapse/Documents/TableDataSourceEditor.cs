using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Sources;

namespace Sinapse.Documents
{
    public partial class TableDataSourceEditor : DockContent
    {

        private TableDataSource tableSource;


        public TableDataSourceEditor(TableDataSource source)
        {
            InitializeComponent();

            this.tableSource = source;
        }


        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            if (tableSource != null)
            {
         //       this.dgvViewer.DataSource = this.tableSource.CreateDataView(NetworkDataSet.All);
         //       this.dgvColumns.DataSource = this.tableSource.Columns;
            }
        }

    }
}
