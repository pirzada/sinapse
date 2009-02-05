using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core.Sources;

using Sinapse.WinForms.ToolWindows;

namespace Sinapse.WinForms.Forms.Documents.Sources.ToolWindows
{
    public partial class EditColumns : Form
    {
        private TableDataSourceColumnCollection columns;


        public EditColumns()
        {
            InitializeComponent();
        }

        public EditColumns(TableDataSourceColumnCollection columns) : this()
        {
            this.columns = columns;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dataGridView1.DataSource = columns;
        }


    }
}
