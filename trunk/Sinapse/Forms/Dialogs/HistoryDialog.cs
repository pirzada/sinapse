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

using Sinapse.Data;


namespace Sinapse.Forms.Dialogs
{
    internal sealed partial class HistoryDialog : Sinapse.Forms.Base.SingleInstanceForm
    {
        internal HistoryDialog()
        {
            InitializeComponent();

            HistoryListener.NewActionLogged += new EventHandler(newActionLogged);
        }

        private void newActionLogged(object sender, EventArgs e)
        {
            this.textBox.Clear();

            foreach (HistoryEvent hEvent in HistoryListener.ActionLog)
            {
                this.textBox.Text += hEvent.ToString(); 
            }

            if (this.btnAutoScroll.Checked)
                this.scrollToEnd();
        }

        private void scrollToEnd()
        {
            this.textBox.Select(this.textBox.Text.Length, 0);
            this.textBox.ScrollToCaret();
        }

    }
}