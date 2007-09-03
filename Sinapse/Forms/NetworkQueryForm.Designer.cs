namespace Sinapse.Forms
{
    partial class NetworkQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkQueryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNetworkName = new System.Windows.Forms.Label();
            this.lbRunWizard = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShowRounded = new System.Windows.Forms.CheckBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbShowProbability = new System.Windows.Forms.CheckBox();
            this.networkDisplayControl = new Sinapse.Controls.NetworkDisplayControl();
            this.networkRangesControl = new Sinapse.Controls.NetworkRangesControl();
            this.networkDataQueryControl = new Sinapse.Controls.NetworkDataQueryControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbNetworkName);
            this.panel1.Controls.Add(this.lbRunWizard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 52);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please type or import your data in the grid below and click \'Query\' in the right " +
                "panel.";
            // 
            // lbNetworkName
            // 
            this.lbNetworkName.AutoSize = true;
            this.lbNetworkName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNetworkName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNetworkName.ForeColor = System.Drawing.SystemColors.Window;
            this.lbNetworkName.Location = new System.Drawing.Point(12, 4);
            this.lbNetworkName.Name = "lbNetworkName";
            this.lbNetworkName.Size = new System.Drawing.Size(246, 25);
            this.lbNetworkName.TabIndex = 0;
            this.lbNetworkName.Text = "Neural Network Query";
            // 
            // lbRunWizard
            // 
            this.lbRunWizard.AutoSize = true;
            this.lbRunWizard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRunWizard.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbRunWizard.Location = new System.Drawing.Point(192, 31);
            this.lbRunWizard.Name = "lbRunWizard";
            this.lbRunWizard.Size = new System.Drawing.Size(95, 13);
            this.lbRunWizard.TabIndex = 0;
            this.lbRunWizard.Text = "[acquire new data]";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(708, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(206, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Be sure not to enter values out of the trained data ranges specified on the right" +
                " corner sidebox.";
            // 
            // cbShowRounded
            // 
            this.cbShowRounded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbShowRounded.AutoSize = true;
            this.cbShowRounded.Checked = true;
            this.cbShowRounded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowRounded.Location = new System.Drawing.Point(10, 22);
            this.cbShowRounded.Name = "cbShowRounded";
            this.cbShowRounded.Size = new System.Drawing.Size(128, 17);
            this.cbShowRounded.TabIndex = 1;
            this.cbShowRounded.Text = "Show rounded results";
            this.cbShowRounded.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuery.Location = new System.Drawing.Point(21, 70);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(158, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "Query Network!";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbShowProbability);
            this.groupBox1.Controls.Add(this.cbShowRounded);
            this.groupBox1.Location = new System.Drawing.Point(708, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 99);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Query";
            // 
            // cbShowProbability
            // 
            this.cbShowProbability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbShowProbability.AutoSize = true;
            this.cbShowProbability.Checked = true;
            this.cbShowProbability.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowProbability.Location = new System.Drawing.Point(10, 45);
            this.cbShowProbability.Name = "cbShowProbability";
            this.cbShowProbability.Size = new System.Drawing.Size(127, 17);
            this.cbShowProbability.TabIndex = 1;
            this.cbShowProbability.Text = "Show data probability";
            this.cbShowProbability.UseVisualStyleBackColor = true;
            // 
            // networkDisplayControl
            // 
            this.networkDisplayControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.networkDisplayControl.Enabled = false;
            this.networkDisplayControl.Location = new System.Drawing.Point(708, 62);
            this.networkDisplayControl.Name = "networkDisplayControl";
            this.networkDisplayControl.ReadOnly = true;
            this.networkDisplayControl.Size = new System.Drawing.Size(200, 280);
            this.networkDisplayControl.TabIndex = 13;
            // 
            // networkRangesControl
            // 
            this.networkRangesControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.networkRangesControl.Enabled = false;
            this.networkRangesControl.Location = new System.Drawing.Point(708, 453);
            this.networkRangesControl.Name = "networkRangesControl";
            this.networkRangesControl.ReadOnly = true;
            this.networkRangesControl.Size = new System.Drawing.Size(200, 179);
            this.networkRangesControl.TabIndex = 9;
            // 
            // networkDataQueryControl
            // 
            this.networkDataQueryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.networkDataQueryControl.Enabled = false;
            this.networkDataQueryControl.Location = new System.Drawing.Point(4, 74);
            this.networkDataQueryControl.Name = "networkDataQueryControl";
            this.networkDataQueryControl.Size = new System.Drawing.Size(698, 585);
            this.networkDataQueryControl.TabIndex = 12;
            // 
            // NetworkQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 660);
            this.Controls.Add(this.networkDisplayControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.networkRangesControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.networkDataQueryControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkQueryForm";
            this.Text = "Network Query";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNetworkName;
        private System.Windows.Forms.Label lbRunWizard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbShowRounded;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private Sinapse.Controls.NetworkRangesControl networkRangesControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbShowProbability;
        private Sinapse.Controls.NetworkDataQueryControl networkDataQueryControl;
        private Sinapse.Controls.NetworkDisplayControl networkDisplayControl;
    }
}