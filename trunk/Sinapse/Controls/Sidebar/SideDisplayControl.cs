/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Dialogs;

namespace Sinapse.Controls.Sidebar
{
    public partial class SideDisplayControl : UserControl
    {

        private NetworkContainer m_neuralNetwork;
        private bool m_readOnly;
        private bool m_visible;


        //---------------------------------------------


        #region Constructor
        public SideDisplayControl()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal NetworkContainer NeuralNetwork
        {
            get
            {
                return this.m_neuralNetwork;
            }
            set
            {
                if (value != null)
                {
                    if (value != m_neuralNetwork)
                    {
                       this.m_neuralNetwork = value;
                        this.Enabled = true;
                        this.UpdateDisplayData();
                        this.lbIntro.Visible = false;
                        this.setVisible(true);
                        
                        this.m_neuralNetwork.NetworkChanged += new EventHandler(neuralNetwork_NetworkChanged);
                    }
                }
                else
                {
                    this.lbName.Text = "Network not present";
                    this.lbIntro.Visible = true;
                    this.setVisible(false);
                    this.Enabled = false;
                }
            }
        }
        
        public bool ReadOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;

                if (value)
                {
                    this.setCursors(Cursors.Default);
                }
                else
                {
                    this.setCursors(Cursors.Hand);
                }

                this.setVisible(this.m_visible);

            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal void UpdateDisplayData()
        {
            if (m_neuralNetwork == null)
                return;
            
            this.SuspendLayout();
            this.panelInputs.SuspendLayout();
            this.panelOutputs.SuspendLayout();
                                             
            this.lbName.Text = m_neuralNetwork.Name;
            this.lbLayout.Text = m_neuralNetwork.GetLayoutString();
            this.lbDescription.Text = m_neuralNetwork.Description;
            this.lbErrorRate.Text = m_neuralNetwork.Precision.ToString("0.000000");

            panelInputs.Controls.Clear();
            panelOutputs.Controls.Clear();

            Label label;
            foreach (string inputCol in m_neuralNetwork.Schema.InputColumns)
            {
                label = new Label();
                label.Text = inputCol;
                label.Font = new System.Drawing.Font(
                    "Microsoft Sans Serif", 6.75F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

                this.panelInputs.Controls.Add(label);
            }

            foreach (string outputCol in m_neuralNetwork.Schema.OutputColumns)
            {
                label = new Label();
                label.Text = outputCol;
                label.Font = new System.Drawing.Font(
                    "Microsoft Sans Serif", 6.75F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

                this.panelOutputs.Controls.Add(label);
            }

            this.panelInputs.ResumeLayout(true);
            this.panelOutputs.ResumeLayout(true);
            this.ResumeLayout(true);
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void neuralNetwork_NetworkChanged(object sender, EventArgs e)
        {
            this.UpdateDisplayData();
        }

        private void setVisible(bool value)
        {
            this.m_visible = value;

           // this.lbName.Visible = value;
            this.lbLayout.Visible = value;
            this.lbDescription.Visible = value;
            this.lbErrorRate.Visible = value;
            this.lbDescriptionH.Visible = value;
            this.lbNetworkLayoutH.Visible = value;
            this.lbPrecisionH.Visible = value;
            this.lbTableTitle.Visible = value;
            this.panelInputs.Visible = value;
            this.panelOutputs.Visible = value;
            this.lbInput.Visible = value;
            this.lbOutput.Visible = value;

            if (m_readOnly)
                this.lbDescriptionChange.Visible = false;
            else
                this.lbDescriptionChange.Visible = value;
        }

        private void setCursors(Cursor cursor)
        {
            this.lbDescriptionChange.Cursor = cursor;
            this.lbDescription.Cursor = cursor;
            this.lbName.Cursor = cursor;
        }
        #endregion


        //---------------------------------------------


        #region Events
        private void lbName_Click(object sender, EventArgs e)
        {
            if (this.m_readOnly)
                return;

            string name;
            if (InputBox.Show("Please type a new network name", "Network name", m_neuralNetwork.Name, out name) == DialogResult.OK)
            {
                this.m_neuralNetwork.Name = name;
            }
        }

        private void lbDescription_Click(object sender, EventArgs e)
        {
            if (this.m_readOnly)
                return;

            string description;
            if (InputBox.Show("Please type a network description", "Network description", m_neuralNetwork.Description, out description) == DialogResult.OK)
            {
                this.m_neuralNetwork.Description = description;
            }
        }
        #endregion

    }
}
