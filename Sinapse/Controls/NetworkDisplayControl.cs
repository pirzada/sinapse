/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2007 Cesar Roberto de Souza <cesarsouza@gmail.com> *
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

namespace Sinapse.Controls
{
    public partial class NetworkDisplayControl : UserControl
    {

        private NetworkContainer m_neuralNetwork;
        private bool m_readOnly;
        private bool m_visible;

        public NetworkDisplayControl()
        {
            InitializeComponent();
        }

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
                        
                        this.m_neuralNetwork.OnNetworkChanged += new EventHandler(neuralNetwork_NetworkChanged);
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
            this.lbName.Text = m_neuralNetwork.Name;
            this.lbLayout.Text = m_neuralNetwork.GetLayoutString();
            this.lbDescription.Text = m_neuralNetwork.Description;
            this.lbErrorRate.Text = m_neuralNetwork.Precision.ToString("0.000000");
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
            if (InputDialog.Show("Please type a new network name", "Network name", m_neuralNetwork.Name, out name) == DialogResult.OK)
            {
                this.m_neuralNetwork.Name = name;
            }
        }

        private void lbDescription_Click(object sender, EventArgs e)
        {
            if (this.m_readOnly)
                return;

            string description;
            if (InputDialog.Show("Please type a network description", "Network description", m_neuralNetwork.Description, out description) == DialogResult.OK)
            {
                this.m_neuralNetwork.Description = description;
            }
        }
        #endregion
    }
}
