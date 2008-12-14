using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Systems;


namespace Sinapse.Windows.Editors.AdaptiveSystems
{
    public partial class ActivationNetworkDesigner : DockContent
    {

        /* PS: The original idea is to display the input filters on the left,
         * then a diagram of the network (and the neuron counters inside this
         * diagram) and the output filter to the left. The activation function
         * could be defined on the top of the diagram, and its options appear
         * on the main property grid.
         * 
         * We have some limits due to how AForge Networks are created; they can
         * only be instantiated with all its options set on their constructor,
         * and after that, they cannot be modified. The workaround is to build
         * the network logically (only graphically) and then pass its parameters
         * to the constructor, to create the real network only as the last step.
         */ 

        private ActivationNetworkSystem system;

        public ActivationNetworkDesigner()
        {
            InitializeComponent();
        }

        public ActivationNetworkSystem NetworkSystem
        {
            get { return system; }
            set
            {
                system = value;
                inputFilters.Filters = system.Preprocess;
                outputFilters.Filters = system.Postprocess;
                
            }
        }
    }
}