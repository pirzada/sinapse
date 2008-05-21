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

using ZedGraph;

using AForge.Statistics.SampleAnalysis;
using AForge.Statistics;
using AForge.Math;


namespace Sinapse.Extensions.Simplifier.Forms
{

    public partial class Simplifier : System.Windows.Forms.Form
    {

        private readonly Color[] colors = { Color.YellowGreen, Color.DarkOliveGreen, Color.DarkKhaki, Color.Olive,
            Color.Honeydew, Color.PaleGoldenrod, Color.Indigo, Color.Olive, Color.SeaGreen };


        private PrincipalComponentAnalysis pca;

        private DataTable tableAnalysisSource;
        private DataTable tableShiftSource;
        private DataTable tableShiftResult;



        #region Constructor
        public Simplifier()
        {
            InitializeComponent();

            dgvSample.AutoGenerateColumns = true;
            dgvShiftProjection.AutoGenerateColumns = true;
            dgvOverviewVectors.AutoGenerateColumns = true;
            dgvOverviewComponents.AutoGenerateColumns = false;
            dgvShiftComponents.AutoGenerateColumns = false;
        }
        #endregion


        private void DataAnalyzer_Load(object sender, EventArgs e)
        {

        }

        #region Buttons
        private void btnRunAnalysis_Click(object sender, EventArgs e)
        {

            dgvSample.EndEdit();
            tableAnalysisSource.AcceptChanges();

            Matrix smatrix = new Matrix(tableAnalysisSource);

            DescriptiveAnalysis sda = new DescriptiveAnalysis(smatrix);
            pca = new PrincipalComponentAnalysis(smatrix);
            pca.Center = cbCenter.Checked;
            pca.Standardize = cbStandardize.Checked;
            
            // populate statistics overview tab
            dgvStatisticCenter.DataSource = sda.DeviationScores.ToDataTable();
            dgvStatisticStandard.DataSource = sda.StandardScores.ToDataTable();

            dgvStatisticCovariance.DataSource = sda.CovarianceMatrix.ToDataTable();
            dgvStatisticCorrelation.DataSource = sda.CorrelationMatrix.ToDataTable();
            dgvStatisticMeasures.DataSource = sda.Measures;

            pca.Compute();

            tableShiftSource = pca.SourceMatrix.ToDataTable();

            dgvOverviewComponents.DataSource = pca.Components;
            dgvShiftComponents.DataSource = pca.Components;
            
            dgvOverviewVectors.DataSource = pca.ComponentMatrix.ToDataTable();
            dgvShiftSample.DataSource = tableShiftSource;

            numComponents.Maximum = pca.Components.Count;

            tabControl.SelectedTab = tabOverview;

            CreateChartCurve(graphCurve);
            CreateChartPie(graphShare);

        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            Matrix shiftSource = new Matrix(tableShiftSource);
            Matrix m = pca.Apply(shiftSource, (int)numComponents.Value);
            dgvShiftProjection.DataSource = m.ToDataTable();
        }
        #endregion


        #region Menus
        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string extension = Path.GetExtension(filename);
                if (extension == ".xls")
                {
                    Sinapse.Databases.Excel db = new Sinapse.Databases.Excel(filename, true, false);
                    TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

                    if (t.ShowDialog(this) == DialogResult.OK)
                    {
                        this.tableAnalysisSource = db.GetWorksheet(t.Selection);
                        this.dgvSample.DataSource = tableAnalysisSource;
                    }
                }
                else if (extension == ".txt")
                {

                }
            }
        }

        #endregion


        #region Graphs
        public void CreateChartCurve(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            
            myPane.CurveList.Clear();

            // Set the titles and axis labels
            myPane.Title.Text = "Component Distribution";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Tahoma";
            myPane.XAxis.Title.Text = "Components";
            myPane.YAxis.Title.Text = "Percentage";

            PointPairList list = new PointPairList();
            for (int i = 0; i < pca.Components.Count; i++)
            {
                list.Add(pca.Components[i].Index, pca.Components[i].CumulativeProportion);
            }

            // Hide the legend
            myPane.Legend.IsVisible = false;

            // Add a curve
            LineItem curve = myPane.AddCurve("label", list, Color.Red, SymbolType.Circle);
            curve.Line.Width = 2.0F;
            curve.Line.IsAntiAlias = true;
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 7;

            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = true;


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

        public void CreateChartPie(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            // Set the GraphPane title
            myPane.Title.Text = "Component Proportion";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Tahoma";

            // Fill the pane background with a color gradient
          //  myPane.Fill = new Fill(Color.White, Color.WhiteSmoke, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            myPane.Legend.IsVisible = false;

            // Add some pie slices
            for (int i = 0; i < pca.Components.Count; i++)
            {
                myPane.AddPieSlice(pca.Components[i].Proportion, colors[i%colors.Length], 0.1, pca.Components[i].Index.ToString());
            }


            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = true;


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }
        #endregion

        private void numComponents_ValueChanged(object sender, EventArgs e)
        {
            dgvShiftComponents.ClearSelection();
            for (int i = 0; i < numComponents.Value && i < dgvShiftComponents.Rows.Count; i++)
            {
                dgvShiftComponents.Rows[i].Selected = true;
            }
        }


    }
}