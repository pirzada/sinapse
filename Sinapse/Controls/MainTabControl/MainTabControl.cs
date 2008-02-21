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

using Sinapse.Controls.Base;
using Sinapse.Controls.MainTabControl.Base;
using Sinapse.Data.Network;


namespace Sinapse.Controls.MainTabControl
{

    internal sealed partial class MainTabControl : Control
    {

        private TabPageTraining m_tabTraining;
        private TabPageTesting m_tabTesting;
        private TabPageValidation m_tabValidation;
        private TabPageQuery m_tabQuery;
        private TabPageGraph m_tabGraph;


        public EventHandler DataSelectionChanged;


        //----------------------------------------


        #region Constructor
        public MainTabControl()
        {           
            InitializeComponent();
            
            this.m_tabTraining = new TabPageTraining();
            this.m_tabValidation = new TabPageValidation();
            this.m_tabTesting = new TabPageTesting();
            this.m_tabQuery = new TabPageQuery();
            this.m_tabGraph = new TabPageGraph();

            this.setTab(m_tabTraining, tabTraining);
            this.setTab(m_tabValidation, tabValidation);
            this.setTab(m_tabTesting, tabTesting);
            this.setTab(m_tabQuery, tabQuery);
            this.setTab(m_tabGraph, tabGraph);

        }
        #endregion


        //----------------------------------------


        #region Control Events
        private void OnDataSelectionChanged()
        {
            if (this.DataSelectionChanged != null)
                this.DataSelectionChanged.Invoke(this, EventArgs.Empty);
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            this.OnDataSelectionChanged();
        }

        private void tabPage_SelectionChanged(object sender, EventArgs e)
        {
            this.OnDataSelectionChanged();
        }
        #endregion


        //----------------------------------------            


        #region Properties
        internal NetworkDatabase NetworkDatabase
        {
            set
            {
                this.m_tabTraining.NetworkDatabase = value;
                this.m_tabValidation.NetworkDatabase = value;
                this.m_tabTesting.NetworkDatabase = value;
            }
        }

        internal NetworkContainer NetworkContainer
        {
            set
            {
                this.m_tabTesting.NetworkContainer = value;
                this.m_tabQuery.NetworkContainer = value;
                this.m_tabGraph.NetworkContainer = value;
            }
        }

        internal int ItemCount
        {
            get
            {
                if (this.SelectedControl is TabPageDataControlBase)
                    return (this.SelectedControl as TabPageDataControlBase).ItemCount;
                else return 0;
            }
        }

        internal int SelectedItemCount
        {
            get
            {
                if (this.SelectedControl is TabPageDataControlBase)
                    return (this.SelectedControl as TabPageDataControlBase).SelectedItemCount;
                else return 0;
            }
        }

        internal TabPageControlBase SelectedControl
        {
            get { return this.tabControl.SelectedTab.Controls[0] as TabPageControlBase; }
        }
        #endregion


        //---------------------------------------------


        #region Tab Pages
        internal TabPageTraining TrainingSetControl
        {
            get { return this.m_tabTraining; }
        }

        internal TabPageTesting TestingSetControl
        {
            get { return this.m_tabTesting; }
        }

        internal TabPageValidation ValidationSetControl
        {
            get { return this.m_tabValidation; }
        }

        internal TabPageQuery QueryControl
        {
            get { return this.m_tabQuery; }
        }

        internal TabPageGraph GraphControl
        {
            get { return this.m_tabGraph; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        #endregion


        //----------------------------------------


        #region Private Methods
        private void setTab(UserControl userControl, TabPageEX tabPage)
        {
            if (userControl is TabPageDataControlBase)
            {
                (userControl as TabPageDataControlBase).DataSelectionChanged += tabPage_SelectionChanged;
            }

            userControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(userControl);
        }
        #endregion

    }
}
