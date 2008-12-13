using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;
using Sinapse.Core.Sources;

namespace Sinapse.Forms.Dialogs
{
    public partial class NewDataSourceDialog : Form
    {
/*
        IDataSource dataSource;
        Type dataSourceType;
*/

        public NewDataSourceDialog()
        {
            InitializeComponent();
        }


/*
        public IDataSource DataSource
        {
            get { return dataSource; }
        }

        public Type DataSourceType
        {
            get { return dataSource; }
        }
*/


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("Invalid filename");
                return;
            }
            if (!System.IO.Path.HasExtension(tbName.Text))
            {
                MessageBox.Show("Extension missing");
                return;
            }

            TableDataSource tds = new TableDataSource(tbName.Text);
            string path = System.IO.Path.Combine(Workplace.Active.FilePath, tbName.Text);
            tds.Save(path);
            Workplace.Active.DataSources.Add(tbName.Text, typeof(TableDataSource));

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}