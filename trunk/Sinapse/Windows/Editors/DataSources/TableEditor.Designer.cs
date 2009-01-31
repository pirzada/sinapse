namespace Sinapse.Forms.Editors.DataSources
{
    partial class TableEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditor));
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
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(0, 25);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(702, 368);
            this.dgvTable.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWizard,
            this.btnImport,
            this.toolStripSeparator1,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(702, 25);
            this.toolStrip1.TabIndex = 7;
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
            this.btnTrainingSet.Click += new System.EventHandler(this.btnTrainingSet_Click);
            // 
            // btnValidationSet
            // 
            this.btnValidationSet.Name = "btnValidationSet";
            this.btnValidationSet.Size = new System.Drawing.Size(131, 22);
            this.btnValidationSet.Text = "Validation";
            this.btnValidationSet.Click += new System.EventHandler(this.btnValidationSet_Click);
            // 
            // btnTestingSet
            // 
            this.btnTestingSet.Name = "btnTestingSet";
            this.btnTestingSet.Size = new System.Drawing.Size(131, 22);
            this.btnTestingSet.Text = "Testing";
            this.btnTestingSet.Click += new System.EventHandler(this.btnTestingSet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.outputCaption);
            this.panel1.Controls.Add(this.inputCaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 28);
            this.panel1.TabIndex = 8;
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
            // TableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 421);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "TableEditor";
            this.TabText = "TableEditor";
            this.Text = "Table Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnWizard;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnTrainingSet;
        private System.Windows.Forms.ToolStripMenuItem btnValidationSet;
        private System.Windows.Forms.ToolStripMenuItem btnTestingSet;
        private System.Windows.Forms.Panel panel1;
        private Sinapse.Controls.CaptionLabel outputCaption;
        private Sinapse.Controls.CaptionLabel inputCaption;
        private System.Windows.Forms.OpenFileDialog importDialog;
    }
}