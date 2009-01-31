using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core.Training;

namespace Sinapse.Forms.Training
{
    public partial class TrainingOptionsWindow : Form
    {
        private TrainingOptions options;

        public TrainingOptionsWindow(TrainingOptions options)
        {
            this.options = options;

            InitializeComponent();
        }
    }
}