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

    internal sealed partial class TabPageTesting : TabPageBase
    {


        //----------------------------------------


        #region Constructor
        public TabPageTesting(NetworkDataTabControl parentControl)
            : base(parentControl)
        {
            InitializeComponent();
            SetUp(NetworkSet.Testing, "Testing Set");
        }
        #endregion


        //----------------------------------------


        protected override void OnDatabaseLoaded()
        {
            base.OnDatabaseLoaded();

            if (this.ParentControl.NetworkDatabase != null)
            {
                DataGridViewColumn column;

                foreach (String colName in this.ParentControl.NetworkDatabase.Schema.OutputColumns)
                {
                    column = new DataGridViewColumn();
                    column.DataPropertyName = NetworkDatabase.ColumnComputedPrefix + colName;
                    column.HeaderText = "Network: " + colName;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.DefaultCellStyle.BackColor = SystemColors.Window;
                    this.dataGridView.Columns.Add(column);
                }
            }
        }

    }
}
