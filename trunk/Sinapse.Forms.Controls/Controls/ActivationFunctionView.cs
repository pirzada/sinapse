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

namespace Sinapse.WinForms.Controls.Controls
{

    public partial class ActivationFunctionView : Control
    {

        public enum FunctionDerivative { None, First, Second }

        private IActivationFunction function;
        private DoubleRange plotDomain;
        private FunctionDerivative derivative = FunctionDerivative.None;
        private ZedGraphControl zedGraphControl;
        private IContainer components;
        private uint plotSteps;




        public ActivationFunctionView()
        {
            this.plotSteps = 1;
            this.plotDomain = new DoubleRange(-1, 1);


            InitializeComponent();
            CreateGraph(zedGraphControl);
        }





        public IActivationFunction Function
        {
            get { return this.function; }
            set { this.function = value; }
        }

        public DoubleRange Domain
        {
            get { return this.plotDomain; }
            set { this.plotDomain = value; }
        }

        [DefaultValue(1)]
        public uint Steps
        {
            get { return this.plotSteps; }
            set {
                if (value == 0)
                    throw new ArgumentOutOfRangeException();

                this.plotSteps = value; }
        }

        public FunctionDerivative Derivative
        {
            get { return this.derivative; }
            set { this.derivative = value; }
        }





        public void Plot()
        {
            if (this.function == null)
                throw new InvalidOperationException();

            zedGraphControl.GraphPane.CurveList.Clear();

            double x, y;
            double stepSize = plotDomain.Length / plotSteps;


            PointPairList list = new PointPairList();
            for (int i = 0; i < plotSteps; i++)
            {
                x = this.plotDomain.Min + ((double)i * stepSize);
                switch (this.derivative)
                {
                    case FunctionDerivative.None:
                        y = this.function.Function(x); break;
                    case FunctionDerivative.First:
                        y = this.function.Derivative(x); break;
                    case FunctionDerivative.Second:
                        y = this.function.Derivative2(x); break;
                    default: 
                        goto case FunctionDerivative.None;
                }

                list.Add(x,y);
            }


            LineItem curve = zedGraphControl.GraphPane.
                AddCurve(function.GetType().Name, list, Color.Red, SymbolType.None);
            //curve.Line.IsSmooth = true;
            //curve.Line.SmoothTension = 0.1f;
            curve.Line.IsAntiAlias = true;
            curve.Line.Width = 2f;


            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }





        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Activation Function";
            //myPane.XAxis.Title.Text = "X";
            //myPane.XAxis.Title.IsTitleAtCross = true;
            myPane.XAxis.Title.IsVisible = false;

            //myPane.YAxis.Title.Text = "Y";
            //myPane.YAxis.Title.IsTitleAtCross = true;
            myPane.YAxis.Title.IsVisible = false;


            // Set the Y axis intersect the X axis at an X value of 0.0
            myPane.YAxis.Cross = 0.0;
            myPane.XAxis.Cross = 0.0;
            myPane.Legend.IsVisible = true;


            // Turn off the axis frame and all the opposite side tics
            myPane.Chart.Border.IsVisible = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Invalidate();
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0;
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(150, 150);
            this.zedGraphControl.TabIndex = 0;
            this.zedGraphControl.Dock = DockStyle.Fill;
            //
            // ActivationFunctionView
            //
            this.Name = "ActivationFunctionView";
            this.Controls.Add(zedGraphControl);

            this.zedGraphControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

    }
}
