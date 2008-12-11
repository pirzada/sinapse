using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core.Training;

namespace Sinapse.Windows
{
    /// <summary>
    ///   Display a list of TrainingSavepoints and offers buttons to interact with
    ///   them.
    /// </summary>
    public partial class SavepointsWindow : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        private BindingList<TrainingSavepoint> savepoints;


        /// <summary>
        ///   Constructs a new Savepoints Window
        /// </summary>
        public SavepointsWindow()
        {
            InitializeComponent();

            dataGridView.AutoGenerateColumns = false;
        }


        /// <summary>
        ///   Gets or sets a boolean value determining whether the Savepoint
        ///   Window should autoscroll to the last position whenever a new
        ///   savepoint is registered.
        /// </summary>
        public bool AutoScroll
        {
            get { return cbAutoScroll.Checked; }
            set { cbAutoScroll.Checked = value; }
        }


        /// <summary>
        ///   Gets or sets the list of Savepoints currently displayed in
        ///   this Savepoint Window.
        /// </summary>
        public BindingList<TrainingSavepoint> Savepoints
        {
            get { return savepoints; }
            set
            {
                if (savepoints != value)
                {
                    if (value != null)
                    {
                        this.Enabled = true;
                        savepoints = value;
                        dataGridView.DataSource = savepoints;
                        savepoints.ListChanged += listChanged;
                        listChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
                    }
                    else
                    {
                        savepoints = value;
                        dataGridView.DataSource = null;
                        this.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Gets or sets the current selected Savepoint on the Savepoint Window.
        /// </summary>
        public TrainingSavepoint Current
        {
            get
            {
                if (dataGridView.CurrentRow != null)
                {
                    return dataGridView.CurrentRow.DataBoundItem as TrainingSavepoint;
                }
                else return null;
            }
            set
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if ((row.DataBoundItem as TrainingSavepoint) == value)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///   Occurs when the Revert To Selected button is clicked.
        /// </summary>
        public event EventHandler RestoreClicked
        {
            add { btnRevert.Click += value; }
            remove { btnRevert.Click -= value; }
        }

        /// <summary>
        ///   Occurs when the Save Current button is clicked.
        /// </summary>
        public event EventHandler SaveClicked
        {
            add { btnSaveCurrent.Click += value; }
            remove { btnSaveCurrent.Click -= value; }
        }

        /// <summary>
        ///   Occurs when the current selected row in the DataGridView changes.
        /// </summary>
        public event EventHandler CurrentChanged
        {
            add { dataGridView.CurrentCellChanged += value; }
            remove { dataGridView.CurrentCellChanged -= value; }
        }



        /// <summary>
        ///   Scrolls the DataGridView down to its last row.
        /// </summary>
        private void scrollToEnd()
        {
            // First verify if we have rows on the grid
            if (dataGridView.Rows.Count > 0)
            {
                // Then sets the last row as the first displayed cell.
                dataGridView.FirstDisplayedCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[0];
            }
        }

        private void listChanged(object sender, ListChangedEventArgs e)
        {
            // If AutoScroll is enabled and a new item has been added,
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                if (AutoScroll)
                    scrollToEnd();
            }

/*
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                if ((TrainingSavepoint)row.DataBoundItem == currSavepoint)
                {
                    row.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                if ((TrainingSavepoint)row.DataBoundItem == bestSavepoint)
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
*/

            // TODO: Work better those method. If left this way, everytime
            // a savepoint is registered the buttons will update theirselves.
            if (savepoints.Count == 0)
            {
                btnRevert.Enabled = false;
                btnSelectBest.Enabled = false;
            }
            else
            {
                btnRevert.Enabled = true;
                btnSelectBest.Enabled = true;
            }
        }

        private void btnSelectBest_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}