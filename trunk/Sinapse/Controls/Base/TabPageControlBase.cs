/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

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


        public void ShowTab()
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

