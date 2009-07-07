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
            double sens = 1.0 * hitPositive / (hitPositive + errorNegative);
            double espe = 1.0* hitNegative/(hitNegative + errorPositive);
            double effc = (sens + espe)/2;
            dataGridView1.Rows.Add(threshold, sens, espe, effc, hitPositive, hitNegative);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            threshold = 0;

            while (threshold <= 1.001)
            {
                this.m_database.ComputeTable(this.m_network, true);
                this.m_database.Round(true, (float)threshold);
                GenerateTestingSummary();

                threshold += 1f/(float)numericUpDown1.Value;
            }


            double sum = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double trapz = ((double)dataGridView1.Rows[i].Cells[1].Value + (double)dataGridView1.Rows[i + 1].Cells[1].Value);
                trapz = trapz * ((1.0 - (double)dataGridView1.Rows[i + 1].Cells[2].Value) - (1.0 - (double)dataGridView1.Rows[i].Cells[2].Value)) / 2;
                sum += trapz;
            }
            textBox1.Text = Math.Abs(sum).ToString();
        }
    }
}
