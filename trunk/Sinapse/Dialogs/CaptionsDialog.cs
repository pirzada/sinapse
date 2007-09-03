using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TrendView.Data;
using TrendView.Databases;

namespace TrendView.Dialogs
{
    internal sealed partial class CaptionsDialog : Form
    {

        private DataSet dataCategories;


        internal CaptionsDialog(DataSet dataCategories)
        {
            InitializeComponent();
            this.dataCategories = dataCategories;
        }

        public bool HasCaptions
        {
            get { return (comboBox.Items.Count > 0); }
        }


        private void eventCaptionsChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = dataCategories;

            comboBox.Items.Clear();
            comboBox.BeginUpdate();
            foreach (DataTable table in dataCategories.Tables)
            {
                comboBox.Items.Add(table.TableName);
            }
            comboBox.EndUpdate();

            if (this.HasCaptions)
                comboBox.SelectedIndex = 0;  
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataMember = comboBox.SelectedItem as string;
        }

    }
}