using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ZedGraph;


namespace Sinapse.Windows
{
    public partial class TrainingGraph : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        private IPointListEdit ptsTraining;
        private IPointListEdit ptsValidation;
        private IPointListEdit ptsSavepoints;
        private IPointListEdit ptsCurrentSavepoint;

        private int ptsMax = 1200;
        private int updateSeconds;
        private int updateEpochs;



        public TrainingGraph()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer,
              true);

            CreateChart(zedGraphControl);
        }



        public IPointListEdit CurveTraining
        {
            get { return ptsTraining; }
        }

        public IPointListEdit CurveValidation
        {
            get { return ptsValidation; }
        }

        public IPointListEdit CurveSavepoints
        {
            get { return ptsSavepoints; }
        }

        public IPointListEdit CurrentSavepoint
        {
            get { return ptsCurrentSavepoint; }
        }

        public void Clear()
        {
            ptsSavepoints.Clear();
            ptsTraining.Clear();
            ptsValidation.Clear();
            ptsCurrentSavepoint.Clear();
        }

        public void UpdateGraph()
        {
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
            Invalidate();
        }

        public void Trim(int start)
        {
            lock (this)
            {
                trim(ptsValidation, start);
                trim(ptsTraining, start);
                trim(ptsSavepoints, start);

                UpdateGraph();
            }
        }

        private void trim(IPointListEdit points, int start)
        {
            if (points.Count > 0)
            {
                while (points[points.Count - 1].X > start)
                {
                    points.RemoveAt(points.Count - 1);
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            if (ptsCurrentSavepoint.Count > 0)
                Trim((int)ptsCurrentSavepoint[0].X);
        }





        #region ZedGraph Specific Methods
        private void CreateChart(ZedGraphControl zgc)
        {
            // TODO: Enhance the Graph display
            GraphPane myPane = zgc.GraphPane;

            // Set the title and axis labels
            myPane.Title.Text = "Training Graph";
            myPane.XAxis.Title.Text = "Epochs";
            myPane.YAxis.Title.Text = "Least-Mean-Square Error";

            RollingPointPairList listTraining = new RollingPointPairList(ptsMax);
            RollingPointPairList listValidation = new RollingPointPairList(ptsMax);
            RollingPointPairList listSavepoint = new RollingPointPairList(ptsMax);
            RollingPointPairList currentSavepointList = new RollingPointPairList(ptsMax);

            // Add a curve
            LineItem curve;

            // Training
            curve = myPane.AddCurve("Training Set", ptsTraining, Color.Red, SymbolType.Diamond);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            this.ptsTraining = curve.Points as IPointListEdit;
            // trainingCurve.Line.IsSmooth = true;
            // trainingCurve.Line.SmoothTension = 0.5F;

            // Validation
            curve = myPane.AddCurve("Validation Set", ptsValidation, Color.Blue, SymbolType.Diamond);
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 4;
            this.ptsValidation = curve.Points as IPointListEdit;
            // validationCurve.Line.IsSmooth = true;
            // validationCurve.Line.SmoothTension = 0.5F;

            // Savepoints
            curve = myPane.AddCurve("Savepoints Mark", ptsSavepoints, Color.DarkGreen, SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.DarkGreen);
            curve.Symbol.Size = 4;
            curve.Line.IsVisible = false;
            this.ptsSavepoints = curve.Points as IPointListEdit;
            // validationCurve.Line.IsSmooth = true;
            // validationCurve.Line.SmoothTension = 0.5F;

            // Current Savepoint
            curve = myPane.AddCurve(String.Empty, currentSavepointList, Color.LimeGreen, SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.LimeGreen);
            curve.Symbol.Size = 8;
            curve.Line.IsVisible = false;
            this.ptsCurrentSavepoint = curve.Points as IPointListEdit;
            // validationCurve.Line.IsSmooth = true;
            // validationCurve.Line.SmoothTension = 0.5F;

            // Set automatic scales adjustments
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


    }
}