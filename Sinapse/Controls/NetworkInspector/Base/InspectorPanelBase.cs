using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Controls.NetworkInspector.Base
{
    public partial class InspectorPanelBase : UserControl
    {

        public event EventHandler NetworkChanged;


        //----------------------------------------


        #region Constructor
        public InspectorPanelBase()
        {
            InitializeComponent();
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected void OnNetworkChanged()
        {
            if (NetworkChanged != null)
                NetworkChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
