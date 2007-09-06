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

namespace Sinapse.Controls
{
    internal sealed partial class NetworkRangesControl : UserControl
    {

        private NetworkData networkData;
        private bool readOnly;

        //---------------------------------------------

        #region Constructor
        public NetworkRangesControl()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------------------------------

        #region Properties
        internal NetworkData NetworkData
        {
            get { return this.networkData; }
            set
            {
                if (value != null)
                {
                    this.Enabled = true;
                    this.networkData = value;
                    this.dataGridView.DataSource = this.networkData.NetworkSchema.DataRanges.Table;
                }
                else
                {
                    this.Enabled = false;
                    this.dataGridView.DataSource = null;
                    this.networkData = null;
                }
            }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                this.readOnly = value;
                this.dataGridView.ReadOnly = value;
                this.btnAutodetect.Enabled = !value;
            }
        }
        #endregion

        //---------------------------------------------

        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            this.networkData.NetworkSchema.DataRanges.AutodetectRanges(this.networkData.DataTable);
        }

    }
}
