using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Sources;
using Sinapse.Forms.Dialogs;

using Sinapse.Windows.Editors.DataSources;

namespace Sinapse.Windows.Documents
{
    [DocumentViewer(typeof(TableDataSource))]
    internal partial class TableSourceView : SinapseDocumentView
    {

        private TableEditor wndTableEditor;
        private ColumnSpecification wndColumnSpecification;



        public TableSourceView(Workbench workbench, ISinapseDocument document)
            : base(workbench, document)
        {
            InitializeComponent();

        }

/*
        public TableDataSource TableSource
        {
            get { return tableSource; }
            protected set
            {
                tableSource = value;
                
                if (value != null)
                {
                    tableSource.Changed += tableSource_Changed;
                    tableSource.DataChanged += tableSource_Changed;
                    tableSource.FileSaved += tableSource_Changed;
                    updateCaption();
                }
            }
        }
        */



        #region Form Events
        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.wndColumnSpecification = new ColumnSpecification();
         //   this.wndColumnSpecification.TableSource = this.tableSource;
            this.wndColumnSpecification.Show(this.dockPanel, DockState.Document);

         //   this.wndSourceOverview = new SourceOverview();
         //   this.wndSourceOverview.DataSource = tableSource;
         //   this.wndSourceOverview.Show(this.dockPanel, DockState.Document);

            this.wndTableEditor = new TableEditor();
        //    this.wndTableEditor.TableSource = tableSource;
            this.wndTableEditor.Show(this.dockPanel, DockState.Document);
            this.ResumeLayout(true);
            
        }


        #endregion



   



        private void btnOverview_Click(object sender, EventArgs e)
        {

        }

        private void btnTable_Click(object sender, EventArgs e)
        {

        }

        private void btnColumns_Click(object sender, EventArgs e)
        {

        }

        private void btnNotes_Click(object sender, EventArgs e)
        {

        }



    }
}
