using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Neuro;

using Sinapse.Data;
using Sinapse.Data.Network;
using Sinapse.Data.Reporting;


namespace Sinapse.Forms
{
    internal sealed partial class RocViewer : Form
    {
        private NetworkContainer m_network;
        private NetworkDatabase m_database;
        private float threshold;

        public RocViewer(NetworkContainer networkContainer, NetworkDatabase networkDatabase)
        {
            InitializeComponent();

            m_network = networkContainer;
            m_database = networkDatabase;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            threshold = 0;

            while (threshold <= 1.001)
            {
                this.m_database.ComputeTable(this.m_network, true);
                this.m_database.Round(true, (float)threshold);
                GenerateTestingSummary();

                threshold += 0.05f;
            }
        }

        public void GenerateTestingSummary()
        {
            DataRow[] testingRows = this.m_database.DataTable.Select(
               String.Format("[{0}] = {1}", NetworkDatabase.ColumnRoleId, (ushort)NetworkSet.Testing));
            int testingItems = testingRows.Length * this.m_database.Schema.OutputColumns.Length;

            int hitTotal = 0, hitPositive = 0, hitNegative = 0;
            int errorTotal = 0, errorPositive = 0, errorNegative = 0;
            double totalScore = 0, finalScore = 0;

            foreach (DataRow row in testingRows)
            {
                foreach (String outputColumn in this.m_network.Schema.OutputColumns)
                {

                    totalScore += Math.Abs(Double.Parse((string)row[NetworkDatabase.ColumnDeltaPrefix + outputColumn]));

                    if (row[outputColumn].Equals(row[NetworkDatabase.ColumnComputedPrefix + outputColumn]))
                    {
                        hitTotal++;

                        if (row[outputColumn].Equals("1"))
                        {
                            hitPositive++;
                        }
                        else
                        {
                            hitNegative++;
                        }
                    }
                    else
                    {
                        errorTotal++;

                        if (row[outputColumn].Equals("0"))
                        {
                            errorPositive++;
                        }
                        else
                        {
                            errorNegative++;
                        }
                    }

                }
            }

            finalScore = totalScore / testingItems;
            dataGridView1.Rows.Add(threshold, 1.0 * hitPositive/(hitPositive + errorNegative), 1.0* hitNegative/(hitNegative + errorPositive), hitPositive, hitNegative);
/*
            reportBuilder.Replace("[totalDeviation]", totalScore.ToString("N6"));
            reportBuilder.Replace("[finalDeviation]", finalScore.ToString("N6"));

            reportBuilder.Replace("[hits]", hitTotal.ToString());
            reportBuilder.Replace("[hits%]", ((float)hitTotal / testingItems).ToString("0.00%"));

            reportBuilder.Replace("[errors]", errorTotal.ToString());
            reportBuilder.Replace("[errors%]", ((float)errorTotal / testingItems).ToString("0.00%"));

            if (hitTotal != 0)
            {
                reportBuilder.Replace("[hitsP]", hitPositive.ToString());
                reportBuilder.Replace("[hitsN]", hitNegative.ToString());
                reportBuilder.Replace("[hitsP%]", ((float)hitPositive / hitTotal).ToString("0.00%"));
                reportBuilder.Replace("[hitsN%]", ((float)hitNegative / hitTotal).ToString("0.00%"));
            }
            else
            {
                reportBuilder.Replace("[hitsP]", "-");
                reportBuilder.Replace("[hitsN]", "-");
                reportBuilder.Replace("[hitsP%]", String.Empty);
                reportBuilder.Replace("[hitsN%]", String.Empty);
            }

            if (errorTotal != 0)
            {
                reportBuilder.Replace("[errorsP]", errorPositive.ToString());
                reportBuilder.Replace("[errorsN]", errorNegative.ToString());
                reportBuilder.Replace("[errorsP%]", ((float)errorPositive / errorTotal).ToString("0.00%"));
                reportBuilder.Replace("[errorsN%]", ((float)errorNegative / errorTotal).ToString("0.00%"));
            }
            else
            {
                reportBuilder.Replace("[errorsP]", "-");
                reportBuilder.Replace("[errorsN]", "-");
                reportBuilder.Replace("[errorsP%]", String.Empty);
                reportBuilder.Replace("[errorsN%]", String.Empty);
            }
 */ 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
