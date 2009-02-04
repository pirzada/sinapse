using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using AForge;
using AForge.Neuro;

using Sinapse.Tools;


namespace Sinapse.WinForms.Editors.AdaptiveSystems.Controls
{
    public partial class ActivationNetworkOptions : UserControl
    {
        private IActivationFunction function;

        public ActivationNetworkOptions()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                this.cbActivationFunction.DisplayMember = "Name";
                this.cbActivationFunction.DataSource = Utils.GetTypesImplementingInterface(
                    Assembly.GetAssembly(typeof(AForge.Neuro.ActivationNetwork)), typeof(IActivationFunction));
            }
        }

        public IActivationFunction ActivationFunction
        {
            get { return function; }
        }

        public int[] HiddenLayers
        {
            get { return this.networkLayersEditor.Layers; }
        }

       
        private void cbActivationFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGraph();
        }

        private void propertyGrid_Validated(object sender, EventArgs e)
        {
            updateGraph();
        }

        private void updateGraph()
        {
            Type functionType = cbActivationFunction.SelectedItem as Type;
            if (functionType != null && (function == null || functionType != function.GetType()))
            {
                this.function = (IActivationFunction)Activator.CreateInstance(functionType);
                this.propertyGrid.SelectedObject = function;
                this.activationFunctionView.Function = function;
                this.activationFunctionView.Domain = new DoubleRange(-1.0, 1.0);
                this.activationFunctionView.Steps = 50;
                this.activationFunctionView.Plot();
            }
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            this.activationFunctionView.Plot();
        }


    }
}
