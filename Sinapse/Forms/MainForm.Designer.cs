namespace Sinapse.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNetworkName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNeuronCount = new System.Windows.Forms.Label();
            this.lbInputCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRowCount = new System.Windows.Forms.Label();
            this.lbOutputCount = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lbStatusEpoch = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.networkRangesControl = new Sinapse.Controls.NetworkRangesControl();
            this.networkCreatorControl = new Sinapse.Controls.NetworkCreatorControl();
            this.networkTrainerControl = new Sinapse.Controls.NetworkTrainerControl();
            this.networkDataControl = new Sinapse.Controls.NetworkDataTrainControl();
            this.networkDisplayControl = new Sinapse.Controls.NetworkDisplayControl();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.lbNetworkName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbNeuronCount);
            this.panel1.Controls.Add(this.lbInputCount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbRowCount);
            this.panel1.Controls.Add(this.lbOutputCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 52);
            this.panel1.TabIndex = 5;
            // 
            // lbNetworkName
            // 
            this.lbNetworkName.AutoSize = true;
            this.lbNetworkName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNetworkName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNetworkName.ForeColor = System.Drawing.SystemColors.Window;
            this.lbNetworkName.Location = new System.Drawing.Point(12, 4);
            this.lbNetworkName.Name = "lbNetworkName";
            this.lbNetworkName.Size = new System.Drawing.Size(479, 25);
            this.lbNetworkName.TabIndex = 0;
            this.lbNetworkName.Text = "Neural Networks: A General Implementation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Location = new System.Drawing.Point(42, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Training data";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(718, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neurons:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(829, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Inputs:";
            // 
            // lbNeuronCount
            // 
            this.lbNeuronCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNeuronCount.AutoSize = true;
            this.lbNeuronCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbNeuronCount.Location = new System.Drawing.Point(782, 31);
            this.lbNeuronCount.Name = "lbNeuronCount";
            this.lbNeuronCount.Size = new System.Drawing.Size(19, 13);
            this.lbNeuronCount.TabIndex = 0;
            this.lbNeuronCount.Text = "00";
            // 
            // lbInputCount
            // 
            this.lbInputCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInputCount.AutoSize = true;
            this.lbInputCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbInputCount.Location = new System.Drawing.Point(877, 31);
            this.lbInputCount.Name = "lbInputCount";
            this.lbInputCount.Size = new System.Drawing.Size(19, 13);
            this.lbInputCount.TabIndex = 0;
            this.lbInputCount.Text = "00";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Location = new System.Drawing.Point(924, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Outputs:";
            // 
            // lbRowCount
            // 
            this.lbRowCount.AutoSize = true;
            this.lbRowCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbRowCount.Location = new System.Drawing.Point(118, 31);
            this.lbRowCount.Name = "lbRowCount";
            this.lbRowCount.Size = new System.Drawing.Size(52, 13);
            this.lbRowCount.TabIndex = 0;
            this.lbRowCount.Text = "(00 items)";
            // 
            // lbOutputCount
            // 
            this.lbOutputCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutputCount.AutoSize = true;
            this.lbOutputCount.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbOutputCount.Location = new System.Drawing.Point(981, 31);
            this.lbOutputCount.Name = "lbOutputCount";
            this.lbOutputCount.Size = new System.Drawing.Size(19, 13);
            this.lbOutputCount.TabIndex = 0;
            this.lbOutputCount.Text = "00";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.progressBar,
            this.lbStatusEpoch,
            this.lbStatusError,
            this.lbItems});
            this.statusStrip.Location = new System.Drawing.Point(0, 644);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(250, 17);
            this.lbStatus.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lbStatusEpoch
            // 
            this.lbStatusEpoch.Name = "lbStatusEpoch";
            this.lbStatusEpoch.Size = new System.Drawing.Size(109, 17);
            this.lbStatusEpoch.Spring = true;
            // 
            // lbStatusError
            // 
            this.lbStatusError.Name = "lbStatusError";
            this.lbStatusError.Size = new System.Drawing.Size(109, 17);
            this.lbStatusError.Spring = true;
            // 
            // lbItems
            // 
            this.lbItems.AutoSize = false;
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(80, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuNetwork,
            this.MenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 52);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileNew,
            this.MenuFileOpen,
            this.toolStripSeparator,
            this.MenuFileSave,
            this.MenuFileSaveAs,
            this.toolStripSeparator2,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(35, 20);
            this.MenuFile.Text = "&File";
            // 
            // MenuFileNew
            // 
            this.MenuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileNew.Image")));
            this.MenuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileNew.Name = "MenuFileNew";
            this.MenuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuFileNew.Size = new System.Drawing.Size(151, 22);
            this.MenuFileNew.Text = "&New";
            this.MenuFileNew.Click += new System.EventHandler(this.MenuFileNew_Click);
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileOpen.Image")));
            this.MenuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileOpen.Name = "MenuFileOpen";
            this.MenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuFileOpen.Size = new System.Drawing.Size(151, 22);
            this.MenuFileOpen.Text = "&Open";
            this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("MenuFileSave.Image")));
            this.MenuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuFileSave.Size = new System.Drawing.Size(151, 22);
            this.MenuFileSave.Text = "&Save";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            this.MenuFileSaveAs.Size = new System.Drawing.Size(151, 22);
            this.MenuFileSaveAs.Text = "Save &As";
            this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(151, 22);
            this.MenuFileExit.Text = "E&xit";
            // 
            // MenuNetwork
            // 
            this.MenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkQuery});
            this.MenuNetwork.Name = "MenuNetwork";
            this.MenuNetwork.Size = new System.Drawing.Size(59, 20);
            this.MenuNetwork.Text = "Network";
            // 
            // MenuNetworkQuery
            // 
            this.MenuNetworkQuery.Name = "MenuNetworkQuery";
            this.MenuNetworkQuery.Size = new System.Drawing.Size(115, 22);
            this.MenuNetworkQuery.Text = "Query";
            this.MenuNetworkQuery.Click += new System.EventHandler(this.MenuNetworkQuery_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(40, 20);
            this.MenuHelp.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Enabled = false;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(129, 22);
            this.MenuHelpAbout.Text = "&About...";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ann";
            this.openFileDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Open Network Object";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Network Objects (*.ann)|*.ann|All Files (*.*)|*.*";
            this.saveFileDialog.Title = "Save Network Object";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // networkRangesControl
            // 
            this.networkRangesControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.networkRangesControl.Enabled = false;
            this.networkRangesControl.Location = new System.Drawing.Point(813, 375);
            this.networkRangesControl.Name = "networkRangesControl";
            this.networkRangesControl.ReadOnly = false;
            this.networkRangesControl.Size = new System.Drawing.Size(200, 263);
            this.networkRangesControl.TabIndex = 14;
            // 
            // networkCreatorControl
            // 
            this.networkCreatorControl.Enabled = false;
            this.networkCreatorControl.Location = new System.Drawing.Point(5, 79);
            this.networkCreatorControl.Name = "networkCreatorControl";
            this.networkCreatorControl.Size = new System.Drawing.Size(195, 248);
            this.networkCreatorControl.TabIndex = 13;
            // 
            // networkTrainerControl
            // 
            this.networkTrainerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.networkTrainerControl.Enabled = false;
            this.networkTrainerControl.Location = new System.Drawing.Point(5, 333);
            this.networkTrainerControl.Name = "networkTrainerControl";
            this.networkTrainerControl.Size = new System.Drawing.Size(195, 305);
            this.networkTrainerControl.TabIndex = 12;
            // 
            // networkDataControl
            // 
            this.networkDataControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.networkDataControl.Enabled = false;
            this.networkDataControl.Location = new System.Drawing.Point(206, 86);
            this.networkDataControl.Name = "networkDataControl";
            this.networkDataControl.Size = new System.Drawing.Size(601, 551);
            this.networkDataControl.TabIndex = 11;
            // 
            // networkDisplayControl
            // 
            this.networkDisplayControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.networkDisplayControl.Enabled = false;
            this.networkDisplayControl.Location = new System.Drawing.Point(813, 79);
            this.networkDisplayControl.Name = "networkDisplayControl";
            this.networkDisplayControl.ReadOnly = false;
            this.networkDisplayControl.Size = new System.Drawing.Size(200, 290);
            this.networkDisplayControl.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 666);
            this.Controls.Add(this.networkDisplayControl);
            this.Controls.Add(this.networkRangesControl);
            this.Controls.Add(this.networkCreatorControl);
            this.Controls.Add(this.networkTrainerControl);
            this.Controls.Add(this.networkDataControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(780, 500);
            this.Name = "MainForm";
            this.Text = "Network Trainer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNetworkName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbInputCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRowCount;
        private System.Windows.Forms.Label lbOutputCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusEpoch;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusError;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuNetwork;
        private Sinapse.Controls.NetworkDataTrainControl networkDataControl;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileNew;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private Sinapse.Controls.NetworkTrainerControl networkTrainerControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNeuronCount;
        private Sinapse.Controls.NetworkCreatorControl networkCreatorControl;
        private System.Windows.Forms.ToolStripStatusLabel lbItems;
        private Sinapse.Controls.NetworkRangesControl networkRangesControl;
        private Sinapse.Controls.NetworkDisplayControl networkDisplayControl;
    }
}