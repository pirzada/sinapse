using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Sinapse.Core;
using Sinapse.Core.Filters;

namespace Sinapse.WinForms.Documents.Systems.Controls
{
    public partial class FilterSequence : UserControl
    {

        FilterCollection filters;


        public FilterSequence()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;

            updateList();
            UpdateMenu();
        }



        public FilterCollection Filters
        {
            get { return filters; }
            set
            {
                if (filters != value)
                {
                    filters = value;
                    dataGridView.DataSource = filters;
                    filters.ListChanged += new ListChangedEventHandler(filters_ListChanged);
                    updateList();
                }
            }
        }

        void filters_ListChanged(object sender, ListChangedEventArgs e)
        {
            updateList();
        }

        void updateList()
        {
            if (filters == null || filters.Count == 0)
            {
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
            }
        }


        public void UpdateMenu()
        {
            Type[] filters = FilterCollection.GetAllFilters();

            ToolStripItem item;
            menuAddFilter.DropDownItems.Clear();
            foreach (Type filterType in filters)
            {
                object[] attr = filterType.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if (attr.Length > 0)
                {
                    DisplayNameAttribute displayNameAttr = attr[0] as DisplayNameAttribute;

                    item = new ToolStripButton(displayNameAttr.DisplayName);
                    item.Tag = filterType;
                    item.Click += new EventHandler(item_Click);
                    menuAddFilter.DropDownItems.Add(item);
                }
            }
            menuAddFilter.DropDownItems.Add(new ToolStripSeparator());
            
            item = new ToolStripButton("Update");
            item.Click +=new EventHandler(updateMenu_Click);
            menuAddFilter.DropDownItems.Add(item);
        }


        void updateMenu_Click(object sender, EventArgs e)
        {
            UpdateMenu();
        }

        void item_Click(object sender, EventArgs e)
        {
            Type filterType = (sender as ToolStripItem).Tag as Type;
            IFilter filter = (IFilter)Activator.CreateInstance(filterType);
            filters.Add(filter);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int currentIndex = dataGridView.SelectedCells[0].RowIndex;
                swap(currentIndex, currentIndex - 1);
                dataGridView.Rows[currentIndex].Selected = false;
                dataGridView.Rows[currentIndex - 1].Selected = true;
            }
            
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int currentIndex = dataGridView.SelectedCells[0].RowIndex;
                swap(currentIndex, currentIndex + 1);
                dataGridView.Rows[currentIndex].Selected = false;
                dataGridView.Rows[currentIndex + 1].Selected = true;
            }
        }


        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                btnMoveUp.Enabled = (dataGridView.SelectedCells[0].RowIndex > 0);
                btnMoveDown.Enabled = (dataGridView.SelectedCells[0].RowIndex < dataGridView.Rows.Count - 1);
            }
            else
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
            }
        }


        private void swap(int i, int j)
        {
            IFilter temp = filters[i];
            filters[i] = filters[j];
            filters[j] = filters[i];
        }

    }
}
