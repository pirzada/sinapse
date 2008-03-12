/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
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

namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class StatusBarOptionsDialog 
        : Sinapse.Forms.Base.SingleInstanceForm
    {


        #region Constructor
        public StatusBarOptionsDialog()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            rbEpoch.Checked = !Properties.Settings.Default.display_UpdateByTime;
            rbTime.Checked = Properties.Settings.Default.display_UpdateByTime;

            numRate.Value = (decimal)Properties.Settings.Default.display_UpdateRate;
            numTime.Value = (decimal)Properties.Settings.Default.display_UpdateTime;
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnApply_Click(object sender, EventArgs e)
        {
            this.apply();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.apply();
            this.Close();
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void apply()
        {
            Properties.Settings.Default.display_UpdateByTime = this.rbTime.Checked;
            Properties.Settings.Default.display_UpdateRate = (int)numRate.Value;
            Properties.Settings.Default.display_UpdateTime = (int)numTime.Value;
        }
        #endregion

    }
}