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

    public partial class WorkplaceWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        private bool directoryView = true;


        private TreeNode rootWorkplace;

        private TreeNode nodeSources;
        private TreeNode nodeSystems;
        private TreeNode nodeSessions;
        

        public event WorkplaceContentDoubleClickedEventHandler WorkplaceContentDoubleClicked;


        #region Constructor
        public WorkplaceWindow()
        {
            InitializeComponent();

            rootWorkplace = new TreeNode("Workplace", 0, 0);

            nodeSources = new System.Windows.Forms.TreeNode("Sources", 2, 2);
            nodeSources.ContextMenuStrip = this.menuSource;

            nodeSystems = new System.Windows.Forms.TreeNode("Systems", 3, 3);
            nodeSystems.ContextMenuStrip = this.menuSystem;

            nodeTraining = new System.Windows.Forms.TreeNode("Trainings", 4, 4);
            nodeTraining.ContextMenuStrip = this.menuTraining;

            


            Workplace.ActiveWorkplaceChanged += new EventHandler(Workplace_ActiveWorkplaceChanged);
        }
        #endregion




        #region Properties
        /// <summary>
        ///   Gets the current selected WorkplaceContent on the Workplace Window
        /// </summary>
        public SinapseDocumentInfo SelectedItem
        {
            get
            {
                if (this.treeViewWorkplace.SelectedNode != null)
                {
                    object tag = this.treeViewWorkplace.SelectedNode.Tag;

                    if (tag is SinapseDocumentInfo)
                        return tag as SinapseDocumentInfo;
                }
                return null;
            }
        }

        public event TreeViewEventHandler SelectionChanged
        {
            add { this.treeViewWorkplace.AfterSelect += value; }
            remove { this.treeViewWorkplace.AfterSelect -= value; }
        }

        public new event EventHandler DoubleClick
        {
            add { this.treeViewWorkplace.DoubleClick += value; }
            remove { this.treeViewWorkplace.DoubleClick -= value; }
        }
        #endregion




        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Workplace_ActiveWorkplaceChanged(null, EventArgs.Empty);
        }

        private void treeViewWorkplace_DoubleClick(object sender, EventArgs e)
        {
            object tag = this.treeViewWorkplace.SelectedNode.Tag;

            if (tag is SinapseDocumentInfo)
                this.OnWorkplaceContentDoubleClicked(
                    new WorkplaceContentDoubleClickedEventArgs(tag as SinapseDocumentInfo));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.populateTreeView();
        }
        #endregion




        #region Workplace Events
        private void Workplace_ActiveWorkplaceChanged(object sender, EventArgs e)
        {
            // If we have an active workplace,
            if (Workplace.Active != null)
            {
                this.Enabled = true;

                // Lets hide the "Nothing to show" label and populate the tree view
                this.lbNothingToShow.Hide();
                this.treeViewWorkplace.Enabled = true;
                this.populateTreeView();

                // And also register the events for the new workplace
                Workplace.Active.DataSources.ListChanged += new ListChangedEventHandler(Workplace_ContentChanged);
                Workplace.Active.TrainingSessions.ListChanged += new ListChangedEventHandler(Workplace_ContentChanged);
                Workplace.Active.AdaptiveSystems.ListChanged += new ListChangedEventHandler(Workplace_ContentChanged);
            }
            else
            {
                // Otherwise, we hide everything and show a "Nothing to show"
                //   text label on the middle of the control.
                this.treeViewWorkplace.Nodes.Clear();
                this.treeViewWorkplace.Enabled = false;
                this.lbNothingToShow.Show();
                this.Enabled = false;
            }
        }


        private void Workplace_ContentChanged(object sender, ListChangedEventArgs e)
        {
            this.populateTreeView();
        }
        #endregion




        private void showCategoryView()
        {
            this.treeViewWorkplace.SuspendLayout();

            rootWorkplace.Text = Workplace.Active.Name;
            rootWorkplace.Tag = Workplace.Active;

            treeViewWorkplace.Nodes.Clear();
            rootWorkplace.Nodes.Clear();
            nodeSources.Nodes.Clear();
            nodeSystems.Nodes.Clear();
            nodeSessions.Nodes.Clear();


            TreeNode node;
            foreach (SinapseDocumentInfo document in Workplace.Active.Documents.Select(Extensions.System))
            {
                nodeSystems.Nodes.Add(createNode(document));
            }

            

            this.rootWorkplace.Nodes.Add(nodeSystems);
            this.rootWorkplace.Nodes.Add(nodeSystems);
            this.rootWorkplace.Nodes.Add(nodeSystems);
            this.treeViewWorkplace.Nodes.Add(rootWorkplace);
            this.treeViewWorkplace.ExpandAll();
            this.treeViewWorkplace.ResumeLayout(true);
        }

        private void showDirectoryView()
        {
            this.treeViewWorkplace.SuspendLayout();

            rootWorkplace.Text = Workplace.Active.Name;
            rootWorkplace.Tag = Workplace.Active;

            treeViewWorkplace.Nodes.Clear();


            this.treeViewWorkplace.Nodes.Add(rootWorkplace);
            this.treeViewWorkplace.ExpandAll();
            this.treeViewWorkplace.ResumeLayout(true);
        }


        private TreeNode createNode(SinapseDocumentInfo document)
        {
            TreeNode node = new TreeNode(document.Name);
            node.Tag = document;

            if      (document.Type.IsAssignableFrom(typeof(ISource)))
            {
                node.ImageKey         = "Source";
                node.SelectedImageKey = "Source";
            }
            else if (document.Type.IsAssignableFrom(typeof(ISystem)))
            {
                node.ImageKey         = "System";
                node.SelectedImageKey = "System";
            }
            else if (document.Type.IsAssignableFrom(typeof(ISession)))
            {
                node.ImageKey         = "Session";
                node.SelectedImageKey = "Session";
            }

            return node;
        }



        #region Menu Events
        private void menuSourceAddTable_Click(object sender, EventArgs e)
        {           
/*
            // Tell listeners we double clicked a workplace entry (request open)
            this.OnWorkplaceContentDoubleClicked(new WorkplaceContentDoubleClickedEventArgs(item));
 */ 
        }

        private void menuSystemAddNetworkActivation_Click(object sender, EventArgs e)
        {
/*
            WorkplaceComponentInfo item = new WorkplaceComponentInfo(Workplace.Active, "New item", typeof(NetworkSystem));
            Workplace.Active.AdaptiveSystems.Add(item);

            // Tell listeners we double clicked a workplace entry (request open)
            this.OnWorkplaceContentDoubleClicked(new WorkplaceContentDoubleClickedEventArgs(item));
*/ 
        }

        private void menuSystemAddNetworkDistance_Click(object sender, EventArgs e)
        {

        }
        #endregion





        #region Protected Methods (For Events)
        protected void OnWorkplaceContentDoubleClicked(WorkplaceContentDoubleClickedEventArgs e)
        {
            if (this.WorkplaceContentDoubleClicked != null)
                this.WorkplaceContentDoubleClicked.Invoke(this, e);
        }
        #endregion

        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }



    }




    #region Event Delegates & Arguments
    public delegate void WorkplaceContentDoubleClickedEventHandler(object sender, WorkplaceContentDoubleClickedEventArgs e);
    
    public sealed class WorkplaceContentDoubleClickedEventArgs : EventArgs
    {
        private SinapseDocumentInfo workplaceContent;

        public SinapseDocumentInfo WorkplaceItem
        {
            get { return workplaceContent; }
            set { workplaceContent = value; }
        }
        public WorkplaceContentDoubleClickedEventArgs(SinapseDocumentInfo item)
        {
            this.workplaceContent = item;
        }
    }
    #endregion

}
