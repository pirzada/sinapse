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
    public partial class NetworkSystemDesign : DockContent
    {

        private ActivationNetworkSystem system;

        public NetworkSystemDesign()
        {
            InitializeComponent();
        }

        public ActivationNetworkSystem NetworkSystem
        {
            get { return system; }
            set { system = value; }
        }
    }
}