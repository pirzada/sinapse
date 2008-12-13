namespace Sinapse.Documents
{
    partial class TableDataSourceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDataSourceEditor));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnWizard = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnTrainingSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnValidationSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestingSet = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outputCaption = new Sinapse.Controls.CaptionLabel();
            this.inputCaption = new Sinapse.Controls.CaptionLabel();
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabColumns.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabColumns);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(834, 640);
            this.tabControl.TabIndex = 3;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.dgvTable);
            this.tabTable.Controls.Add(this.toolStrip1);
            this.tabTable.Controls.Add(this.panel1);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(826, 614);
            this.tabTable.TabIndex = 1;
            this.tabTable.Text = "Table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(3, 28);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(820, 555);
            this.dgvTable.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWizard,
            this.btnImport,
            this.toolStripSeparator1,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnWizard
            // 
            this.btnWizard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWizard.Image = global::Sinapse.Properties.Resources.wizard;
            this.btnWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWizard.Name = "btnWizard";
            this.btnWizard.Size = new System.Drawing.Size(23, 22);
            this.btnWizard.Text = "Import Wizard";
            this.btnWizard.Click += new System.EventHandler(this.btnWizard_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::Sinapse.Properties.Resources.file_import;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(59, 22);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTrainingSet,
            this.btnValidationSet,
            this.btnTestingSet});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(95, 22);
            this.toolStripSplitButton1.Text = "Current Set";
            // 
            // btnTrainingSet
            // 
            this.btnTrainingSet.Name = "btnTrainingSet";
            this.btnTrainingSet.Size = new System.Drawing.Size(131, 22);
            this.btnTrainingSet.Text = "Training";
            // 
            // btnValidationSet
            // 
            this.btnValidationSet.Name = "btnValidationSet";
            this.btnValidationSet.Size = new System.Drawing.Size(131, 22);
            this.btnValidationSet.Text = "Validation";
            // 
            // btnTestingSet
            // 
            this.btnTestingSet.Name = "btnTestingSet";
            this.btnTestingSet.Size = new System.Drawing.Size(131, 22);
            this.btnTestingSet.Text = "Testing";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.outputCaption);
            this.panel1.Controls.Add(this.inputCaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 583);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 28);
            this.panel1.TabIndex = 5;
            // 
            // outputCaption
            // 
            this.outputCaption.AutoSize = true;
            this.outputCaption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outputCaption.Color = System.Drawing.Color.AliceBlue;
            this.outputCaption.Location = new System.Drawing.Point(74, 5);
            this.outputCaption.Name = "outputCaption";
            this.outputCaption.Size = new System.Drawing.Size(71, 20);
            this.outputCaption.TabIndex = 0;
            this.outputCaption.Text = "Outputs";
            // 
            // inputCaption
            // 
            this.inputCaption.AutoSize = true;
            this.inputCaption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputCaption.Color = System.Drawing.Color.Honeydew;
            this.inputCaption.Location = new System.Drawing.Point(5, 5);
            this.inputCaption.Name = "inputCaption";
            this.inputCaption.Size = new System.Drawing.Size(63, 20);
            this.inputCaption.TabIndex = 0;
            this.inputCaption.Text = "Inputs";
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.splitContainer1);
            this.tabColumns.Location = new System.Drawing.Point(4, 22);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tabColumns.Size = new System.Drawing.Size(826, 614);
            this.tabColumns.TabIndex = 0;
            this.tabColumns.Text = "Column Specification";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(820, 608);
            this.splitContainer1.SplitterDistance = 578;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvColumns);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 608);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Columns";
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(3, 16);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.Size = new System.Drawing.Size(572, 589);
            this.dgvColumns.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "tds";
            // 
            // TableDataSourceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 640);
            this.Controls.Add(this.tabControl);
            this.Name = "TableDataSourceEditor";
            this.TabText = "DataSource Editor";
            this.Text = "Table Data Source Editor";
            this.Load += new System.EventHandler(this.TableDataSourceEditor_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabColumns.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabColumns;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnTrainingSet;
        private System.Windows.Forms.ToolStripMenuItem btnValidationSet;
        private System.Windows.Forms.ToolStripMenuItem btnTestingSet;
        private System.Windows.Forms.Panel panel1;
        private Sinapse.Controls.CaptionLabel inputCaption;
        private Sinapse.Controls.CaptionLabel outputCaption;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog importDialog;
    }
}
