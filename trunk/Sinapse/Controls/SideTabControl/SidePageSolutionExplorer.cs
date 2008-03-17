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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data.Network;


namespace Sinapse.Controls.SideTabControl
{
    internal sealed partial class SidePageSolutionExplorer : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkWorkplace networkWorkplace;


        //---------------------------------------------

        #region Constructor
        public SidePageSolutionExplorer()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public NetworkWorkplace Workplace
        {
            get { return this.networkWorkplace; }
            set
            {
                this.networkWorkplace = value;
                
                if (value != null)
                {
                    this.populateTreeView();
                    this.networkWorkplace.Sessions.ListChanged += sessions_ListChanged;
                }
            }
        }
        #endregion


        //---------------------------------------------

        #region Control Events
        #endregion


        //---------------------------------------------
        

        #region Object Events
        private void sessions_ListChanged(object sender, ListChangedEventArgs e)
        {
            
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void populateTreeView()
        {
            this.treeView.Nodes.Add(createNode(networkWorkplace));
        }

        private TreeNode createNode(NetworkWorkplace workplace)
        {
            TreeNode node = new TreeNode(workplace.Name);
            foreach (TrainingSession session in workplace.Sessions)
            {
                node.Nodes.Add(createNode(session));
            }
            return node;
        }

        private TreeNode createNode(TrainingSession session)
        {           
            TreeNode node = new TreeNode(session.Name);
            node.Tag = session;
            node.Nodes.Add(createNode(session.Database));
            node.Nodes.Add(createNode(session.Network));
            return node;
        }

        private TreeNode createNode(NetworkContainer container)
        {
            TreeNode node = new TreeNode("Network");
            node.Tag = container;
            return node;
        }

        private TreeNode createNode(NetworkDatabase database)
        {
            TreeNode node = new TreeNode("Database");
            node.Tag = database;
            return node;
        }
        #endregion

    }
}
