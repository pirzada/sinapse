using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Dialogs;

using AForge;
using AForge.Neuro;
using AForge.Controls;
using AForge.Neuro.Learning;

namespace Sinapse.Forms
{

    internal sealed partial class MainForm : Form
    {

        private NeuralNetwork m_neuralNetwork;

        //---------------------------------------------

        #region Constructor & Destructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal NeuralNetwork CurrentNetwork
        {
            get { return m_neuralNetwork; }
            set
            {
                this.m_neuralNetwork = value;
                this.networkTrainerControl.NeuralNetwork = value;
                this.networkDisplayControl.NeuralNetwork = value;

                if (value != null)
                {
                    this.MenuNetwork.Enabled = true;
                    this.MenuFileSave.Enabled = true;
                    this.MenuFileSaveAs.Enabled = true;
                    this.lbNeuronCount.Text = m_neuralNetwork.LayoutString();

                    this.m_neuralNetwork.OnSavePathChanged += neuralNetwork_SavePathChanged;
                    this.neuralNetwork_SavePathChanged(null, EventArgs.Empty);
                }
                else
                {
                    this.lbNeuronCount.Text = "0";
                    this.MenuNetwork.Enabled = false;
                    this.MenuFileSave.Enabled = false;
                    this.MenuFileSaveAs.Enabled = false;
                }
            }
        }
        #endregion

        //---------------------------------------------

        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Wire up controls and events
            this.networkDataControl.OnDataChanged += networkDataControl_DataChanged;
            this.networkDataControl.OnSchemaChanged += networkDataControl_SchemaChanged;
            this.networkDataControl.OnSelectionChanged += networkDataControl_SelectionChanged;
            this.networkCreatorControl.OnNetworkCreated += networkCreatorControl_NetworkCreated;
            this.networkTrainerControl.OnStatusChanged += networkTrainerControl_StatusChanged;
            this.networkTrainerControl.OnDataNeeded += networkTrainerControl_DataNeeded;
            this.networkTrainerControl.OnTrainingComplete += networkTrainerControl_TrainingComplete;

            this.CurrentNetwork = null;
            this.setStatus("Waiting data");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.setStatus("Exiting...");

            if (this.networkTrainerControl.IsTraining)
            {
                this.networkTrainerControl.Stop();
            }
        }
        #endregion

        //---------------------------------------------

        #region Network Data Control Events
        private void networkDataControl_SchemaChanged(object sender, EventArgs e)
        {
            this.lbInputCount.Text = this.networkDataControl.NetworkData.NetworkSchema.InputColumns.Length.ToString();
            this.lbOutputCount.Text = this.networkDataControl.NetworkData.NetworkSchema.OutputColumns.Length.ToString();

            this.networkCreatorControl.NetworkSchema = this.networkDataControl.NetworkData.NetworkSchema;
            this.networkRangesControl.NetworkData = this.networkDataControl.NetworkData;
            this.networkTrainerControl.NeuralNetwork = null;
        }

        private void networkDataControl_DataChanged(object sender, EventArgs e)
        {
            this.lbRowCount.Text = String.Format("({0} items)", networkDataControl.ItemCount);
            this.lbItems.Text = String.Format("{0}/{1}", this.networkDataControl.ItemCount, this.networkDataControl.SelectedItemCount);
        }

        private void networkDataControl_SelectionChanged(object sender, EventArgs e)
        {
            this.lbItems.Text = String.Format("{0}/{1}", this.networkDataControl.ItemCount, this.networkDataControl.SelectedItemCount);
        }
        #endregion

        //---------------------------------------------


        #region Other Controls Events
        private void networkCreatorControl_NetworkCreated(object sender, EventArgs e)
        {
            if (this.CurrentNetwork != null && MessageBox.Show("Would you like to overwride your current network?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.setStatus("Nothing changed");
                return;
            }

            this.CurrentNetwork = this.networkCreatorControl.NeuralNetwork;
            this.setStatus("Network Created");
        }
        #endregion


        #region Network Trainer Control Events
        private void networkTrainerControl_DataNeeded(object sender, EventArgs e)
        {
            double[][] input, output;
            this.networkDataControl.NetworkData.CreateVectors(out input, out output);
            this.networkTrainerControl.Start(input, output);
        }

        private void networkTrainerControl_StatusChanged(object sender, EventArgs e)
        {
            this.lbStatus.Text = this.networkTrainerControl.Status;
            this.progressBar.Value = this.networkTrainerControl.Progress;
            this.lbStatusEpoch.Text = String.Format("Epoch: {0}", this.networkTrainerControl.Epoch);
            this.lbStatusError.Text = String.Format("Error Rate: {0:0.00000}", this.networkTrainerControl.ErrorRate);
        }

        private void networkTrainerControl_TrainingComplete(object sender, EventArgs e)
        {
            this.m_neuralNetwork.Precision = this.networkTrainerControl.ErrorRate;

            if (MessageBox.Show("Training completed. Would you like to start querying the Network?",
                "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                 this.MenuNetworkQuery_Click(this, EventArgs.Empty);
            }
        }
        #endregion


        #region Neural Network Events
        private void neuralNetwork_SavePathChanged(object sender, EventArgs e)
        {
            this.openFileDialog.FileName = this.m_neuralNetwork.LastSavePath;
            this.saveFileDialog.FileName = this.m_neuralNetwork.LastSavePath;

            this.MenuFileSave.Enabled = (this.m_neuralNetwork.LastSavePath.Length > 0);
        }
        #endregion


        //---------------------------------------------

        #region Menus
        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            ImportWizard importWizard = new ImportWizard();
            if (importWizard.ShowDialog(this) == DialogResult.OK)
            {
                this.networkDataControl.NetworkData = importWizard.GetNetworkData();
                this.CurrentNetwork = null;
            }
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            this.networkSave(this.CurrentNetwork.LastSavePath);
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog(this);
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog(this);
        }

        private void MenuNetworkQuery_Click(object sender, EventArgs e)
        {
            this.setStatus("Querying network");
            new NetworkQueryForm(this.m_neuralNetwork).ShowDialog(this);
            this.setStatus("Ready");
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        #endregion

        //---------------------------------------------

        #region Statusbar Update
        private void setStatus(string text)
        {
            this.lbStatus.Text = text;
        }
        #endregion

        //---------------------------------------------

        #region Open & Save Network
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkLoad(openFileDialog.FileName);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkSave(saveFileDialog.FileName);
        }

        private void networkSave(string path)
        {
            try
            {
                NeuralNetwork.Serialize(this.CurrentNetwork, path);
            }
            catch
            {
                MessageBox.Show("Error saving network");
            }
        }

        private void networkLoad(string path)
        {
            NeuralNetwork neuralNetwork = null;

            try
            {
                neuralNetwork = NeuralNetwork.Deserialize(path);
            }
            catch
            {
                MessageBox.Show("Error opening network");
            }
            finally
            {
                if (neuralNetwork != null)
                {
                    this.CurrentNetwork = neuralNetwork;
                }
            }
        }
        #endregion

    }
}