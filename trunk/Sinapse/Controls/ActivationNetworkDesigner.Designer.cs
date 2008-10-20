namespace Sinapse.Editors
{
    partial class ActivationNetworkDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivationNetworkDesigner));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbActivationFunction = new System.Windows.Forms.ComboBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.activationFunctionView1 = new Sinapse.Forms.Controls.Controls.ActivationFunctionView();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layer Organization";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbActivationFunction);
            this.groupBox2.Controls.Add(this.propertyGrid1);
            this.groupBox2.Controls.Add(this.activationFunctionView1);
            this.groupBox2.Location = new System.Drawing.Point(3, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 404);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activation Function";
            // 
            // cbActivationFunction
            // 
            this.cbActivationFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivationFunction.FormattingEnabled = true;
            this.cbActivationFunction.Location = new System.Drawing.Point(6, 19);
            this.cbActivationFunction.Name = "cbActivationFunction";
            this.cbActivationFunction.Size = new System.Drawing.Size(231, 21);
            this.cbActivationFunction.TabIndex = 0;
            this.cbActivationFunction.SelectedIndexChanged += new System.EventHandler(this.cbActivationFunction_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(6, 46);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(231, 352);
            this.propertyGrid1.TabIndex = 0;
            // 
            // activationFunctionView1
            // 
            this.activationFunctionView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.activationFunctionView1.Domain = ((AForge.DoubleRange)(resources.GetObject("activationFunctionView1.Domain")));
            this.activationFunctionView1.Function = null;
            this.activationFunctionView1.Location = new System.Drawing.Point(243, 19);
            this.activationFunctionView1.Name = "activationFunctionView1";
            this.activationFunctionView1.Size = new System.Drawing.Size(452, 379);
            this.activationFunctionView1.Steps = ((uint)(1u));
            this.activationFunctionView1.TabIndex = 2;
            this.activationFunctionView1.Text = "activationFunctionView1";
            // 
            // ActivationNetworkDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActivationNetworkDesigner";
            this.Size = new System.Drawing.Size(707, 571);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sinapse.Forms.Controls.Controls.ActivationFunctionView activationFunctionView1;
        private System.Windows.Forms.ComboBox cbActivationFunction;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
