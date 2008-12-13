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
                
                HistoryListener.Write("Waiting data");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            HistoryListener.Write("Exiting...");

            // Stops any thread that could be running before exiting
      //      if (this.tabControlSide.TrainerControl.IsTraining)
      //          this.tabControlSide.TrainerControl.Stop();


            /*           // Asks user if unsaved changes should be saved on exiting
                       if (this.m_networkContainer != null && this.m_networkContainer.HasUnsavedChanges)
                       {
                           DialogResult r = MessageBox.Show("The current network has been modified. Would you like to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                           if (r == DialogResult.Yes)
                           {
                               this.MenuNetworkSave_Click(this, EventArgs.Empty);
                           }
                           else if (r == DialogResult.Cancel)
                           {
                               e.Cancel = true;
                               return;
                           }                   
                       }

                       if (this.m_networkDatabase != null && this.m_networkDatabase.HasUnsavedChanges)
                       {
                           DialogResult r = MessageBox.Show("The current database has been modified. Would you like to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                           if (r == DialogResult.Yes)
                           {
                               this.MenuDatabaseSave_Click(this, EventArgs.Empty);
                           }
                           else if (r == DialogResult.Cancel)
                           {
                               e.Cancel = true;
                               return;
                           }
                       }
                    */

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
            if (this.windowProperties != null)
                this.windowProperties.PropertyGrid.SelectedObject = this.windowWorkplace.SelectedItem;
        }

        private void windowWorkplace_SelectionChanged(object sender, TreeViewEventArgs e)
        {
            if (this.windowProperties != null)
                this.windowProperties.PropertyGrid.SelectedObject = this.windowWorkplace.SelectedItem;
        }

        private void windowWorkplace_WorkplaceContentDoubleClicked(object sender, WorkplaceContentDoubleClickedEventArgs e)
        {
            if (e.WorkplaceContent.Type == typeof(TableDataSource))
            {
                TableDataSourceEditor editor = new TableDataSourceEditor(e.WorkplaceContent.Open() as TableDataSource);
                editor.Show(this.dockMain, DockState.Document);
            }
            else if (e.WorkplaceContent.Type == typeof(NetworkSystem))
            {
                NetworkSystemEditor editor = new NetworkSystemEditor(e.WorkplaceContent.Open() as ActivationNetworkSystem);
                editor.Show(this.dockMain, DockState.Document);
            }
            else if (e.WorkplaceContent.Type == typeof(BackpropagationTrainingSession))
            {
                BackpropagationTrainingSession session = e.WorkplaceContent.Open() as BackpropagationTrainingSession;
                TrainingSessionEditor editor = new TrainingSessionEditor(session);
                editor.SavepointsWindow.Show(this.dockMain, DockState.DockRight);
                editor.ControllerWindow.Show(this.dockMain);

                editor.ControllerWindow.DockHandler.FloatPane.DockTo(this.dockMain.DockWindows[DockState.DockRight]);           
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

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (this.dockMain.ActiveDocument is IWorkplaceDocument)
            {
                (this.dockMain.ActiveDocument as IWorkplaceDocument).Save();
            }
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (this.dockMain.ActiveDocument is IWorkplaceDocument)
            {
                (this.dockMain.ActiveDocument as IWorkplaceDocument).SaveAs();
            }
        }

        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            foreach (IWorkplaceDocument doc in this.dockMain.Documents)
            {
                doc.Save();
            }
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


        #region ToolStripMenu Training
        private void btnTrainStart_Click(object sender, EventArgs e)
        {
  //          this.tabControlSide.TrainerControl.Start();
        }

        private void btnTrainStop_Click(object sender, EventArgs e)
        {
  //          this.tabControlSide.TrainerControl.Stop();
        }

        private void btnTrainPause_Click(object sender, EventArgs e)
        {
  //          this.tabControlSide.TrainerControl.Pause();
        }

        private void btnTrainForget_Click(object sender, EventArgs e)
        {
   //         this.tabControlSide.TrainerControl.Forget();
        }

        private void btnTrainNext_Click(object sender, EventArgs e)
        {
            //   this.tabControlSide.TrainerControl.Start();
        }

        private void btnTrainBack_Click(object sender, EventArgs e)
        {

        }

        private void btnTrainGraph_Click(object sender, EventArgs e)
        {
  //          this.tabControlMain.GraphControl.ShowTab();
        }
        #endregion


        #region ToolStripMenu Testing
        private void btnTestCompute_Click(object sender, EventArgs e)
        {
  //          if (this.tabControlMain.SelectedControl != this.tabControlMain.TestingSetControl)
  //              this.tabControlMain.TestingSetControl.ShowTab();

  //          this.tabControlMain.TestingSetControl.Compute();
        }

        private void btnTestReport_Click(object sender, EventArgs e)
        {
  //          this.tabControlMain.TestingSetControl.Compare();
        }

        private void btnTestRound_Click(object sender, EventArgs e)
        {
            /*if (this.tabControlMain.SelectedControl != this.tabControlMain.TestingSetControl)
                this.tabControlMain.TestingSetControl.ShowTab();
            */
            ToolStripMenuItem item = (sender as ToolStripMenuItem);
            
            if (item.Tag is Single)
            {
                float value = (float)item.Tag;

  //              if (this.tabControlMain.SelectedControl is Sinapse.Controls.MainTabControl.TabPageTesting)
  //                  this.tabControlMain.TestingSetControl.NetworkDatabase.Round(true, value);
  //              else if (this.tabControlMain.SelectedControl is Sinapse.Controls.MainTabControl.TabPageQuery)
  //                  this.tabControlMain.QueryControl.NetworkDatabase.Round(false, value);
            }
        }


        #endregion


        //---------------------------------------------


        #region File Dialogs
        private void openNetworkDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.networkOpen(openNetworkDialog.FileName);
        }


        private void openDatabaseDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.databaseOpen(openDatabaseDialog.FileName);
        }

        private void mruProviderDatabase_MenuItemClicked(string filename)
        {
            this.databaseOpen(filename);
        }

        private void mruProviderNetwork_MenuItemClicked(string filename)
        {
            this.networkOpen(filename);
        }

        private void mruProviderWorkplace_MenuItemClicked(string filename)
        {
            this.workplaceOpen(filename);
        }

        private void mruProviderSession_MenuItemClicked(string filename)
        {
            this.sessionOpen(filename);
        }
        #endregion


        //---------------------------------------------


        #region Open & Save Network
        private void networkSave(string path)
        {
            try
            {
 //               NetworkContainer.Serialize(this.CurrentNetworkContainer, path);
                this.mruProviderSystem.Insert(path);
                HistoryListener.Write("Network Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving network");
#if DEBUG
                throw;
#endif
            }
        }

        private void networkOpen(string path)
        {
   //         NetworkContainer neuralNetwork = null;

            try
            {
     //           neuralNetwork = NetworkContainer.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening network");
#if DEBUG
                throw;
#endif
            }
            finally
            {
    /*            if (neuralNetwork != null)
                {
                    neuralNetwork.WireUpEvents();
        //            this.CurrentNetworkContainer = neuralNetwork;
                    this.mruProviderNetwork.Insert(path);
                    HistoryListener.Write("Network Loaded");

                    if (m_networkDatabase == null && File.Exists(Path.ChangeExtension(path,".sdo")))
                    {
                        if (MessageBox.Show("Sinapse detected a database with the same name as this network. " +
                            "Would you like to load this database too?", "Matching database found", MessageBoxButtons.YesNo)
                            == DialogResult.Yes)
                        {
                            this.databaseOpen(Path.ChangeExtension(path, ".sdo"));
                        }
                    }
                }
     */ 
            }
        }
        #endregion


        #region Open & Save Database
        private void databaseSave(string path)
        {
            try
            {
          //      NetworkDatabase.Serialize(this.CurrentNetworkDatabase, path);
                this.mruProviderDatasource.Insert(path);
                HistoryListener.Write("Database Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving database");
#if DEBUG
                throw;
#endif
            }
         
        }

        private void databaseOpen(string path)
        {
    //        NetworkDatabase networkDatabase = null;

            try
            {
    //            networkDatabase = NetworkDatabase.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening database");
#if DEBUG
                throw;
#endif
            }
            finally
            {
       /*         if (networkDatabase != null)
                {
    //                this.CurrentNetworkDatabase = networkDatabase;
                    this.mruProviderDatabase.Insert(path);
                    HistoryListener.Write("Database Loaded");

    //                if (m_networkContainer == null && File.Exists(Path.ChangeExtension(path, ".ann")))
                    {
                        if (MessageBox.Show("Sinapse detected a network with the same name as this database. " +
                            "Would you like to load this network too?", "Matching network found", MessageBoxButtons.YesNo)
                            == DialogResult.Yes)
                        {
                            this.networkOpen(Path.ChangeExtension(path, ".ann"));
                        }
                    }
                }
        */ 
            }
        }
        #endregion


        #region Open & Save Workplace
        private void workplaceSave(string path)
        {
            try
            {
      //          NetworkWorkplace.Serialize(this.CurrentNetworkWorkplace, path);
                this.mruProviderWorkplace.Insert(path);
                HistoryListener.Write("Workplace Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving workplace");
#if DEBUG
                throw;
#endif
            }

        }

        private void workplaceOpen(string path)
        {
    //        NetworkWorkplace networkWorkplace = null;

            try
            {
                //          networkWorkplace = NetworkWorkplace.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening workplace");
#if DEBUG
                throw;
#endif
            }
            finally
            {
                /*           if (networkWorkplace != null)
                           {
                   //            this.CurrentNetworkWorkplace = networkWorkplace;
                               this.mruProviderWorkplace.Insert(path);
                               HistoryListener.Write("Workplace Loaded");
                           }
                       }
                 */
            }
        }
     
        #endregion


        #region Open & Save Session
        private void sessionSave(string path)
        {
            try
            {
     //           TrainingSession.Serialize(this.CurrentTrainingSession, path);
                this.mruProviderTrainingSession.Insert(path);
                HistoryListener.Write("Training Session Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error saving trainng session");
#if DEBUG
                throw;
#endif
            }

        }

        private void sessionOpen(string path)
        {
  //          TrainingSession trainingSession = null;

            try
            {
  //              trainingSession = TrainingSession.Deserialize(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening training session");
#if DEBUG
                throw;
#endif
            }
            finally
            {
   /*             if (trainingSession != null)
                {
     //               this.CurrentTrainingSession = trainingSession;
                    this.mruProviderSession.Insert(path);
                    HistoryListener.Write("Training Session Loaded");
                }
    */ 
            }
        }

        #endregion


        //---------------------------------------------


        #region Private Methods
        private void createSession()
        {
    //        if (this.m_networkDatabase != null && m_networkContainer != null)
            {
    //            this.CurrentTrainingSession = new TrainingSession("New session", this.m_networkDatabase, this.m_networkContainer);
            }
        }
        #endregion




/*
        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sinapse.Documents.NetworkSystemEditor document = new NetworkSystemEditor(new Sinapse.Core.Systems.ActivationNetworkSystem());
            document.Show(this.dockMain, DockState.Document);
        }

        */


    }
}