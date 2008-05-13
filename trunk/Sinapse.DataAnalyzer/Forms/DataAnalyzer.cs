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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AForge.Statistics.SampleAnalysis;
using AForge.Statistics;


namespace Sinapse.DataAnalyzer.Forms
{
    public partial class DataAnalyzer : Form
    {

        DataTable dataTable;
        PrincipalComponentAnalysis pca;


        public DataAnalyzer()
        {
            InitializeComponent();
        }

        private void DataAnalyzer_Load(object sender, EventArgs e)
        {

        }

        private void btnRunAnalysis_Click(object sender, EventArgs e)
        {

            SampleMatrix smatrix = new SampleMatrix(dataTable);
            pca = new PrincipalComponentAnalysis(smatrix);
            
            pca.Compute();

            dgvPrincipalComponents.DataSource = pca.Components;
            dgvComponentList.DataSource = pca.Components;
            dgvVectors.DataSource = pca.ComponentMatrix;
            
            
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string filename = openFileDialog.FileName;
            string extension = Path.GetExtension(filename);
            if (extension == ".xls")
                MessageBox.Show("Bla");

            Sinapse.Databases.Excel db = new Sinapse.Databases.Excel(filename, true, false);
            MessageBox.Show(db.GetWorksheetList()[0]);
        }

    }
}