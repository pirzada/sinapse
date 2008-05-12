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

using ZedGraph;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Forms.Dialogs;


namespace Sinapse.Controls.MainTabControl
{
    internal sealed partial class TabPageLearningGraph : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkContainer m_networkContainer;
        private IPointListEdit m_trainingPoints;
        private IPointListEdit m_validationPoints;
        private IPointListEdit m_currentSavepoint;
        private IPointListEdit m_savePoints;

 //       private bool newSavepoint;

        private SideTabControl.SidePageTrainer m_networkTrainer;


        //----------------------------------------


        #region Constructor
        internal TabPageLearningGraph()
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
                    this.dataGridView.DataSource = this.m_networkContainer.Savepoints;
                    this.m_networkContainer.Savepoints.SavepointRegistered += networkContainer_savepointRegistered;
                    this.m_networkContainer.Savepoints.SavepointRestored += networkContainer_savepointRestored;
                    this.m_networkContainer.Savepoints.CurrentSavepointChanged += networkContainer_savepointChanged;
                }
                else
                {
                    this.dataGridView.DataSource = null;
                }

                this.UpdateEnabled();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal SideTabControl.SidePageTrainer NetworkTrainer
        {
            get { return this.m_networkTrainer; }
            set
            {
                this.m_networkTrainer = value;

                if (value != null)
                {
                //    this.m_networkTrainer.TrainingStarted += networkTrainer_TrainingStarted;
                }
            }
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

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.training_delay = this.trackBar.Value*10;
        }
        #endregion


        #region Graph Events
        private void zedGraphControl_DoubleClick(object sender, EventArgs e)
        {
            if (!GraphOptionsDialog.HasInstance)
            {
                new GraphOptionsDialog().Show(this);
            }
        }
        #endregion


        #region Object Events
        private void networkContainer_savepointRegistered(object sender, EventArgs e)
        {
            this.SavePoints.Add(this.m_networkContainer.Savepoints.CurrentSavepoint.Epoch,
                this.m_networkContainer.Savepoints.CurrentSavepoint.ErrorTraining);

            this.SavePoints.Add(this.m_networkContainer.Savepoints.CurrentSavepoint.Epoch,
                this.m_networkContainer.Savepoints.CurrentSavepoint.ErrorValidation);

            HistoryListener.Write("Savepoint Registered!");
        }

        private void networkContainer_savepointRestored(object sender, EventArgs e)
        {
      //      this.newSavepoint = true;

            HistoryListener.Write("Savepoint Restored!");
        }

        private void networkContainer_savepointChanged(object sender, EventArgs e)
        {
        }
        #endregion


        #region DataGridView Events
        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                NetworkSavepoint save = (this.dataGridView.Rows[e.RowIndex].DataBoundItem as NetworkSavepoint);

                if (save != null)
                    this.m_networkContainer.Savepoints.Restore(save);
            }
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            this.m_currentSavepoint.Clear();

            if (dataGridView.CurrentRow != null)
            {
                NetworkSavepoint sp = dataGridView.CurrentRow.DataBoundItem as NetworkSavepoint;

                if (sp != null)
                {
                    this.m_currentSavepoint.Add(sp.Epoch, sp.ErrorTraining);
                    this.m_currentSavepoint.Add(sp.Epoch, sp.ErrorValidation);
                }

                this.UpdateGraph();
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            NetworkSavepoint currSavepoint = this.m_networkContainer.Savepoints.CurrentSavepoint;
            NetworkSavepoint bestSavepoint = this.m_networkContainer.Savepoints.BestSavepoint;

            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                if ((NetworkSavepoint)row.DataBoundItem == currSavepoint)
                {
                    row.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                if ((NetworkSavepoint)row.DataBoundItem == bestSavepoint)
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            if (Properties.Settings.Default.graph_autoScrollSavepoints)
            {

                if (dataGridView.Rows.Count > 0)
                {
                    dataGridView.FirstDisplayedCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[0];
                }
            }
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnGraphSave_Click(object sender, EventArgs e)
        {
            this.zedGraphControl.SaveAs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateGraph();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearGraph();
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.CurrentRow != null)
            {
                NetworkSavepoint save = (this.dataGridView.CurrentRow.DataBoundItem as NetworkSavepoint);

                if (save != null)
                    this.TrimGraph(save.Epoch);
            }
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
        public void UpdateGraph()
        {
            this.zedGraphControl.AxisChange();
            this.zedGraphControl.Invalidate();
            this.Invalidate();
        }

        public void ClearGraph()
        {
            this.TrainingPoints.Clear();
            this.ValidationPoints.Clear();
            this.SavePoints.Clear();
            this.UpdateGraph();
        }


        public void TrimGraph(int startEpoch)
        {
            lock (this)
            {
                if (this.m_trainingPoints.Count > 0)
                {
                    while (this.m_trainingPoints[this.m_trainingPoints.Count - 1].X > startEpoch)
                    {
                        this.m_trainingPoints.RemoveAt(this.m_trainingPoints.Count - 1);
                    }
                }

                if (this.m_validationPoints.Count > 0)
                {
                    while (this.m_validationPoints[this.m_validationPoints.Count - 1].X > startEpoch)
                    {
                        this.m_validationPoints.RemoveAt(this.m_validationPoints.Count - 1);
                    }
                }

                if (this.m_savePoints.Count > 0)
                {
                    while (this.m_savePoints[this.m_savePoints.Count - 1].X > startEpoch)
                    {
                        this.m_savePoints.RemoveAt(this.m_savePoints.Count - 1);
                    }
                }

                this.UpdateGraph();
            }
        }

        public void UpdateEnabled()
        {
            if (m_networkContainer != null && this.NetworkTrainer.NetworkDatabase != null)
                this.setTabPageEnabled(true);
            else this.setTabPageEnabled(false);
        }

        public void SavepointNext()
        {
        }

        public void SavepointPrev()
        {
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
            RollingPointPairList currentSavepointList = new RollingPointPairList(1200);

            // Add a curve
            LineItem curve;

            curve = myPane.AddCurve("Training Set", trainingList, Color.Red, SymbolType.Diamond);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            this.m_trainingPoints = curve.Points as IPointListEdit;
            // trainingCurve.Line.IsSmooth = true;
            // trainingCurve.Line.SmoothTension = 0.5F;


            curve = myPane.AddCurve("Validation Set", validationList, Color.Blue, SymbolType.Diamond);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            this.m_validationPoints = curve.Points as IPointListEdit;
            // validationCurve.Line.IsSmooth = true;
            // validationCurve.Line.SmoothTension = 0.5F;


            curve = myPane.AddCurve("Savepoints Mark", savepointList, Color.DarkGreen, SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.DarkGreen);
            curve.Symbol.Size = 4;
            curve.Line.IsVisible = false;
            this.m_savePoints = curve.Points as IPointListEdit;
            // validationCurve.Line.IsSmooth = true;
            // validationCurve.Line.SmoothTension = 0.5F;

            curve = myPane.AddCurve(String.Empty, currentSavepointList, Color.LimeGreen, SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.LimeGreen);
            curve.Symbol.Size = 8;
            curve.Line.IsVisible = false;
            this.m_currentSavepoint = curve.Points as IPointListEdit;
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
