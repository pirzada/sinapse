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

namespace Sinapse.Windows.SystemEditor
{
    public partial class InterfaceSpecification : DockContent
    {

        SystemInputOutputCollection inputs;
        SystemInputOutputCollection outputs;

        public InterfaceSpecification()
        {
            InitializeComponent();
        }


        public SystemInputOutputCollection Inputs
        {
            get { return inputs; }
            set
            {
                if (inputs != value)
                {
                    inputs = value;
                    dgvInterfaceInputs.DataSource = inputs;
                }
            }
        }

        public SystemInputOutputCollection Outputs
        {
            get { return outputs; }
            set
            {
                if (outputs != value)
                {
                    outputs = value;
                    dgvInterfaceOutputs.DataSource = outputs;
                }
            }
        }

    }
}