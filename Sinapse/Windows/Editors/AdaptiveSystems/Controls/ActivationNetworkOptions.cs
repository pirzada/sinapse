using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using AForge.Neuro;

using Sinapse.Tools;


namespace Sinapse.Windows.Editors.AdaptiveSystems.Controls
{
    public partial class ActivationNetworkOptions : UserControl
    {
        private IActivationFunction function;

        public ActivationNetworkOptions()
        {
            InitializeComponent();

            this.cbActivationFunction.DisplayMember = "Name";
            this.cbActivationFunction.DataSource = Utils.GetTypesImplementingInterface(typeof(IActivationFunction));
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
            Type functionType = cbActivationFunction.SelectedItem as Type;
            if (functionType != null)
            {
                this.function = (IActivationFunction)System.Activator.CreateInstance(functionType);
                this.propertyGrid.SelectedObject = function;
            }
        }


    }
}
