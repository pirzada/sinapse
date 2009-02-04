using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;
using Sinapse.Core.Training;
using Sinapse.WinForms.Training;

using Sinapse.WinForms.Core;


namespace Sinapse.WinForms.Documents
{

    internal partial class TrainingSessionView :  SinapseDocumentView
    {

        private BackpropagationTrainingSession session;
        private TrainingSessionController controller;
      //  private SavepointsWindow savepoints;
        private TrainingOptionsWindow options;


        public TrainingSessionView(Workbench workbench, BackpropagationTrainingSession session) : base(workbench, session)
        {
            this.session = session;
            InitializeComponent();

            controller = new TrainingSessionController(session);
         //   savepoints = new SavepointsWindow(session.Savepoints);
            options = new TrainingOptionsWindow(session.Options);
        }



        public BackpropagationTrainingSession Session
        {
            get { return session; }
        }

        public TrainingSessionController ControllerWindow
        {
            get { return controller; }
        }

     /*   public SavepointsWindow SavepointsWindow
        {
            get { return savepoints; }
        }
        */



    }
}
