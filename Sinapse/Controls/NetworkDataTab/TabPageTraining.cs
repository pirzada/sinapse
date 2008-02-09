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
        
        internal override NetworkSet GetNetworkSet()
        {
            return NetworkSet.Training;
        }

        //----------------------------------------

        
        private ushort trainingSet;


        //----------------------------------------


        #region Constructor
        public TabPageTraining(NetworkDataTabControl parentControl) : base(parentControl)
        {
            InitializeComponent();
        }
        #endregion


        //----------------------------------------


        private void populateCombobox()
        {
            cbTrainingSets.Items.Clear();
            cbTrainingSets.Items.Add("All");
            cbTrainingSets.Items.Add("---");

            for (int i = 0; i < this.ParentControl.NetworkData.TrainingSets; ++i)
            {
                cbTrainingSets.Items.Add(i);
            }
        }

        private void cbTrainingSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrainingSets.SelectedText == "All" || cbTrainingSets.SelectedText == "---")
            {
                this.trainingSet = 0;
                this.BindingSource.Filter = this.getFilterStrBase();
            }
            else
            {
                this.trainingSet = (ushort)cbTrainingSets.SelectedItem;
                this.BindingSource.Filter = String.Format("{0} AND {1} = {2}",
                    this.getFilterStrBase(), NetworkDatabase.ColumnTrainingSetId, cbTrainingSets.SelectedText);
            }
        }

        protected override void OnDataImported(DataTable table)
        {
            this.ParentControl.NetworkData.ImportData(table, NetworkSet.Training, trainingSet);
        }
    }
}
