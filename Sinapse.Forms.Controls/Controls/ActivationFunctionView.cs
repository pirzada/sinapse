using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

namespace Sinapse.Forms.Controls.Controls
{
    public partial class ActivationFunctionView : UserControl
    {

        private const int points = 100;
        
        private IActivationFunction _function;


        public ActivationFunctionView()
        {
            InitializeComponent();
            InitializeGraph();
        }

        public IActivationFunction Function
        {
            get { return _function; }
            set
            {
                this._function = value;
                this.propertyGrid1.SelectedObject = this._function;
            }
        }

        private void InitializeGraph()
        {
            
        }

        public void Plot()
        {
            int step = Math.Ceiling(this._function.Range.Length / points);

            for (int i = this._function.Range.Min; i < this._function.Range.Max; i+=step)
            {
                
            }
        }

    }
}
