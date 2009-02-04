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
using Sinapse.WinForms;
using Sinapse.WinForms.Documents;
using Sinapse.WinForms.Training;

using Sinapse.WinForms.Dialogs;

using Sinapse.Core;
using Sinapse.Core.Sources;
using Sinapse.Core.Systems;
using Sinapse.Core.Training;

using Sinapse.WinForms.Core;



namespace Sinapse.WinForms
{

    internal sealed partial class MainForm : Form
    {

        private Workbench workbench;


        //---------------------------------------------


        #region Constructor & Destructor
        public MainForm()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            workbench = new Workbench(this.dockMain);
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

                // Fix ToolStrip
                ToolStripManager.LoadSettings(this);

                // Load Workbench Layout
                workbench.LoadLayout();
                workbench.MruDocuments = this.mruProviderDocuments;
                workbench.MruWorkplace = this.mruProviderWorkplace;

                // Show Start Page (if configured to do so)
                if (Properties.Settings.Default.behaviour_ShowStartPage)
                {
                    StartPage page = new StartPage(workbench);
                    page.Show(this.dockMain, DockState.Document);
                }
                
                // Wire-up some events
                this.workbench.WorkplaceOpened += new EventHandler(Workbench_WorkplaceChanged);

                HistoryListener.Write("Sinapse Interface Loaded");
            }
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            HistoryListener.Write("Exiting...");

            base.OnClosing(e);
            
            // Close Workbench


            // Close Workplace, always asking for confirmation
            if (!workbench.CloseAllDocuments(true))
            {
                e.Cancel = true;
                return;
            }


            // Save ToolStripPanels
            ToolStripManager.SaveSettings(this);

            // Save Workbench Layout
            workbench.SaveLayout();

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




        #region Workplace Events
        private void Workbench_WorkplaceChanged(object sender, EventArgs e)
        {
            if (workbench.Workplace == null)
            {
                MenuWorkplace.Visible = false;
            }
            else
            {
                MenuWorkplace.Visible = true;
            }
        }
        #endregion



        //---------------------------------------------


        #region Menu File
        /// <summary>
        ///   Handling for Menu -> File -> New-> Workplace
        /// </summary>
        private void MenuFileNewWorkplace_Click(object sender, EventArgs e)
        {
            new NewWorkplaceDialog(workbench).ShowDialog(this);
        }

        /// <summary>
        ///   Handling for Menu -> File -> Open -> Workplace
        /// </summary>
        private void MenuFileOpenWorkplace_Click(object sender, EventArgs e)
        {
            workbench.ShowOpenWorkplaceDialog();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Close Workplace
        /// </summary>
        private void MenuFileCloseWorkplace_Click(object sender, EventArgs e)
        {
            workbench.CloseWorkplace();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save
        /// </summary>
        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            workbench.ActiveDocumentView.Save();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save As
        /// </summary>
        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            workbench.ActiveDocumentView.SaveAs();
        }

        /// <summary>
        ///   Handling for Menu -> File -> Save All
        /// </summary>
        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            this.workbench.SaveAll();
        }
        #endregion


        #region Menu Workplace
        private void MenuWorkplaceAddDataSource_Click(object sender, EventArgs e)
        {
           new NewDocumentDialog(workbench, typeof(ISource)).ShowDialog(this);
        }

        private void MenuWorkplaceAddAdaptiveSystem_Click(object sender, EventArgs e)
        {
            new NewDocumentDialog(workbench, typeof(ISystem)).ShowDialog(this);
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
            workbench.OpenWorkplace(filename);
        }

        private void mruProviderDocuments_MenuItemClicked(string filename)
        {
            workbench.OpenDocument(filename);
        }
        #endregion

        private void MenuViewProperties_Click(object sender, EventArgs e)
        {
            workbench.PropertyWindow.Show(dockMain);
        }

        private void MenuViewWorkplace_Click(object sender, EventArgs e)
        {
            workbench.WorkplaceWindow.Show(dockMain);
        }


    }
}