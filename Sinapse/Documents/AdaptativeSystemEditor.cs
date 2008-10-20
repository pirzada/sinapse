using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Networks;

namespace Sinapse.Documents
{
    public partial class AdaptativeSystemEditor : DockContent
    {

        private AdaptativeSystemBase system;

        public AdaptativeSystemEditor()
        {
            InitializeComponent();
        }
    }
}
