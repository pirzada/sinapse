using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core.Training;

using WeifenLuo.WinFormsUI.Docking;

namespace Sinapse.Documents
{

    public partial class BackpropagationTrainer :  WeifenLuo.WinFormsUI.Docking.DockContent, IDocument
    {

        private BackpropagationTrainingSession session;

        public BackpropagationTrainer(BackpropagationTrainingSession session)
        {
            this.session = session;
            InitializeComponent();
        }





        public void Save()
        {
            if (session.Location != String.Empty)
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


    }
}
