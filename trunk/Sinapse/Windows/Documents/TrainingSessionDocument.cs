using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;
using Sinapse.Core.Training;
using Sinapse.Windows.Training;

using WeifenLuo.WinFormsUI.Docking;


namespace Sinapse.Windows.Documents
{

    public partial class TrainingSessionDocument :  WeifenLuo.WinFormsUI.Docking.DockContent, IWorkplaceDocument
    {

        private WorkplaceItem item;
        private BackpropagationTrainingSession session;
        private TrainingSessionController controller;
        private SavepointsWindow savepoints;
        private TrainingOptionsWindow options;


        public TrainingSessionDocument(BackpropagationTrainingSession session)
        {
            this.session = session;
            InitializeComponent();

            controller = new TrainingSessionController(session);
            savepoints = new SavepointsWindow(session.Savepoints);
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

        public SavepointsWindow SavepointsWindow
        {
            get { return savepoints; }
        }





        #region IWorkplaceDocument Members

        public void Save()
        {
            if (session.FullPath != String.Empty)
                session.Save();
            else SaveAs();
        }

        public void SaveAs()
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                session.Save(saveFileDialog.FileName);
            }
        }

        public ToolStripMenuItem[] MenuItems
        {
            get { return null; }
        }

        public ToolStrip[] ToolStrips
        {
            get { return null; }
        }

        public WorkplaceItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public bool HasChanges
        {
            get { return session.HasChanges; }
        }

        #endregion
    }
}
