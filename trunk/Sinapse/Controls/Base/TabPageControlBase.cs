using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using Dotnetrix.Controls;

namespace Sinapse.Controls.Base
{   
    
    internal class TabPageControlBase : UserControl
    {

        private string m_tabPageName;


        //----------------------------------------


        #region Constructor
        protected TabPageControlBase()
        {
            this.m_tabPageName = String.Empty;
        }
        #endregion


        //----------------------------------------


        #region Properties
        protected bool TabPageEnabled
        {
            get
            {
                if (this.TabPage != null)
                    return this.Parent.Enabled;
                else return this.TabPageEnabled;
            }
            set
            {
                if (this.TabPage != null)
                    this.Parent.Enabled = value;
                else this.TabPageEnabled = value;
            }
        }

        protected string TabPageName
        {
            get { return this.m_tabPageName; }
            set
            {
                this.m_tabPageName = value;
                this.UpdateTitle();
            }
        }

        internal TabPageEX TabPage
        {
            get
            {
                if (this.Parent == null)
                    return null;
                else return (this.Parent as TabPageEX);
            }
        }
        #endregion


        //----------------------------------------


        internal new void ShowTab()
        {
            if (this.TabPage != null && this.TabPage.Parent != null)
            {
                TabControlEX tabControl = this.TabPage.Parent as TabControlEX;

                if (tabControl != null)
                {
                    tabControl.SelectedTab = this.TabPage;
                }
            }
        }

        protected virtual void UpdateTitle()
        {
            if (this.TabPage != null)
                this.TabPage.Text = this.m_tabPageName;
        }

    }

}

