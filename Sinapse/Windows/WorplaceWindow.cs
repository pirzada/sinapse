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

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Networks;
using Sinapse.Core.Sources;
using Sinapse.Core.Training;

namespace Sinapse.Windows
{
    internal sealed partial class WorkplaceWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {

       private TreeNode nodeSources;
       private TreeNode nodeSystems;
       private TreeNode nodeTraining;
        private TreeNode rootWorkplace; 

        public event EventHandler AddNewSource;
        public event EventHandler AddNewSystem;
        public event EventHandler AddNewSession;


        #region Constructor
        public WorkplaceWindow()
        {
            InitializeComponent();

            nodeSources = new System.Windows.Forms.TreeNode("Sources", 1, 1);
            nodeSystems = new System.Windows.Forms.TreeNode("Systems", 1, 1);
            nodeTraining = new System.Windows.Forms.TreeNode("Trainings", 1, 1);
            rootWorkplace = new System.Windows.Forms.TreeNode("Workplace", new System.Windows.Forms.TreeNode[] {
                nodeSources, nodeSystems, nodeTraining});

            Workplace.ActiveWorkplaceChanged += new EventHandler(Workplace_ActiveWorkplaceChanged);
        }
        #endregion


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        private void Workplace_ActiveWorkplaceChanged(object sender, EventArgs e)
        {
            if (Workplace.Active != null)
            {
                this.label1.Hide();
                this.treeView1.Enabled = true;
                this.RefreshTreeView();
            }
            else
            {
                this.treeView1.Nodes.Clear();
                this.treeView1.Enabled = false;
                this.label1.Show();
            }
        }

        private void RefreshTreeView()
        {
            this.treeView1.SuspendLayout();
            this.treeView1.Nodes.Clear();
            TreeNode node;
            foreach (AdaptativeSystemBase system in Workplace.Active.Systems)
            {
                node = new TreeNode(system.Name, 1, 1);
                node.Tag = system;
                nodeSystems.Nodes.Add(node);
            }
            foreach (DataSourceBase source in Workplace.Active.DataSources)
            {
                node = new TreeNode(source.Name, 1, 1);
                node.Tag = source;
                nodeSources.Nodes.Add(node);
            }
            foreach (TrainingSession session in Workplace.Active.TrainingSessions)
            {
                node = new TreeNode(session.Name, 1, 1);
                node.Tag = session;
                nodeTraining.Nodes.Add(node);
            }
            this.treeView1.Nodes.Add(rootWorkplace);
            this.treeView1.ExpandAll();
            this.treeView1.ResumeLayout(true);
        }

        private void btnAddSourceTable_Click(object sender, EventArgs e)
        {
            
        }
    }

    public delegate void SourceAddedEventHandler(SourceAddedEventArgs e, object sender);

    public class SourceAddedEventArgs : EventArgs
    {
        
    }
}
