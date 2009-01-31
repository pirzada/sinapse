using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Forms.Editors.AdaptiveSystems.Controls
{
    public partial class LayersControl : UserControl
    {
   

        public LayersControl()
        {
            InitializeComponent();
        }


        public int[] Layers
        {
            get
            {
                int[] r = new int[dataGridView.Rows.Count];
                for (int i = 0; i < r.Length; i++)
                    r[i] = (int)dataGridView.Rows[i].Cells[0].Value;
                return r;
            }
            set
            {
                if (value != null)
                {
                    dataGridView.Rows.Clear();
                    for (int i = value.Length - 1; i >= 0; i++)
                        dataGridView.Rows.Add(new object[] { i });
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Insert at the end
            dataGridView.Rows.Insert(dataGridView.Rows.Count, new object[] { 0 });
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                // Remove selection
                dataGridView.Rows.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
            }
        }

/*
        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                btnMoveUp.Enabled = (dataGridView.SelectedRows[0].Index > 0);
                btnMoveDown.Enabled = (dataGridView.SelectedRows[0].Index < dataGridView.Rows.Count - 1);
            }
            else
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnRemove.Enabled = false;
            }
        }
*/
    }
}
