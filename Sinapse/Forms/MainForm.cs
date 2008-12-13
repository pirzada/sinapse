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
using System.IO;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Data;
using Sinapse.Windows;
using Sinapse.Windows.Documents;
using Sinapse.Windows.Training;

using Sinapse.Forms.Dialogs;

using Sinapse.Core;
using Sinapse.Core.Sources;
using Sinapse.Core.Systems;
using Sinapse.Core.Training;



namespace Sinapse.Forms
{

    internal sealed partial class MainForm : Form
    {

        private WorkplaceWindow windowWorkplace;
        private PropertyWindow windowProperties;
        private HistoryWindow windowHistory;
        private TaskWindow windowTask;

        private Dictionary<ISinapseComponent, DockContent> openDocuments;


        //---------------------------------------------


        #region Constructor & Destructor
        public MainForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer,
              true);
            
            InitializeComponent();

            this.SuspendLayout();
            this.windowWorkplace = new WorkplaceWindow();
            this.windowWorkplace.WorkplaceContentDoubleClicked += new WorkplaceContentDoubleClickedEventHandler(windowWorkplace_WorkplaceContentDoubleClicked);
            this.windowWorkplace.GotFocus += new EventHandler(windowWorkplace_GotFocus);
            this.windowWorkplace.SelectionChanged += new TreeViewEventHandler(windowWorkplace_SelectionChanged);
            this.windowWorkplace.Show(this.dockMain, DockState.DockLeft);

            this.windowProperties = new PropertyWindow();
            this.windowProperties.Show(this.windowWorkplace.Pane, DockAlignment.Bottom, 0.4);

            this.windowHistory = new HistoryWindow();
            this.windowHistory.Show(this.dockMain, DockState.DockBottomAutoHide);

            this.windowTask = new TaskWindow();
            this.windowTask.Show(this.dockMain, DockState.DockBottomAutoHide);

            this.lbVersion.Text = "v" + Application.ProductVersion;
            this.ResumeLayout(true);


            this.openDocuments = new Dictionary<ISinapseComponent, DockContent>();
        }


        
        #endregion


        //---------------------------------------------


        #region MainForm Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                // Set form Sizing and Location
                if (!Properties.Settings.Default.main_FirstLoad)
                {
                    this.Size = Properties.Settings.Default.main_Size;
                    this.Location = Properties.Settings.Default.main_Location;
                    this.WindowState = Properties.Settings.Default.main_WindowState;
                }

                // Show Start Page (if configured to do so)
                if (Properties.Settings.Default.behaviour_ShowStartPage)
                {
                    StartPage page = new StartPage();
                    page.Show(this.dockMain, DockState.Document);
                }
                
                // Wire-up some events
                Workplace.ActiveWorkplaceChanged += new EventHandler(Workplace_ActiveWorkplaceChanged);


                HistoryListener.Write("Waiting data");
            }
        }

        private void Workplace_ActiveWorkplaceChanged(object sender, EventArgs e)
        {
            if (Workplace.Active == null)
            {
                MenuWorkplace.Visible = false;
            }
            else
            {
                MenuWorkplace.Visible = true;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            HistoryListener.Write("Exiting...");


            // Save settings before closing
            Properties.Settings.Default.main_FirstLoad = false;
            Properties.Settings.Default.main_WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.main_Size = this.Size;
                Properties.Settings.Default.main_Location = this.Location;
            }
            else
            {
                Properties.Settings.Default.main_Size = this.RestoreBounds.Size;
                Properties.Settings.Default.main_Location = this.RestoreBounds.Location;
            }
 
        }
        #endregion


        //---------------------------------------------

        #region Window Workplace Events
        private void windowWorkplace_GotFocus(object sender, EventArgs e)
        {
            // Update the property window to reflect information about the selected item
            if (this.windowProperties != null)
                this.windowProperties.PropertyGrid.SelectedObject = this.windowWorkplace.SelectedItem;
        }

        private void windowWorkplace_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            // Update the property window to reflect information about the selected item
            if (this.windowProperties != null)
                this.windowProperties.PropertyGrid.SelectedObject = this.windowWorkplace.SelectedItem;
        }

        private void windowWorkplace_WorkplaceContentDoubleClicked(object sender, WorkplaceContentDoubleClickedEventArgs e)
        {
            // A WorkplaceDocument has been double clicked
            // TODO: check if document is already open

            ISinapseComponent component;

            if (e.WorkplaceContent.Open(out component))
            {
                // The component was open succesfully
                if (e.WorkplaceContent.Type == typeof(TableDataSource))
                {
                    TableDataSourceEditor editor = new TableDataSourceEditor(component as TableDataSource);
                    editor.Show(this.dockMain, DockState.Document);
                }
                else if (e.WorkplaceContent.Type == typeof(ActivationNetworkSystem))
                {

                    NetworkSystemEditor editor = new NetworkSystemEditor(component as ActivationNetworkSystem);
                    editor.Show(this.dockMain, DockState.Document);
                }
                else if (e.WorkplaceContent.Type == typeof(BackpropagationTrainingSession))
                {
                    BackpropagationTrainingSession session = component as BackpropagationTrainingSession;
                    TrainingSessionEditor editor = new TrainingSessionEditor(session);
                    editor.SavepointsWindow.Show(this.dockMain, DockState.DockRight);
                    editor.ControllerWindow.Show(this.dockMain);
                    

                    editor.ControllerWindow.DockHandler.FloatPane.DockTo(this.dockMain.DockWindows[DockState.DockRight]);
                }
            }
            else
            {
                // The component was already open
                this.openDocuments[component].Show();
            }

        }
        #endregion


        //---------------------------------------------



        //---------------------------------------------


        #region Menu File
        /// <summary>
        ///   Handling for Menu -> File -> New-> Workplace
        /// </summary>
        private void MenuFileNewWorkplace_Click(object sender, EventArgs e)
        {
            NewWorkplaceDialog dlg = new NewWorkplaceDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Workplace.Active = dlg.Workplace;
                Workplace.Active.Save();
            }
        }

        /// <summary>
        ///   Handling for Menu -> File -> Open -> Workplace
        /// </summary>
        private void MenuFileOpenWorkplace_Click(object sender, EventArgs e)
        {
            if (openWorkplaceDialog.ShowDialog(this) == DialogResult.OK)
            {
                Workplace.Active = Workplace.Open(openWorkplaceDialog.FileName);
            }
        }

        /// <summary>
        ///   Handling for Menu -> File -> Close Workplace
        /// </summary>
        private void MenuFileCloseWorkplace_Click(object sender, EventArgs e)
        {
            if (Workplace.Active.HasChanges)
            {
                DialogResult r = MessageBox.Show(
                    "The Workplace has unsaved changes. Quit anyway?", "Unsaved changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            }
            Workplace.Active = null;
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save
        /// </summary>
        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (dockMain.ActiveDocument is IWorkplaceDocument)
            {
                (dockMain.ActiveDocument as IWorkplaceDocument).Save();
            }

            Workplace.Active.Save();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save As
        /// </summary>
        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (dockMain.ActiveDocument is IWorkplaceDocument)
            {
                (dockMain.ActiveDocument as IWorkplaceDocument).SaveAs();
            }

            Workplace.Active.Save();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save All
        /// </summary>
        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            foreach (IWorkplaceDocument doc in this.dockMain.Documents)
            {
                doc.Save();
            }

            Workplace.Active.Save();
        }
        #endregion


        #region Menu Workplace
        private void MenuWorkplaceAddDataSource_Click(object sender, EventArgs e)
        {
           new NewDataSourceDialog().ShowDialog(this);
            
        }
        #endregion


        #region Menu Help
        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void MenuHelpContents_Click(object sender, EventArgs e)
        {

        }
        #endregion


        //---------------------------------------------



        #region Most Recently Used Lists Events
        private void mruProviderWorkplace_MenuItemClicked(string filename)
        {
         //   this.workplaceOpen(filename);
        }

        private void mruProviderDocuments_MenuItemClicked(string filename)
        {
         //   this.sessionOpen(filename);
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }







    }
}