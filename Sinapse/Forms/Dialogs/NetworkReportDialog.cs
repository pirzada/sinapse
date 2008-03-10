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
using System.Diagnostics;
using System.IO;


using AForge.Neuro;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Data.Reporting;


namespace Sinapse.Forms.Dialogs
{

    internal sealed partial class NetworkReportDialog : Form
    {

        private NetworkContainer m_network;
        private NetworkDatabase m_database;

        //----------------------------------------


        #region Constructor
        internal NetworkReportDialog(NetworkContainer networkContainer, NetworkDatabase networkDatabase)
        {
            this.m_database = networkDatabase;
            this.m_network = networkContainer;

            this.InitializeComponent();
        }
        #endregion


        //----------------------------------------


        #region Form Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                // Set form Sizing and Location
                if (!Properties.Settings.Default.report_FirstLoad)
                {
                    this.Size = Properties.Settings.Default.report_Size;
                    this.Location = Properties.Settings.Default.report_Location;
                    this.WindowState = Properties.Settings.Default.report_WindowState;
                }

                // Set default report filename
                this.saveFileDialog.FileName = m_network.Name + " Report";
            }

            this.CreateReport();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // Save settings before closing
            Properties.Settings.Default.report_FirstLoad = false;
            Properties.Settings.Default.report_WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.report_Size = this.Size;
                Properties.Settings.Default.report_Location = this.Location;
            }
            else
            {
                Properties.Settings.Default.report_Size = this.RestoreBounds.Size;
                Properties.Settings.Default.report_Location = this.RestoreBounds.Location;
            }

        }
        #endregion


        //----------------------------------------


        #region Form Buttons
        private void btnRun_Click(object sender, EventArgs e)
        {
            this.CreateReport();
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            new NetworkReportOptionsDialog().ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowPrintDialog();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowPrintPreviewDialog();
        }

        private void btnPrintOptions_Click(object sender, EventArgs e)
        {
            this.webBrowser.ShowPageSetupDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog(this);
        }

        
        #endregion


        //----------------------------------------


        #region File Save Dialog
        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TextWriter textWriter = null;

            try
            {
                textWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default);
                textWriter.Write(this.webBrowser.DocumentText);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving testing report: " + ex.Message);
#if DEBUG
                throw ex;
#endif
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }
        #endregion

        
        //----------------------------------------


        #region Public Methods
        public void CreateReport()
        {
            lbStatus.Text = "Generating...";
            this.backgroundWorker.RunWorkerAsync();
        }
        #endregion


        //----------------------------------------


        #region WebBrowser Events
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.progressBar.Value = 0;
        }
        #endregion


        //----------------------------------------


        #region Background Thread
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportGenerator reportGenerator;
            backgroundWorker.ReportProgress(0);

            reportGenerator = new ReportGenerator(m_network, m_database);
            backgroundWorker.ReportProgress(10);

            reportGenerator.GenerateHeader();
            backgroundWorker.ReportProgress(15);

            reportGenerator.GenerateNetworkDetails();
            backgroundWorker.ReportProgress(20);

            reportGenerator.GenerateSchemaDetails();
            backgroundWorker.ReportProgress(30);

            reportGenerator.GenerateTrainingDetails();
            backgroundWorker.ReportProgress(40);

            reportGenerator.GenerateTestingSummary();
            backgroundWorker.ReportProgress(50);

            reportGenerator.GenerateTestingDetails();
            backgroundWorker.ReportProgress(60);

            reportGenerator.GenerateNormalization();
            backgroundWorker.ReportProgress(70);

            reportGenerator.GenerateWeights();
            backgroundWorker.ReportProgress(80);

            reportGenerator.GenerateFooter();
            backgroundWorker.ReportProgress(90);

            e.Result = reportGenerator.Report;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.webBrowser.Created)
                this.webBrowser.DocumentText = e.Result as string;

            this.progressBar.Value = 100;
            this.lbStatus.Text = "Done.";
        }
        #endregion

    }
}