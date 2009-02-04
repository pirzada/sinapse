namespace Sinapse.WinForms.ToolWindows
{
    partial class WorkplaceExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeViewWorkplace = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuAddNewSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNewSource = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewAll = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnViewDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.lbNothingToShow = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewWorkplace
            // 
            this.treeViewWorkplace.ContextMenuStrip = this.contextMenu;
            this.treeViewWorkplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewWorkplace.ImageIndex = 0;
            this.treeViewWorkplace.ImageList = this.imageList;
            this.treeViewWorkplace.Location = new System.Drawing.Point(0, 25);
            this.treeViewWorkplace.Name = "treeViewWorkplace";
            this.treeViewWorkplace.SelectedImageIndex = 0;
            this.treeViewWorkplace.ShowRootLines = false;
            this.treeViewWorkplace.Size = new System.Drawing.Size(221, 357);
            this.treeViewWorkplace.TabIndex = 0;
            this.treeViewWorkplace.DoubleClick += new System.EventHandler(this.treeViewWorkplace_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuAdd,
            this.ContextMenuOpen,
            this.ContextMenuSeparator1,
            this.ContextMenuCut,
            this.ContextMenuCopy,
            this.ContextMenuPaste,
            this.ContextMenuDelete,
            this.ContextMenuRename,
            this.ContextMenuSeparator2,
            this.ContextMenuOpenExplorer,
            this.ContextMenuSeparator3,
            this.ContextMenuProperties});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(245, 220);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // ContextMenuAdd
            // 
            this.ContextMenuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddNewItem,
            this.MenuAddNewFolder,
            this.toolStripSeparator7,
            this.MenuAddNewSystem,
            this.MenuAddNewSource,
            this.MenuAddNewSession});
            this.ContextMenuAdd.Name = "ContextMenuAdd";
            this.ContextMenuAdd.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuAdd.Text = "Add";
            // 
            // MenuAddNewItem
            // 
            this.MenuAddNewItem.Name = "MenuAddNewItem";
            this.MenuAddNewItem.Size = new System.Drawing.Size(178, 22);
            this.MenuAddNewItem.Text = "New Item...";
            // 
            // MenuAddNewFolder
            // 
            this.MenuAddNewFolder.Name = "MenuAddNewFolder";
            this.MenuAddNewFolder.Size = new System.Drawing.Size(178, 22);
            this.MenuAddNewFolder.Text = "New Folder";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // MenuAddNewSystem
            // 
            this.MenuAddNewSystem.Name = "MenuAddNewSystem";
            this.MenuAddNewSystem.Size = new System.Drawing.Size(178, 22);
            this.MenuAddNewSystem.Text = "Adaptive System...";
            // 
            // MenuAddNewSource
            // 
            this.MenuAddNewSource.Name = "MenuAddNewSource";
            this.MenuAddNewSource.Size = new System.Drawing.Size(178, 22);
            this.MenuAddNewSource.Text = "Data Source...";
            // 
            // MenuAddNewSession
            // 
            this.MenuAddNewSession.Name = "MenuAddNewSession";
            this.MenuAddNewSession.Size = new System.Drawing.Size(178, 22);
            this.MenuAddNewSession.Text = "Training Session...";
            // 
            // ContextMenuOpen
            // 
            this.ContextMenuOpen.Name = "ContextMenuOpen";
            this.ContextMenuOpen.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuOpen.Text = "Open";
            // 
            // ContextMenuSeparator1
            // 
            this.ContextMenuSeparator1.Name = "ContextMenuSeparator1";
            this.ContextMenuSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // ContextMenuCut
            // 
            this.ContextMenuCut.Image = global::Sinapse.WinForms.Properties.Resources.editcut;
            this.ContextMenuCut.Name = "ContextMenuCut";
            this.ContextMenuCut.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuCut.Text = "Cut";
            // 
            // ContextMenuCopy
            // 
            this.ContextMenuCopy.Image = global::Sinapse.WinForms.Properties.Resources.edit_copy;
            this.ContextMenuCopy.Name = "ContextMenuCopy";
            this.ContextMenuCopy.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuCopy.Text = "Copy";
            // 
            // ContextMenuPaste
            // 
            this.ContextMenuPaste.Image = global::Sinapse.WinForms.Properties.Resources.edit_paste;
            this.ContextMenuPaste.Name = "ContextMenuPaste";
            this.ContextMenuPaste.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuPaste.Text = "Paste";
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Image = global::Sinapse.WinForms.Properties.Resources.editdelete;
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuDelete.Text = "Delete";
            // 
            // ContextMenuRename
            // 
            this.ContextMenuRename.Name = "ContextMenuRename";
            this.ContextMenuRename.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuRename.Text = "Rename";
            // 
            // ContextMenuSeparator2
            // 
            this.ContextMenuSeparator2.Name = "ContextMenuSeparator2";
            this.ContextMenuSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // ContextMenuOpenExplorer
            // 
            this.ContextMenuOpenExplorer.Name = "ContextMenuOpenExplorer";
            this.ContextMenuOpenExplorer.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuOpenExplorer.Text = "Open Folder in Windows Explorer";
            // 
            // ContextMenuSeparator3
            // 
            this.ContextMenuSeparator3.Name = "ContextMenuSeparator3";
            this.ContextMenuSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // ContextMenuProperties
            // 
            this.ContextMenuProperties.Image = global::Sinapse.WinForms.Properties.Resources.view_text;
            this.ContextMenuProperties.Name = "ContextMenuProperties";
            this.ContextMenuProperties.Size = new System.Drawing.Size(244, 22);
            this.ContextMenuProperties.Text = "Properties";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.btnViewAll,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(221, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Sinapse.WinForms.Properties.Resources.documentinfo;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Properties";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewAll
            // 
            this.btnViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewAll.Image = global::Sinapse.WinForms.Properties.Resources.view_tree;
            this.btnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(23, 22);
            this.btnViewAll.Text = "View All";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::Sinapse.WinForms.Properties.Resources.reload;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewDirectory,
            this.btnViewCategory});
            this.toolStripDropDownButton1.Image = global::Sinapse.WinForms.Properties.Resources.view_choose;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // btnViewDirectory
            // 
            this.btnViewDirectory.Name = "btnViewDirectory";
            this.btnViewDirectory.Size = new System.Drawing.Size(155, 22);
            this.btnViewDirectory.Text = "Directory View";
            // 
            // btnViewCategory
            // 
            this.btnViewCategory.Name = "btnViewCategory";
            this.btnViewCategory.Size = new System.Drawing.Size(155, 22);
            this.btnViewCategory.Text = "Category View";
            // 
            // lbNothingToShow
            // 
            this.lbNothingToShow.BackColor = System.Drawing.SystemColors.Window;
            this.lbNothingToShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNothingToShow.Location = new System.Drawing.Point(0, 25);
            this.lbNothingToShow.Name = "lbNothingToShow";
            this.lbNothingToShow.Size = new System.Drawing.Size(221, 357);
            this.lbNothingToShow.TabIndex = 2;
            this.lbNothingToShow.Text = "No Workplace loaded. Please click the \'New\' menu and select \'Workplace\' to begin." +
                "";
            this.lbNothingToShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkplaceExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 382);
            this.Controls.Add(this.lbNothingToShow);
            this.Controls.Add(this.treeViewWorkplace);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorkplaceExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "Workplace";
            this.Text = "Workplace Explorer";
            this.contextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewWorkplace;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lbNothingToShow;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripButton btnViewAll;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnViewDirectory;
        private System.Windows.Forms.ToolStripMenuItem btnViewCategory;
        private System.Windows.Forms.ToolStripSeparator ContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCut;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuPaste;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRename;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuProperties;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNewItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNewSystem;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNewSource;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNewSession;
        private System.Windows.Forms.ToolStripSeparator ContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuOpenExplorer;
        private System.Windows.Forms.ToolStripSeparator ContextMenuSeparator3;
    }
}
