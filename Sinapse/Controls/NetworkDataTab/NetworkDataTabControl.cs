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
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

using Dotnetrix.Controls;

using Sinapse.Data;

namespace Sinapse.Controls.NetworkDataTab
{

    internal sealed class NetworkDataTabControl : Dotnetrix.Controls.TabControlEX
    {

        private NetworkDatabase m_networkData;


        private TabPageTraining m_tabTraining;
        private TabPageTesting m_tabTesting;
        private TabPageValidation m_tabValidation;
        

        public EventHandler SelectionChanged;
        public EventHandler DataChanged;
        public EventHandler SchemaChanged;
        public EventHandler DatabaseLoaded;


        //----------------------------------------

        
        #region Constructor
        public NetworkDataTabControl()
        {
            this.m_tabTesting = new TabPageTesting(this);
            this.m_tabValidation = new TabPageValidation(this);
            this.m_tabTraining = new TabPageTraining(this);
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnCreateControl()
        {
            if (!this.DesignMode)
            {
                if (this.Controls.Count == 0) // Prevents from inserting tabs twice
                {
                    this.Controls.Add(createTab(m_tabTraining, "Training Set", 0));
                    this.Controls.Add(createTab(m_tabValidation, "Validation Set", 1));
                    this.Controls.Add(createTab(m_tabTesting, "Testing Set", 2));
                }
            }

            base.OnCreateControl();
        }        
        #endregion


        //----------------------------------------            


        #region Properties
        internal NetworkDatabase NetworkDatabase
        {
            get
            {
                return this.m_networkData;
            }
            set
            {
                this.m_networkData = value;

                if (value != null)
                {
                    this.Enabled = true;
                    this.OnDatabaseLoaded();
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        internal TabPageBase SelectedControl
        {
            get { return this.SelectedTab.Controls[0] as TabPageBase; }
        }
      
        internal int ItemCount
        {
            get { return this.SelectedControl.ItemCount; }
        }

        internal int SelectedItemCount
        {
            get { return this.SelectedControl.SelectedItemCount; }
        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        private void OnDataChanged()
        {
            if (this.DataChanged != null)
                this.DataChanged.Invoke(this, EventArgs.Empty);
        }

        private void OnSelectionChanged()
        {
            if (this.SchemaChanged != null)
                this.SchemaChanged.Invoke(this, EventArgs.Empty);
        }

        private void OnDatabaseLoaded()
        {
            if (this.DatabaseLoaded != null)
                this.DatabaseLoaded.Invoke(this, EventArgs.Empty);
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void selectedTab_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged();
        }

        private TabPageEX createTab(UserControl control, string text, int imageIndex)
        {
            control.Dock = DockStyle.Fill;

            TabPageEX tabPage = new TabPageEX(text);
            tabPage.ImageIndex = imageIndex;
            tabPage.Controls.Add(control);

            return tabPage;
        }
        #endregion


    }
}
