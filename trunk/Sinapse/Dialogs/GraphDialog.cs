/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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

using ZedGraph;

namespace Sinapse.Dialogs
{

    internal sealed partial class GraphDialog : Form
    {

        IPointListEdit m_trainingPoints;
        IPointListEdit m_validationPoints;

        Boolean m_forceClose;
        

        //---------------------------------------------


        #region Constructor
        public GraphDialog()
        {
            InitializeComponent();

            this.CreateChart(zedGraphControl);
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public IPointListEdit TrainingPoints
        {
            get { return m_trainingPoints; }
        }

        public IPointListEdit ValidationPoints
        {
            get { return m_validationPoints; }
        }

        public Boolean AutoUpdate
        {
            get { return cbAutoupdate.Checked; }
            set { cbAutoupdate.Checked = value; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        internal void UpdateGraph()
        {
            this.zedGraphControl.AxisChange();
            this.zedGraphControl.Invalidate();
            this.Invalidate();
        }

        internal void ClearGraph()
        {
            this.TrainingPoints.Clear();
            this.ValidationPoints.Clear();
            this.UpdateGraph();
        }

        internal new void Close()
        {
            this.m_forceClose = true;
            base.Close();
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateGraph();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearGraph();
        }
        #endregion


        //---------------------------------------------


        #region Form Events
        private void GraphDialog_Load(object sender, EventArgs e)
        {
            // Load form sizing and location
            this.Size = Properties.Settings.Default.graph_Size;
            this.Location = Properties.Settings.Default.graph_Location;
        }

        private void GraphDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save form sizing and location
            Properties.Settings.Default.main_Size = this.Size;
            Properties.Settings.Default.main_Location = this.Location;

            if (!this.m_forceClose)
            {
                e.Cancel = true;
                if (this.ParentForm != null)
                    this.ParentForm.Focus();
                this.Hide();
            }
        }
        #endregion


        //---------------------------------------------


        private void CreateChart(ZedGraphControl zgc)
        {

            GraphPane myPane = zgc.GraphPane;

            // Set the title and axis labels
            myPane.Title.Text = "Training Graph";
            myPane.XAxis.Title.Text = "Epochs";
            myPane.YAxis.Title.Text = "Root-Mean-Square Error";

            RollingPointPairList trainingList = new RollingPointPairList(1200);
            RollingPointPairList validationList = new RollingPointPairList(1200);


            // Add a curve
            LineItem curve;

            curve = myPane.AddCurve("Training Set", trainingList, Color.Red, SymbolType.Diamond);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            m_trainingPoints = curve.Points as IPointListEdit;
         // trainingCurve.Line.IsSmooth = true;
         // trainingCurve.Line.SmoothTension = 0.5F;


            curve = myPane.AddCurve("Validation Set", validationList, Color.Blue, SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            m_validationPoints = curve.Points as IPointListEdit;
         // validationCurve.Line.IsSmooth = true;
         // validationCurve.Line.SmoothTension = 0.5F;

            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = true;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

    }
}