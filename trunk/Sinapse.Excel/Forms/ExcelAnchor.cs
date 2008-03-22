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

using Microsoft.Office.Core;

using Sinapse.ExcelExtension.Forms.Dialogs;


namespace Sinapse.ExcelExtension.Forms
{

    partial class ExcelAnchor : Form
    {

        
        public ExcelAnchor()
        {
            InitializeComponent();
            InitializeHook();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Anchor on the bottom-right corner of the screen.
            Screen currentScreen = Screen.FromHandle(this.Handle);
            this.Location = new Point(currentScreen.WorkingArea.Width - this.Width,
                                      currentScreen.WorkingArea.Height - this.Height);
        }


        private void MenuSinapseAbout_Click(CommandBarButton sender, ref bool cancel)
        {
            new AboutBox().ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }
    }
}