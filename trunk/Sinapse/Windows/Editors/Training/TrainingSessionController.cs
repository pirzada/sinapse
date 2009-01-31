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
    public partial class TrainingSessionController : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private BackpropagationTrainingSession session;

        public TrainingSessionController(BackpropagationTrainingSession session)
        {
            this.session = session;

            InitializeComponent();
        }
    }
}