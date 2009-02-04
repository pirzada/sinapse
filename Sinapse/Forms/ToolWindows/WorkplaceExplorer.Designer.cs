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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.documentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuProperties = new System.Windows.Forms.ToolStripMenuItem();
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
            this.folderContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.workplaceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.documentContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.folderContextMenu.SuspendLayout();
            this.workplaceContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewWorkplace
            // 
            this.treeViewWorkplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewWorkplace.ImageIndex = 0;
            this.treeViewWorkplace.ImageList = this.imageList;
            this.treeViewWorkplace.LabelEdit = true;
            this.treeViewWorkplace.Location = new System.Drawing.Point(0, 25);
            this.treeViewWorkplace.Name = "treeViewWorkplace";
            this.treeViewWorkplace.SelectedImageIndex = 0;
            this.treeViewWorkplace.ShowRootLines = false;
            this.treeViewWorkplace.Size = new System.Drawing.Size(221, 357);
            this.treeViewWorkplace.TabIndex = 0;
            this.treeViewWorkplace.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewWorkplace_NodeMouseDoubleClick);
            this.treeViewWorkplace.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewWorkplace_AfterLabelEdit);
            this.treeViewWorkplace.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewWorkplace_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // documentContextMenu
            // 
            this.documentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuOpen,
            this.ContextMenuSeparator1,
            this.ContextMenuCut,
            this.ContextMenuCopy,
            this.ContextMenuPaste,
            this.ContextMenuDelete,
            this.ContextMenuRename,
            this.ContextMenuSeparator3,
            this.ContextMenuProperties});
            this.documentContextMenu.Name = "contextMenuStrip1";
            this.documentContextMenu.Size = new System.Drawing.Size(135, 170);
            // 
            // ContextMenuOpen
            // 
            this.ContextMenuOpen.Name = "ContextMenuOpen";
            this.ContextMenuOpen.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuOpen.Text = "Open";
            // 
            // ContextMenuSeparator1
            // 
            this.ContextMenuSeparator1.Name = "ContextMenuSeparator1";
            this.ContextMenuSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // ContextMenuCut
            // 
            this.ContextMenuCut.Image = global::Sinapse.WinForms.Properties.Resources.editcut;
            this.ContextMenuCut.Name = "ContextMenuCut";
            this.ContextMenuCut.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuCut.Text = "Cut";
            this.ContextMenuCut.Click += new System.EventHandler(this.ContextMenuCut_Click);
            // 
            // ContextMenuCopy
            // 
            this.ContextMenuCopy.Image = global::Sinapse.WinForms.Properties.Resources.edit_copy;
            this.ContextMenuCopy.Name = "ContextMenuCopy";
            this.ContextMenuCopy.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuCopy.Text = "Copy";
            this.ContextMenuCopy.Click += new System.EventHandler(this.ContextMenuCopy_Click);
            // 
            // ContextMenuPaste
            // 
            this.ContextMenuPaste.Image = global::Sinapse.WinForms.Properties.Resources.edit_paste;
            this.ContextMenuPaste.Name = "ContextMenuPaste";
            this.ContextMenuPaste.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuPaste.Text = "Paste";
            this.ContextMenuPaste.Click += new System.EventHandler(this.ContextMenuPaste_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Image = global::Sinapse.WinForms.Properties.Resources.editdelete;
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuDelete.Text = "Delete";
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // ContextMenuRename
            // 
            this.ContextMenuRename.Name = "ContextMenuRename";
            this.ContextMenuRename.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuRename.Text = "Rename";
            this.ContextMenuRename.Click += new System.EventHandler(this.ContextMenuRename_Click);
            // 
            // ContextMenuSeparator3
            // 
            this.ContextMenuSeparator3.Name = "ContextMenuSeparator3";
            this.ContextMenuSeparator3.Size = new System.Drawing.Size(131, 6);
            // 
            // ContextMenuProperties
            // 
            this.ContextMenuProperties.Image = global::Sinapse.WinForms.Properties.Resources.view_text;
            this.ContextMenuProperties.Name = "ContextMenuProperties";
            this.ContextMenuProperties.Size = new System.Drawing.Size(134, 22);
            this.ContextMenuProperties.Text = "Properties";
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
            // folderContextMenu
            // 
            this.folderContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator4,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripSeparator5,
            this.toolStripMenuItem13,
            this.toolStripSeparator6,
            this.toolStripMenuItem14});
            this.folderContextMenu.Name = "contextMenuStrip1";
            this.folderContextMenu.Size = new System.Drawing.Size(245, 198);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem1.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem2.Text = "New Item...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem3.Text = "New Folder";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem4.Text = "Adaptive System...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem5.Text = "Data Source...";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem6.Text = "Training Session...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::Sinapse.WinForms.Properties.Resources.editcut;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem8.Text = "Cut";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::Sinapse.WinForms.Properties.Resources.edit_copy;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem9.Text = "Copy";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::Sinapse.WinForms.Properties.Resources.edit_paste;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem10.Text = "Paste";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.ContextMenuPaste_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::Sinapse.WinForms.Properties.Resources.editdelete;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem11.Text = "Delete";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem12.Text = "Rename";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.ContextMenuRename_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem13.Text = "Open Folder in Windows Explorer";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = global::Sinapse.WinForms.Properties.Resources.view_text;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem14.Text = "Properties";
            // 
            // workplaceContextMenu
            // 
            this.workplaceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripSeparator8,
            this.toolStripMenuItem24,
            this.toolStripSeparator9,
            this.toolStripMenuItem25,
            this.toolStripSeparator10,
            this.toolStripMenuItem26});
            this.workplaceContextMenu.Name = "contextMenuStrip1";
            this.workplaceContextMenu.Size = new System.Drawing.Size(245, 132);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripSeparator7,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem7.Text = "Add";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem15.Text = "New Item...";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem16.Text = "New Folder";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem17.Text = "Adaptive System...";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem18.Text = "Data Source...";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem19.Text = "Training Session...";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem24.Text = "Rename";
            this.toolStripMenuItem24.Click += new System.EventHandler(this.ContextMenuRename_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem25.Text = "Open Folder in Windows Explorer";
            this.toolStripMenuItem25.Click += new System.EventHandler(this.ContextMenuOpenExplorer_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Image = global::Sinapse.WinForms.Properties.Resources.view_text;
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem26.Text = "Properties";
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
            this.documentContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.folderContextMenu.ResumeLayout(false);
            this.workplaceContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip documentContextMenu;
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
        private System.Windows.Forms.ToolStripSeparator ContextMenuSeparator3;
        private System.Windows.Forms.ContextMenuStrip folderContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ContextMenuStrip workplaceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem26;
    }
}
