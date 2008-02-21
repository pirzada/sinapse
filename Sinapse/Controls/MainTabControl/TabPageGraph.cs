using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Controls.MainTabControl.Base;

using ZedGraph;

namespace Sinapse.Controls.MainTabControl
{
    internal sealed partial class TabPageGraph : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkContainer m_networkContainer;
        private IPointListEdit m_trainingPoints;
        private IPointListEdit m_validationPoints;


        //----------------------------------------


        #region Constructor
        internal TabPageGraph()
        {
            InitializeComponent();

            this.TabPageName = "Training History";
            this.dataGridView.AutoGenerateColumns = false;

            this.CreateChart(zedGraphControl);
        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkContainer NetworkContainer
        {
            get { return this.m_networkContainer; }
            set
            {
                this.m_networkContainer = value;

                if (value != null)
                {
                    this.TabPageEnabled = true;
                    this.dataGridView.DataSource = this.m_networkContainer.Savepoints;
                }
                else
                {
                    this.TabPageEnabled = false;
                    this.dataGridView.DataSource = null;
                }
            }
        }

        public IPointListEdit TrainingPoints
        {
            get { return this.m_trainingPoints; }
        }

        public IPointListEdit ValidationPoints
        {
            get { return this.m_validationPoints; }
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
        #endregion

        
        //----------------------------------------

    }
}
