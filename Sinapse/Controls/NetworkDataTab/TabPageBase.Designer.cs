namespace Sinapse.Controls.NetworkDataTab
{
    partial class TabPageBase
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
            this.panelOutputCaption = new System.Windows.Forms.Panel();
            this.panelInputCaption = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeRowsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOutputCaption
            // 
            this.panelOutputCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOutputCaption.BackColor = System.Drawing.Color.AliceBlue;
            this.panelOutputCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOutputCaption.Location = new System.Drawing.Point(81, 377);
            this.panelOutputCaption.Name = "panelOutputCaption";
            this.panelOutputCaption.Size = new System.Drawing.Size(14, 12);
            this.panelOutputCaption.TabIndex = 25;
            // 
            // panelInputCaption
            // 
            this.panelInputCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInputCaption.BackColor = System.Drawing.Color.Honeydew;
            this.panelInputCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputCaption.Location = new System.Drawing.Point(3, 377);
            this.panelInputCaption.Name = "panelInputCaption";
            this.panelInputCaption.Size = new System.Drawing.Size(14, 12);
            this.panelInputCaption.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(98, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 11);
            this.label9.TabIndex = 23;
            this.label9.Text = "Output";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 11);
            this.label10.TabIndex = 24;
            this.label10.Text = "Input";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Location = new System.Drawing.Point(3, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(582, 337);
            this.dataGridView.TabIndex = 22;
            this.dataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeRowsToToolStripMenuItem,
            this.MenuTraining,
            this.MenuValidation,
            this.MenuTesting});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 92);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // changeRowsToToolStripMenuItem
            // 
            this.changeRowsToToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeRowsToToolStripMenuItem.Name = "changeRowsToToolStripMenuItem";
            this.changeRowsToToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.changeRowsToToolStripMenuItem.Text = "Mark rows as";
            // 
            // MenuTraining
            // 
            this.MenuTraining.Name = "MenuTraining";
            this.MenuTraining.Size = new System.Drawing.Size(160, 22);
            this.MenuTraining.Text = "Training data";
            this.MenuTraining.Click += new System.EventHandler(this.MenuTraining_Click);
            // 
            // MenuValidation
            // 
            this.MenuValidation.Name = "MenuValidation";
            this.MenuValidation.Size = new System.Drawing.Size(160, 22);
            this.MenuValidation.Text = "Validation data";
            this.MenuValidation.Click += new System.EventHandler(this.MenuValidation_Click);
            // 
            // MenuTesting
            // 
            this.MenuTesting.Name = "MenuTesting";
            this.MenuTesting.Size = new System.Drawing.Size(160, 22);
            this.MenuTesting.Text = "Testing data";
            this.MenuTesting.Click += new System.EventHandler(this.MenuTesting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Set Name";
            // 
            // openFileDialog
            // 
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.Title = "Import Data";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Image = global::Sinapse.Properties.Resources.network_22;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.Location = new System.Drawing.Point(515, 372);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 23);
            this.btnImport.TabIndex = 27;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // TabPageBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panelOutputCaption);
            this.Controls.Add(this.panelInputCaption);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView);
            this.Name = "TabPageBase";
            this.Size = new System.Drawing.Size(588, 398);
            this.Load += new System.EventHandler(this.TabPageBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panelOutputCaption;
        private System.Windows.Forms.Panel panelInputCaption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.DataGridView dataGridView;
        protected internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        protected internal System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.ToolStripMenuItem changeRowsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTraining;
        private System.Windows.Forms.ToolStripMenuItem MenuValidation;
        private System.Windows.Forms.ToolStripMenuItem MenuTesting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    }
}
