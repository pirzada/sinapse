using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Dotnetrix.Controls;

using Sinapse.Data;

namespace Sinapse.Controls.TrainingTabs
{
    internal sealed class TrainingTabControl : Dotnetrix.Controls.TabControlEX
    {

        private NetworkData m_networkData;


        private TabTesting m_tabTesting;
        private TabValidation m_tabValidation;
        private TabTraining[] m_tabTraining;


        public EventHandler OnSelectionChanged;
        public EventHandler OnSchemaChanged;
        public EventHandler OnDataChanged;


        //----------------------------------------

        
        #region Constructor
        public TrainingTabControl()
        {
            m_tabTesting = new TabTesting();
            m_tabValidation = new TabValidation();

            this.TabPages.Add(CreateTab(m_tabTesting,"Testing Set",0));
            this.TabPages.Add(CreateTab(m_tabValidation,"Validation Set",1));
        }
        #endregion
                                                  

        //----------------------------------------            


        #region Properties
        internal NetworkData NetworkData
        {
            get
            {
                return this.m_networkData;
            }
            set
            {
                if (this.m_networkData != value)
                {

                    if (this.OnSchemaChanged != null)
                        this.OnSchemaChanged.Invoke(this, EventArgs.Empty);

                    if (this.OnDataChanged != null)
                        this.OnDataChanged.Invoke(this, EventArgs.Empty);
                }
            }
        }

        internal NetworkSchema Schema
        {
            get { return m_networkData.NetworkSchema; }
        }

        internal int ItemCount
        {
            get { return this.m_networkData.DataTable.Rows.Count; }
        }
        #endregion


        //----------------------------------------


        private TabPageEX CreateTab(UserControl control, string text, int imageIndex)
        {
            TabPageEX tabPage = new TabPageEX(text);
            tabPage.ImageIndex = imageIndex;
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            return tabPage;
        }

    }
}
