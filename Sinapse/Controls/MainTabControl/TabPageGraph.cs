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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Forms.Dialogs;


namespace Sinapse.Controls.MainTabControl
{
    internal sealed partial class TabPageGraph : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkContainer m_networkContainer;
        private IPointListEdit m_trainingPoints;
        private IPointListEdit m_validationPoints;
        private IPointListEdit m_savePoints;

        private SideTabControl.SidePageTrainer m_networkTrainer;


        //----------------------------------------


        #region Constructor
        internal TabPageGraph()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer,
              true);


            this.TabPageName = "Training History";
            this.dataGridView.AutoGenerateColumns = false;
            this.CreateChart(zedGraphControl);
        }
        #endregion


        //----------------------------------------


        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal NetworkContainer NetworkContainer
        {
            get { return this.m_networkContainer; }
            set
            {
                this.m_networkContainer = value;

                if (value != null && this.NetworkTrainer.NetworkDatabase != null)
                {
                    this.setTabPageEnabled(true);
                    this.dataGridView.DataSource = this.m_networkContainer.Savepoints;
                    this.m_networkContainer.Savepoints.SavepointRegistered += networkContainer_savepointRegistered;
                    this.m_networkContainer.Savepoints.SavepointRestored += networkContainer_savepointRestored;
                }
                else
                {
                    this.setTabPageEnabled(false);
                    this.dataGridView.DataSource = null;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal SideTabControl.SidePageTrainer NetworkTrainer
        {
            get { return this.m_networkTrainer; }
            set { this.m_networkTrainer = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IPointListEdit TrainingPoints
        {
            get { return this.m_trainingPoints; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IPointListEdit ValidationPoints
        {
            get { return this.m_validationPoints; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IPointListEdit SavePoints
        {
            get { return this.m_savePoints; }
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            NetworkSavepoint save = (this.dataGridView.Rows[e.RowIndex].DataBoundItem as NetworkSavepoint);

            if (save != null)
                this.m_networkContainer.Savepoints.Restore(save);
        }

        private void networkContainer_savepointRegistered(object sender, EventArgs e)
        {
            this.SavePoints.Add(this.m_networkContainer.Savepoints.CurrentSavepoint.Epoch,
                this.m_networkContainer.Savepoints.CurrentSavepoint.ErrorTraining);

            HistoryListener.Write("Savepoint Registered!");
        }

        private void networkContainer_savepointRestored(object sender, EventArgs e)
        {
            HistoryListener.Write("Savepoint Restored!");
        }

        private void zedGraphControl_DoubleClick(object sender, EventArgs e)
        {
            if (!GraphOptionsDialog.HasInstance)
            {
                new GraphOptionsDialog().Show(this);
            }
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateGraph();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearGraph();
        }

        private void btnSavepointLoad_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentRow != null)
            {
                NetworkSavepoint save = (this.dataGridView.CurrentRow.DataBoundItem as NetworkSavepoint);

                if (save != null)
                    this.m_networkContainer.Savepoints.Restore(save);
            }
        }

        private void btnSavepointMark_Click(object sender, EventArgs e)
        {
            this.m_networkContainer.Savepoints.Register(m_networkTrainer.NetworkState);
        }

        private void btnSavepointClear_Click(object sender, EventArgs e)
        {
            this.m_networkContainer.Savepoints.Clear();
        }
        #endregion


        //----------------------------------------


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
            this.SavePoints.Clear();
            this.UpdateGraph();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void CreateChart(ZedGraphControl zgc)
        {

            GraphPane myPane = zgc.GraphPane;

            // Set the title and axis labels
            myPane.Title.Text = "Training Graph";
            myPane.XAxis.Title.Text = "Epochs";
            myPane.YAxis.Title.Text = "Root-Mean-Square Error";

            RollingPointPairList trainingList = new RollingPointPairList(1200);
            RollingPointPairList validationList = new RollingPointPairList(1200);
            RollingPointPairList savepointList = new RollingPointPairList(1200);

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


            curve = myPane.AddCurve("Savepoints Mark", savepointList, Color.DarkGreen, SymbolType.Star);
            curve.Symbol.Fill = new Fill(Color.DarkGreen);
            curve.Symbol.Size = 5;
            curve.Line.IsVisible = false;
            m_savePoints = curve.Points as IPointListEdit;
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
        #endregion


        //----------------------------------------

    }
}
