namespace Sinapse.Dialogs
{
    partial class ImportWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWizard));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.wizardControl = new WizardBase.WizardControl();
            this.startStep = new WizardBase.StartStep();
            this.intermediateStep1 = new WizardBase.IntermediateStep();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDatapath = new System.Windows.Forms.TextBox();
            this.intermediateStep2 = new WizardBase.IntermediateStep();
            this.label3 = new System.Windows.Forms.Label();
            this.clbInput = new System.Windows.Forms.CheckedListBox();
            this.intermediateStep3 = new WizardBase.IntermediateStep();
            this.label6 = new System.Windows.Forms.Label();
            this.clbOutput = new System.Windows.Forms.CheckedListBox();
            this.intermediateStep4 = new WizardBase.IntermediateStep();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clbString = new System.Windows.Forms.CheckedListBox();
            this.finishStep = new WizardBase.FinishStep();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbDelimiter = new System.Windows.Forms.ComboBox();
            this.btnAutodetect = new System.Windows.Forms.Button();
            this.intermediateStep1.SuspendLayout();
            this.intermediateStep2.SuspendLayout();
            this.intermediateStep3.SuspendLayout();
            this.intermediateStep4.SuspendLayout();
            this.finishStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All Files (*.*)|*.*";
            this.openFileDialog.Title = "Select data location";
            // 
            // wizardControl
            // 
            this.wizardControl.BackButtonEnabled = true;
            this.wizardControl.BackButtonVisible = true;
            this.wizardControl.CancelButtonEnabled = true;
            this.wizardControl.CancelButtonVisible = true;
            this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl.HelpButtonEnabled = false;
            this.wizardControl.HelpButtonVisible = true;
            this.wizardControl.Location = new System.Drawing.Point(0, 0);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.NextButtonEnabled = true;
            this.wizardControl.NextButtonVisible = true;
            this.wizardControl.Size = new System.Drawing.Size(536, 370);
            this.wizardControl.WizardSteps.Add(this.startStep);
            this.wizardControl.WizardSteps.Add(this.intermediateStep1);
            this.wizardControl.WizardSteps.Add(this.intermediateStep2);
            this.wizardControl.WizardSteps.Add(this.intermediateStep3);
            this.wizardControl.WizardSteps.Add(this.intermediateStep4);
            this.wizardControl.WizardSteps.Add(this.finishStep);
            this.wizardControl.CancelButtonClick += new System.EventHandler(this.wizardControl_CancelButtonClick);
            this.wizardControl.FinishButtonClick += new System.EventHandler(this.wizardControl_FinishButtonClick);
            this.wizardControl.NextButtonClick += new WizardBase.WizardNextButtonClickEventHandler(this.wizardControl_NextButtonClick);
            // 
            // startStep
            // 
            this.startStep.BindingImage = ((System.Drawing.Image)(resources.GetObject("startStep.BindingImage")));
            this.startStep.Icon = ((System.Drawing.Image)(resources.GetObject("startStep.Icon")));
            this.startStep.Name = "startStep";
            this.startStep.Subtitle = "This wizard will help importing your data to be used in a neural schema.";
            this.startStep.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.startStep.Title = "Welcome to the Data Import Wizard";
            this.startStep.TitleFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            // 
            // intermediateStep1
            // 
            this.intermediateStep1.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep1.BindingImage")));
            this.intermediateStep1.Controls.Add(this.cbDelimiter);
            this.intermediateStep1.Controls.Add(this.label9);
            this.intermediateStep1.Controls.Add(this.label2);
            this.intermediateStep1.Controls.Add(this.label4);
            this.intermediateStep1.Controls.Add(this.btnAutodetect);
            this.intermediateStep1.Controls.Add(this.btnBrowse);
            this.intermediateStep1.Controls.Add(this.label1);
            this.intermediateStep1.Controls.Add(this.tbDatapath);
            this.intermediateStep1.Name = "intermediateStep1";
            this.intermediateStep1.Subtitle = "Please select where your data resides.";
            this.intermediateStep1.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep1.Title = "Data Location";
            this.intermediateStep1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "The training samples should be presented as a field delimited file. Delimiter car" +
                "acters may be commas, semicolons or tabulations, which I hope will be detected f" +
                "rom your data automatically.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 90);
            this.label4.TabIndex = 4;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(437, 287);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data location:";
            // 
            // tbDatapath
            // 
            this.tbDatapath.Location = new System.Drawing.Point(103, 288);
            this.tbDatapath.Name = "tbDatapath";
            this.tbDatapath.Size = new System.Drawing.Size(328, 20);
            this.tbDatapath.TabIndex = 0;
            // 
            // intermediateStep2
            // 
            this.intermediateStep2.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep2.BindingImage")));
            this.intermediateStep2.Controls.Add(this.label3);
            this.intermediateStep2.Controls.Add(this.clbInput);
            this.intermediateStep2.Name = "intermediateStep2";
            this.intermediateStep2.Subtitle = "Please select columns which contains data to be fed to the Neural Network";
            this.intermediateStep2.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep2.Title = "Select Input";
            this.intermediateStep2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 56);
            this.label3.TabIndex = 1;
            this.label3.Text = "Please select now the columns in your data which will serve as input to our Neura" +
                "l Network.";
            // 
            // clbInput
            // 
            this.clbInput.CheckOnClick = true;
            this.clbInput.FormattingEnabled = true;
            this.clbInput.Location = new System.Drawing.Point(374, 83);
            this.clbInput.Name = "clbInput";
            this.clbInput.Size = new System.Drawing.Size(150, 229);
            this.clbInput.Sorted = true;
            this.clbInput.TabIndex = 0;
            // 
            // intermediateStep3
            // 
            this.intermediateStep3.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep3.BindingImage")));
            this.intermediateStep3.Controls.Add(this.label6);
            this.intermediateStep3.Controls.Add(this.clbOutput);
            this.intermediateStep3.Name = "intermediateStep3";
            this.intermediateStep3.Subtitle = "Please select data columns which will serve as sample output for the schema.";
            this.intermediateStep3.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep3.Title = "Select Output Examples";
            this.intermediateStep3.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 56);
            this.label6.TabIndex = 2;
            this.label6.Text = "Now, check the columns which represent the desired outputs of the given inputs du" +
                "ring the training process.";
            // 
            // clbOutput
            // 
            this.clbOutput.CheckOnClick = true;
            this.clbOutput.FormattingEnabled = true;
            this.clbOutput.Location = new System.Drawing.Point(374, 83);
            this.clbOutput.Name = "clbOutput";
            this.clbOutput.Size = new System.Drawing.Size(150, 229);
            this.clbOutput.Sorted = true;
            this.clbOutput.TabIndex = 1;
            // 
            // intermediateStep4
            // 
            this.intermediateStep4.BindingImage = ((System.Drawing.Image)(resources.GetObject("intermediateStep4.BindingImage")));
            this.intermediateStep4.Controls.Add(this.label8);
            this.intermediateStep4.Controls.Add(this.label7);
            this.intermediateStep4.Controls.Add(this.clbString);
            this.intermediateStep4.Name = "intermediateStep4";
            this.intermediateStep4.Subtitle = "Please select non-numerical fields so they can be correctly handled by the neural" +
                " schema";
            this.intermediateStep4.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.intermediateStep4.Title = "Select non-numerical fields";
            this.intermediateStep4.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(333, 56);
            this.label8.TabIndex = 3;
            this.label8.Text = "Please check any columns that contains categorical information so they can be cor" +
                "rectly handled by the Neural Network.";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(348, 56);
            this.label7.TabIndex = 3;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // clbString
            // 
            this.clbString.CheckOnClick = true;
            this.clbString.FormattingEnabled = true;
            this.clbString.Location = new System.Drawing.Point(374, 83);
            this.clbString.Name = "clbString";
            this.clbString.Size = new System.Drawing.Size(150, 229);
            this.clbString.Sorted = true;
            this.clbString.TabIndex = 2;
            // 
            // finishStep
            // 
            this.finishStep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("finishStep.BackgroundImage")));
            this.finishStep.Controls.Add(this.label5);
            this.finishStep.Name = "finishStep";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(151, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "We are ready to begin manipulating your data.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Field delimiter character:";
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.FormattingEnabled = true;
            this.cbDelimiter.Items.AddRange(new object[] {
            "Comma",
            "Semi-colon",
            "Space",
            "Tab"});
            this.cbDelimiter.Location = new System.Drawing.Point(151, 259);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(84, 21);
            this.cbDelimiter.TabIndex = 6;
            // 
            // btnAutodetect
            // 
            this.btnAutodetect.Location = new System.Drawing.Point(241, 258);
            this.btnAutodetect.Name = "btnAutodetect";
            this.btnAutodetect.Size = new System.Drawing.Size(232, 23);
            this.btnAutodetect.TabIndex = 2;
            this.btnAutodetect.Text = "Attempt auto-detection from specified file:";
            this.btnAutodetect.UseVisualStyleBackColor = true;
            this.btnAutodetect.Click += new System.EventHandler(this.btnAutodetect_Click);
            // 
            // ImportWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 370);
            this.Controls.Add(this.wizardControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportWizard";
            this.Text = "Import Data Wizard";
            this.intermediateStep1.ResumeLayout(false);
            this.intermediateStep1.PerformLayout();
            this.intermediateStep2.ResumeLayout(false);
            this.intermediateStep3.ResumeLayout(false);
            this.intermediateStep4.ResumeLayout(false);
            this.finishStep.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WizardBase.WizardControl wizardControl;
        private WizardBase.StartStep startStep;
        private WizardBase.IntermediateStep intermediateStep1;
        private WizardBase.FinishStep finishStep;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDatapath;
        private WizardBase.IntermediateStep intermediateStep2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbInput;
        private WizardBase.IntermediateStep intermediateStep3;
        private System.Windows.Forms.CheckedListBox clbOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private WizardBase.IntermediateStep intermediateStep4;
        private System.Windows.Forms.CheckedListBox clbString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDelimiter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAutodetect;

    }
}