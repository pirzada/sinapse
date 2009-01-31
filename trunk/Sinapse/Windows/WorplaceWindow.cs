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
using System.IO;

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

        private TreeNode nodeWorkplace;

        public event WorkplaceContentDoubleClickedEventHandler WorkplaceContentDoubleClicked;



        #region Constructor
        public WorkplaceWindow()
        {
            InitializeComponent();

            nodeWorkplace = new TreeNode("Workplace", 0, 0);           

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
            this.createTree();
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
  //          this.populateTreeView();
        }
        #endregion




        #region Tree Creation
        private void createTree()
        {
            treeViewWorkplace.SuspendLayout();

            nodeWorkplace.Text = Workplace.Active.Name;
            nodeWorkplace.Tag = Workplace.Active;
            
            treeViewWorkplace.Nodes.Clear();

            createTree(Workplace.Active.Root.FullName, nodeWorkplace);                        

            treeViewWorkplace.Nodes.Add(nodeWorkplace);
            treeViewWorkplace.ExpandAll();
            treeViewWorkplace.ResumeLayout(true);
        }

        private void createTree(string dir, TreeNode root)
        {
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);
            
            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node
                TreeNode node = new TreeNode(d.Name);

                // populate the new node recursively
                createTree(d.FullName, node);
                root.Nodes.Add(node); 
            }

            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                // create a new node
                SinapseDocumentInfo documentInfo = new SinapseDocumentInfo(Path.Combine(dir, f.Name), true);
                Workplace.Active.Documents.Add(documentInfo);
                TreeNode node = createNode(documentInfo);

                // add it to the root node
                root.Nodes.Add(node);
            }
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
        #endregion



        #region Menu Events
        private void menuAddSourceTable_Click(object sender, EventArgs e)
        {
            new Sinapse.Forms.Dialogs.NewDocumentDialog(typeof(ISource)).ShowDialog();
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
