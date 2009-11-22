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


        private TreeNode nodeWorkplace;



        #region Constructor
        public WorkplaceExplorer(Workbench workbench) : base(workbench)
        {
            InitializeComponent();

            nodeWorkplace = new TreeNode("Workplace");
            nodeWorkplace.ImageKey = ".workplace";
            nodeWorkplace.SelectedImageKey = ".workplace";
            nodeWorkplace.ContextMenuStrip = workplaceContextMenu;

            Workbench.WorkplaceOpened += new EventHandler(Workbench_WorkplaceChanged);
            Workbench.WorkplaceClosed += new EventHandler(Workbench_WorkplaceChanged);
            SelectionChanged += new TreeViewEventHandler(WorkplaceExplorer_SelectionChanged);
        }

        private void WorkplaceExplorer_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            if (treeViewWorkplace.SelectedNode != null)
            {
                Workbench.PropertyWindow.SelectedObject = treeViewWorkplace.SelectedNode.Tag;    
            }
        }
        #endregion




        #region Properties
        /// <summary>
        ///   Gets the current selected WorkplaceContent on the Workplace Window
        /// </summary>
        public FileSystemProperties SelectedFile
        {
            get
            {
                if (this.treeViewWorkplace.SelectedNode != null)
                {
                    object tag = this.treeViewWorkplace.SelectedNode.Tag;

                    if (tag is FileSystemProperties)
                        return tag as FileSystemProperties;
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


        private void treeViewWorkplace_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewWorkplace.SelectedNode = e.Node;
        }

        private void treeViewWorkplace_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            object tag = e.Node.Tag;

            if (tag is FileProperties)
            {
                string fileName = (tag as FileProperties).FullName;
                this.Workbench.OpenDocument(fileName);
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
            nodeWorkplace.Tag = new FolderProperties(Workbench.Workplace.Root.FullName);
            nodeWorkplace.Nodes.Clear();
            treeViewWorkplace.Nodes.Clear();

            createTree(Workbench.Workplace.Root.FullName, String.Empty, nodeWorkplace);
            
            treeViewWorkplace.Nodes.Add(nodeWorkplace);
            treeViewWorkplace.TopNode = nodeWorkplace;
            treeViewWorkplace.ExpandAll();
            treeViewWorkplace.ResumeLayout(true);
        }

        private void createTree(string rootPath, string dirPath, TreeNode root)
        {
            
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(rootPath, dirPath));
            
            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node to represent the directory
                TreeNode node = new TreeNode(d.Name);
                node.ContextMenuStrip = folderContextMenu;
                node.Tag = new FolderProperties(dirPath, rootPath);

                // populate the new node recursively
                createTree(rootPath, Path.Combine(dirPath, d.Name), node);

                root.Nodes.Add(node); 
            }

            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                if (f.Extension.Equals(".workplace", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                TreeNode node = new TreeNode(f.Name);
                node.ContextMenuStrip = documentContextMenu;
                node.Tag = new FileProperties(Path.Combine(dirPath, f.Name), rootPath);

                string extension = Utils.GetExtension(f.Name, true);
                node.ImageKey = extension;
                node.SelectedImageKey = extension;
                    
                // add it to the root node
                root.Nodes.Add(node);
               
            }
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







        private void ContextMenuCut_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuCopy_Click(object sender, EventArgs e)
        {
        }

        private void ContextMenuPaste_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuDelete_Click(object sender, EventArgs e)
        {
            if (treeViewWorkplace.SelectedNode != null)
            {
                if (treeViewWorkplace.SelectedNode.Tag is FileSystemProperties)
                {
                    (treeViewWorkplace.SelectedNode.Tag as FileSystemProperties).Delete();
                }
               
                createTree();
            }
        }

        private void ContextMenuRename_Click(object sender, EventArgs e)
        {
            treeViewWorkplace.SelectedNode.BeginEdit();
        }

        private void ContextMenuOpenExplorer_Click(object sender, EventArgs e)
        {
            if (SelectedFile != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", SelectedFile.FullName);
            }
        }
       

        private void treeViewWorkplace_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit)
                return;

            if (e.Node.Tag is FileSystemProperties)
            {
                FileSystemProperties file = treeViewWorkplace.SelectedNode.Tag as FileSystemProperties;
                if (e.Label.Equals(Path.GetFileName(file.FullName)))
                    return;

                file.MoveTo(Path.Combine(file.FullName, e.Label));
            }
        }

       

    }

}
