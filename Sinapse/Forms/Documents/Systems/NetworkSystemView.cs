using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Documents;
using Sinapse.Core.Systems;

//using Sinapse.WinForms.Editors.AdaptiveSystems;
//using Sinapse.WinForms.Editors.AdaptiveSystems.Controls;

using Sinapse.WinForms.Core;


namespace Sinapse.WinForms.Documents
{
    [DocumentViewer(".system.ann")]
    internal partial class NetworkSystemView : SinapseDocumentView
    {
        ActivationNetworkSystem Network
        {
            get { return this.Document as ActivationNetworkSystem; }
        }


        public NetworkSystemView(Workbench workbench, ISinapseDocument document)
            : base(workbench, document)
        {
            InitializeComponent();
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            colRole.DataSource = Enum.GetValues(typeof(InputOutput));
            colType.DataSource = Enum.GetValues(typeof(SystemDataType));
            dgvInterface.DataSource = Network.Interface;

            filterSequenceControl1.Filters = Network.Preprocess;
            filterSequenceControl2.Filters = Network.Postprocess;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvInterface_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }







    }
}
