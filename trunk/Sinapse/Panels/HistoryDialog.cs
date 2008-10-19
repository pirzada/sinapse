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
    
    internal sealed partial class HistoryDialog : WeifenLuo.WinFormsUI.Docking.DockContent
    {


        #region Singleton
        private static HistoryDialog m_instance = null;

        public static HistoryDialog Instance
        {
            get
            {
                if (m_instance == null || m_instance.IsDisposed)
                    m_instance = new HistoryDialog();
                return m_instance;
            }
        }
        #endregion


        //----------------------------------------


        #region Constructor
        private HistoryDialog()
        {
            InitializeComponent();
        }
        #endregion


        //----------------------------------------


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                // Set form Sizing and Location
                if (!Properties.Settings.Default.history_FirstLoad)
                {
                    this.Size = Properties.Settings.Default.history_Size;
                    this.Location = Properties.Settings.Default.history_Location;
                }

                this.updateText();

                // Wire up controls and events
                HistoryListener.Log.ListChanged += new ListChangedEventHandler(history_logChanged);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // Save settings before closing
            Properties.Settings.Default.history_FirstLoad = false;
            Properties.Settings.Default.history_Size = this.Size;
            Properties.Settings.Default.history_Location = this.Location;
        }
        #endregion


        //----------------------------------------


        #region History Events
        private void history_logChanged(object sender, ListChangedEventArgs e)
        {
            this.updateText();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void scrollToEnd()
        {
            this.textBox.Select(this.textBox.Text.Length, 0);
            this.textBox.ScrollToCaret();
        }

        private void updateText()
        {
            this.textBox.Lines = HistoryListener.Log.ToStringArray();

            if (this.btnAutoScroll.Checked)
                this.scrollToEnd();
        }
        #endregion

    }
}