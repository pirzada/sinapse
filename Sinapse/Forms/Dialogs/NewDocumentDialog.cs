using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using Sinapse.Core;
using Sinapse.Core.Systems;

namespace Sinapse.Forms.Dialogs
{
    
    public partial class NewDocumentDialog : Form
    {

        private String directory;
        private Type selectedType;
        private DocumentDescription selectedDescription;


        #region Constructor
        public NewDocumentDialog(Type type)
            : this(type, String.Empty)
        {
        }

        public NewDocumentDialog(Type type, String directory)
        {
            if (!type.IsAssignableFrom(typeof(ISinapseDocument)))
                throw new ArgumentException("", "type");

            if (directory == null) directory = String.Empty;


            InitializeComponent();

            IconCache.CreateList(smallIcons, largeIcons);

            createListView(type);
        }
        #endregion



        private void createListView(Type type)
        {
            Type[] documentTypes = Sinapse.Utils.GetTypesImplementingInterface(
              Assembly.GetAssembly(typeof(ISinapseDocument)), type);

            ListViewItem listViewItem;
            ListViewItem.ListViewSubItem subitem;

            foreach (Type documentType in documentTypes)
            {
                object[] attr = documentType.GetCustomAttributes(typeof(DocumentDescription), false);
                if (attr.Length > 0)
                {
                    DocumentDescription desc = attr[0] as DocumentDescription;
                    listViewItem = new ListViewItem(desc.Name);
                    listViewItem.ImageKey = desc.Extension;
                    listViewItem.Tag = documentType;

                    subitem = new ListViewItem.ListViewSubItem(listViewItem, desc.Description);
                    subitem.Name = "Description";
                    listViewItem.SubItems.Add(subitem);
                }
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("Invalid filename");
                return;
            }
            if (Path.GetExtension(tbName.Text).Length > 0)
            {
                MessageBox.Show("The filename should not contain any extensions");
            }

            string path = Path.Combine(directory, tbName.Text + selectedDescription.Extension);
            SinapseDocumentInfo documentInfo = new SinapseDocumentInfo(path, true, selectedType);
            documentInfo.Create();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void btnView_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnViewIcon))
            {
                listView.View = View.LargeIcon;
                btnViewIcon.FlatStyle = FlatStyle.Standard;
                btnViewList.FlatStyle = FlatStyle.Popup;
            }
            else
            {
                listView.View = View.Details;
                btnViewIcon.FlatStyle = FlatStyle.Popup;
                btnViewList.FlatStyle = FlatStyle.Standard;
            }
        }

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int n = 1;

                this.selectedType = listView.SelectedItems[0].Tag as Type;
                this.selectedDescription =
                    selectedType.GetCustomAttributes(typeof(DocumentDescription), false)[0]
                    as DocumentDescription;
                tbDescription.Text = selectedDescription.Description;
                tbName.Text = selectedDescription.DefaultName + n;
            }
        }


    }
}