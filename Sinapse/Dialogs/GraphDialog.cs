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
    public partial class GraphDialog : Form
    {

        LineItem trainingCurve;
        LineItem validationCurve;
        

        //---------------------------------------------


        #region Constructor
        public GraphDialog()
        {
            InitializeComponent();

        }
        #endregion


        //---------------------------------------------


        #region Properties
        public LineItem TrainingCurve
        {
            get { return trainingCurve; }
        }

        public LineItem ValidationCurve
        {
            get { return validationCurve; }
        }

        public Boolean AutoUpdate
        {
            get { return cbAutoupdate.Checked; }
            set { cbAutoupdate.Checked = value; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void UpdateGraph()
        {
            zedGraphControl.AxisChange();
            this.Invalidate();
        }
        #endregion


        //---------------------------------------------


        #region Buttons
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateGraph();
        }
        #endregion


        //---------------------------------------------


        private void GraphDialog_Load(object sender, EventArgs e)
        {
            this.CreateChart(zedGraphControl);
        }


        private void CreateChart(ZedGraphControl zgc)
        {

            GraphPane myPane = zgc.GraphPane;

            // Set the title and axis labels
            myPane.Title.Text = "Training Graph";
            myPane.XAxis.Title.Text = "Epochs";
            myPane.YAxis.Title.Text = "Root-Mean-Square Error";

            double[] x = new double[0];
            double[] y = new double[0];

            // Add a smoothed curve
            trainingCurve = myPane.AddCurve("Training Set", x, y, Color.Red, SymbolType.Diamond);
            trainingCurve.Symbol.Fill = new Fill(Color.White);
            trainingCurve.Symbol.Size = 5;
            trainingCurve.Line.IsSmooth = true;
            trainingCurve.Line.SmoothTension = 0.5F;
            

            validationCurve = myPane.AddCurve("Validation Set", x, y, Color.Blue, SymbolType.Circle);
            validationCurve.Symbol.Fill = new Fill(Color.White);
            validationCurve.Symbol.Size = 5;
            validationCurve.Line.IsSmooth = true;
            validationCurve.Line.SmoothTension = 0.5F;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

        }

    }
}