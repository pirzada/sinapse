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
        //    this.tableSource.NameChanged += new EventHandler(tableSource_NameChanged);

            this.updateName();
        }

        private void tableSource_NameChanged(object sender, EventArgs e)
        {
            this.updateName();
        }

        private void updateName()
        {
            this.Text = String.Format("{0} - Data Source Editor", this.tableSource.Name);
        }


        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            if (this.tableSource != null)
            {
                this.dgvViewer.DataSource = this.tableSource.GetData(DataSource.Set.Training);
                this.dgvColumns.DataSource = this.tableSource.Columns;
            }
        }

    }
}
