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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;

namespace Sinapse.Controls.MainTabControl
{
    internal partial class TabPageQuery : Sinapse.Controls.MainTabControl.Base.TabPageDataControlBase
    {

        //----------------------------------------


        #region Constructor
        public TabPageQuery()
        {
            InitializeComponent();
            SetUp(NetworkSet.Query, "Network Query");
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnCurrentNetworkChanged()
        {
            this.setTabPageEnabled(this.NetworkContainer != null);

            if (this.NetworkContainer != null)
            {
                this.NetworkDatabase = new NetworkDatabase(this.NetworkContainer.Schema);
                //this.BindingSource.DataSource = m_networkDatabase;
            }
            else
            {
                this.NetworkDatabase = null;
                //this.BindingSource.DataSource = null;
            }
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.ComputeTable(this.NetworkContainer, false);

        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            this.NetworkDatabase.Round(false);
        }
        #endregion


        //----------------------------------------


    }
}

