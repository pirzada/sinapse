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
using Sinapse.Core.Documents;
using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Training;

using Sinapse.WinForms.Dialogs;
using Sinapse.WinForms.Core;

namespace Sinapse.WinForms.ToolWindows
{

    public partial class WorkplaceExplorer : ToolWindow
    {

      //  private bool directoryView = true;

        private TreeNode nodeWorkplace;



        #region Constructor
        public WorkplaceExplorer(Workbench workbench) : base(workbench)
        {
            InitializeComponent();

            nodeWorkplace = new TreeNode("Workplace");
            nodeWorkplace.ImageKey = ".workplace";
            nodeWorkplace.SelectedImageKey = ".workplace";

            Workbench.WorkplaceOpened += new EventHandler(Workbench_WorkplaceChanged);
            Workbench.WorkplaceClosed += new EventHandler(Workbench_WorkplaceChanged);
            SelectionChanged += new TreeViewEventHandler(WorkplaceExplorer_SelectionChanged);
        }

        private void WorkplaceExplorer_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            if (this.SelectedItem != null)
                Workbench.PropertyWindow.SelectedObject = this.SelectedItem;
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

        public new event EventHandler DocumentDoubleClicked
        {
            add { this.treeViewWorkplace.DoubleClick += value; }
            remove { this.treeViewWorkplace.DoubleClick -= value; }
        }
        #endregion




        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IconCache.CreateList(imageList);
            Workbench_WorkplaceChanged(null, EventArgs.Empty);
        }

        private void treeViewWorkplace_DoubleClick(object sender, EventArgs e)
        {
            object tag = this.treeViewWorkplace.SelectedNode.Tag;

            if (tag is SinapseDocumentInfo)
            {
                this.Workbench.OpenDocument(tag as SinapseDocumentInfo);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.createTree();
        }
        #endregion




        #region Workplace Events
        private void Workbench_WorkplaceChanged(object sender, EventArgs e)
        {
            // If we have an active workplace,
            if (Workbench.Workplace != null)
            {
                this.Enabled = true;

                // Lets hide the "Nothing to show" label and populate the tree view
                this.lbNothingToShow.Hide();
                this.treeViewWorkplace.Enabled = true;

                this.createTree(); // Create the TreeView

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

            nodeWorkplace.Text = Workbench.Workplace.Name;
            nodeWorkplace.Tag = Workbench.Workplace;
            
            treeViewWorkplace.Nodes.Clear();

            createTree(Workbench.Workplace.Root.FullName, nodeWorkplace);
            
            treeViewWorkplace.Nodes.Add(nodeWorkplace);
            treeViewWorkplace.TopNode = nodeWorkplace;
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
                // get file information
                SinapseDocumentInfo documentInfo = new SinapseDocumentInfo(Path.Combine(dir, f.Name), Workbench.Workplace);
                
                // Verify if it is not of Workplace type
                if (documentInfo.Type != typeof(Workplace))
                {
                   // Workplace.Active.Documents.Add(documentInfo);
                    TreeNode node = createNode(documentInfo);
                    
                    // add it to the root node
                    root.Nodes.Add(node);
                }
            }
        }


        private TreeNode createNode(SinapseDocumentInfo document)
        {
            TreeNode node = new TreeNode();

            node.Name = document.Name;
            node.Text = document.Name;
            node.Tag = document;

            if (document.Type != null)
            {
                string extension = DocumentManager.GetExtension(document.Type);
                node.ImageKey = extension;
                node.SelectedImageKey = extension;
            }
            else
            {
                node.ImageKey = "null";
                node.SelectedImageKey = "null";
            }

            return node;
        }
        #endregion



        #region Menu Events
        private void menuAddDocument_Click(object sender, EventArgs e)
        {
            new Sinapse.WinForms.Dialogs.NewDocumentDialog(Workbench, typeof(ISource));
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





        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            SinapseDocumentInfo selection = this.SelectedItem;
            
            if (selection != null)
            {
             if (typeof(ISource).IsAssignableFrom(selection.Type))
                MessageBox.Show("ISource");
             if (typeof(ISession).IsAssignableFrom(selection.Type))
                 MessageBox.Show("ISession");
             if (typeof(ISystem).IsAssignableFrom(selection.Type))
                 MessageBox.Show("ISystem");
            }
        }



    }

}
