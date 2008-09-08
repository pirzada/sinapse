using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using AForge;
using AForge.Neuro;

using ZedGraph;

namespace Sinapse.Forms.Controls.Controls
{

    public partial class ActivationFunctionView : Control
    {

        private ZedGraphControl zedGraphControl1;
        private IActivationFunction _function;
        private DoubleRange _plotDomain;
        private uint _plotSteps;


        #region Constructor
        public ActivationFunctionView()
        {
            this._plotSteps = 1;
            this._plotDomain = new DoubleRange(-1,1);

            InitializeGraph();
        }
        #endregion



        #region Public Properties
        public IActivationFunction Function
        {
            get { return this._function; }
            set
            {
                this._function = value;
            }
        }

        public DoubleRange Domain
        {
            get { return this._plotDomain; }
            set { this._plotDomain = value; }
        }

        [DefaultValue(1)]
        public uint Steps
        {
            get { return this._plotSteps; }
            set {
                if (value == 0)
                    throw new ArgumentOutOfRangeException();

                this._plotSteps = value; }
        }
        #endregion



        private void InitializeGraph()
        {
            zedGraphControl1 = new ZedGraphControl();
            GraphPane myPane = this.zedGraphControl1.GraphPane;

            // Set the titles and axis labels
            
            myPane.Title.Text = "Activation Function";
            myPane.XAxis.Title.Text = "X";
            myPane.YAxis.Title.Text = "Y";

            // Set the Y axis intersect the X axis at an X value of 0.0
            myPane.YAxis.Cross = 0.0;
            myPane.Legend.IsVisible = false;

            // Turn off the axis frame and all the opposite side tics
            myPane.Chart.Border.IsVisible = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;

            this.Controls.Add(this.zedGraphControl1);

            // Calculate the Axis Scale Ranges
            zedGraphControl1.AxisChange();
        }

        public void Plot()
        {
            if (this._function == null)
                throw new InvalidOperationException();

            zedGraphControl1.GraphPane.CurveList.Clear();

            double x, y;
            double stepSize = _plotDomain.Length / _plotSteps;

            PointPairList list = new PointPairList();
            for (int i = 0; i < _plotSteps; i++)
            {
                x = this._plotDomain.Min + i * stepSize;
                y = this._function.Function(x);

                list.Add(x,y);
            }


            zedGraphControl1.GraphPane.AddCurve(
                _function.GetType().Name,
                list, Color.Red, SymbolType.None);

            zedGraphControl1.AxisChange();
        }

    }
}
