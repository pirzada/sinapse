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
        protected string TabPageName
        {
            get { return this.m_tabPageName; }
            set
            {
                this.m_tabPageName = value;
                this.UpdateTitle();
            }
        }

        protected void setTabPageEnabled(bool value)
        {
            if (this.getTabPage() != null)
                this.Parent.Enabled = value;
        }

        protected TabPageEX getTabPage()
        {
            if (this.Parent != null)
                return (this.Parent as TabPageEX);
            else return null;
        }
        #endregion


        //----------------------------------------


        internal void ShowTab()
        {
            if (this.getTabPage() != null && this.getTabPage().Parent != null)
            {
                TabControlEX tabControl = this.getTabPage().Parent as TabControlEX;

                if (tabControl != null)
                {
                    tabControl.SelectedTab = this.getTabPage();
                }
            }
        }

        protected virtual void UpdateTitle()
        {
            if (this.getTabPage() != null)
                this.getTabPage().Text = this.m_tabPageName;
        }

    }

}

