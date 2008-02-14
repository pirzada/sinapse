/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;

namespace Sinapse.Controls.NetworkDataTab
{

    internal sealed partial class TabPageTraining : TabPageBase
    {

        private int m_trainingLayer;


        //----------------------------------------


        #region Constructor
        public TabPageTraining(NetworkDataTabControl parentControl)
            : base(parentControl)
        {
            InitializeComponent();
            SetUp(NetworkSet.Training, "Training Set");

            cbTrainingLayer.DataSource = new object[] { "All", 1, 2, 3, 4, 5, };
        }
        #endregion


        //----------------------------------------


        #region Control Events
        private void TabPageTraining_Load(object sender, EventArgs e)
        {

        }
        #endregion


        //----------------------------------------


        #region Private Methods
        /*
        private void populateCombobox()
        {
            cbTrainingSets.BeginUpdate();
            cbTrainingSets.Items.Clear();
            cbTrainingSets.Items.Add("All");
            cbTrainingSets.Items.Add("---");

            if (this.ParentControl != null && this.ParentControl.NetworkData != null)
            {
                for (ushort i = 1; i <= this.ParentControl.NetworkData.TrainingLayerCount; ++i)
                {
                    cbTrainingSets.Items.Add(i);
                }
            }

            cbTrainingSets.EndUpdate();
            cbTrainingSets.SelectedIndex = 0;
    
        }
    */
        private void cbTrainingSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrainingLayer.SelectedIndex == 0)
            {
                this.m_trainingLayer = 0;
                this.BindingSource.Filter = this.GetFilterString();
            }
            else
            {
                this.m_trainingLayer = cbTrainingLayer.SelectedIndex;
                this.BindingSource.Filter = String.Format("{0} AND {1} = '{2}'",
                    this.GetFilterString(),
                    NetworkDatabase.ColumnTrainingLayerId,
                    this.m_trainingLayer);
            }

        }
        #endregion


        //----------------------------------------


        protected override void OnRowValidating(DataRowView row)
        {
            if (m_trainingLayer > 0)
                row.Row[NetworkDatabase.ColumnTrainingLayerId] = m_trainingLayer;

            base.OnRowValidating(row);
        }

        protected override void OnDataImported(DataTable table)
        {
            this.ParentControl.NetworkDatabase.ImportData(table, NetworkSet.Training, m_trainingLayer);
        }


        //----------------------------------------


    }
}
