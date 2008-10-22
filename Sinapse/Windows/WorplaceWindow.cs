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
using Sinapse.Core.Systems;
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

        public event WorkplaceContentDoubleClickedEventHandler WorkplaceContentDoubleClicked;

        #region Constructor
        public WorkplaceWindow()
        {
            InitializeComponent();

            nodeSources = new System.Windows.Forms.TreeNode("Sources", 1, 1);
            nodeSources.ContextMenuStrip = this.menuSource;

            nodeSystems = new System.Windows.Forms.TreeNode("Systems", 1, 1);
            nodeSystems.ContextMenuStrip = this.menuSystem;

            nodeTraining = new System.Windows.Forms.TreeNode("Trainings", 1, 1);
            nodeTraining.ContextMenuStrip = this.menuTraining;

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
                this.treeViewWorkplace.Enabled = true;
                this.refreshView();

                Workplace.Active.DataSources.ListChanged += new ListChangedEventHandler(WorkplaceContentChanged);
                Workplace.Active.TrainingSessions.ListChanged += new ListChangedEventHandler(WorkplaceContentChanged);
                Workplace.Active.Systems.ListChanged += new ListChangedEventHandler(WorkplaceContentChanged);
            }
            else
            {
                this.treeViewWorkplace.Nodes.Clear();
                this.treeViewWorkplace.Enabled = false;
                this.label1.Show();
            }
        }

        private void WorkplaceContentChanged(object sender, ListChangedEventArgs e)
        {
            this.refreshView();
        }

        private void refreshView()
        {
            this.treeViewWorkplace.SuspendLayout();
            this.treeViewWorkplace.Nodes.Clear();
            TreeNode node;
            foreach (NetworkSystemBase system in Workplace.Active.Systems)
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
            this.treeViewWorkplace.Nodes.Add(rootWorkplace);
            this.treeViewWorkplace.ExpandAll();
            this.treeViewWorkplace.ResumeLayout(true);
        }

        private void btnAddSourceTable_Click(object sender, EventArgs e)
        {
            TableDataSource item = new TableDataSource("TableDataSource");
            Workplace.Active.DataSources.Add(item);

            this.OnWorkplaceContentDoubleClicked(new WorkplaceContentDoubleClickedEventArgs(item));
        }

        private void treeViewWorkplace_DoubleClick(object sender, EventArgs e)
        {
            object tag = this.treeViewWorkplace.SelectedNode.Tag;

            if (tag is WorkplaceContent)
                this.OnWorkplaceContentDoubleClicked(
                    new WorkplaceContentDoubleClickedEventArgs(tag as WorkplaceContent));
        }

        private void treeViewWorkplace_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void OnWorkplaceContentDoubleClicked(WorkplaceContentDoubleClickedEventArgs e)
        {
            if (this.WorkplaceContentDoubleClicked != null)
                this.WorkplaceContentDoubleClicked.Invoke(this, e);
        }
    }

    #region Event Delegates & Arguments
    internal delegate void WorkplaceContentDoubleClickedEventHandler(object sender, WorkplaceContentDoubleClickedEventArgs e);
    internal sealed class WorkplaceContentDoubleClickedEventArgs : EventArgs
    {
        private WorkplaceContent workplaceContent;

        public WorkplaceContent WorkplaceContent
        {
            get { return workplaceContent; }
            set { workplaceContent = value; }
        }
        public WorkplaceContentDoubleClickedEventArgs(WorkplaceContent item)
        {
            this.workplaceContent = item;
        }
    }
    #endregion
}
