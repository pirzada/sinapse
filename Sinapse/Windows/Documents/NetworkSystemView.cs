using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Systems;

using Sinapse.Windows.Editors.AdaptiveSystems;
using Sinapse.Windows.Editors.AdaptiveSystems.Controls;


namespace Sinapse.Windows.Documents
{
    [DocumentViewer(typeof(ActivationNetworkSystem))]
    internal partial class NetworkSystemView : SinapseDocumentView
    {



        public NetworkSystemView(Workbench workbench, ISinapseDocument document)
            : base(workbench, document)
        {
            InitializeComponent();
        }



        private void AdaptativeSystemEditor_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            this.ResumeLayout(true);
        }





    }
}
