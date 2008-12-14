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
    public partial class TableDataSourceDocument : DockContent, IWorkplaceDocument
    {

        private WorkplaceItem item;
        private TableDataSource tableSource;

        private TableEditor wndTableEditor;
        private SourceOverview wndSourceOverview;
        private ColumnSpecification wndColumnSpecification;
        


        public TableDataSourceDocument(TableDataSource source)
        {
            InitializeComponent();

            this.TableSource = source;
        }


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


        #region Table Data Source Events
        private void tableSource_Changed(object sender, EventArgs e)
        {
            updateCaption();
        }
        #endregion




        #region Form Events
        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.wndColumnSpecification = new ColumnSpecification();
            this.wndColumnSpecification.TableSource = this.tableSource;
            this.wndColumnSpecification.Show(this.dockPanel, DockState.Document);

            this.wndSourceOverview = new SourceOverview();
            this.wndSourceOverview.DataSource = tableSource;
            this.wndSourceOverview.Show(this.dockPanel, DockState.Document);

            this.wndTableEditor = new TableEditor();
            this.wndTableEditor.TableSource = tableSource;
            this.wndTableEditor.Show(this.dockPanel, DockState.Document);
            this.ResumeLayout(true);
            
        }


        #endregion




        #region GUI Update
        private void updateCaption()
        {
            this.Name = this.tableSource.Name;
            this.Text = this.tableSource.Name;

            this.TabText = this.tableSource.Name;

            if (tableSource.HasChanges)
                this.TabText = this.Name + "*";
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

        public WorkplaceItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public bool HasChanges
        {
            get { return tableSource.HasChanges; }
        }

        #endregion
    }
}
