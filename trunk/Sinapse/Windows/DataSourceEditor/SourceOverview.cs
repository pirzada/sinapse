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
using Sinapse.Forms.Dialogs;


namespace Sinapse.Windows.DataSourceEditor
{
    public partial class SourceOverview : DockContent
    {

        private IDataSource dataSource;


        public SourceOverview()
        {
            InitializeComponent();
        }

        public IDataSource DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                if (value != null)
                {
                    dataSource.Changed += new EventHandler(tableSource_Changed);
                }
            }
        }

        void tableSource_Changed(object sender, EventArgs e)
        {
            tbName.Text = dataSource.Name;
            tbDescription.Text = dataSource.Description;
            tbRemarks.Text = dataSource.Remarks;
        }


    }
}