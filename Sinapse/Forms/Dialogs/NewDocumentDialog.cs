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
        private Workbench workbench;
        private DocumentDescription selectedDescription;



        #region Constructor
        public NewDocumentDialog(Workbench workbench, Type type)
            : this(workbench, type, String.Empty)
        {
        }

        public NewDocumentDialog(Workbench workbench)
            : this(workbench, typeof(ISinapseConcept))
        {
        }

        public NewDocumentDialog(Workbench workbench, Type type, String path)
        {
            if (!typeof(ISinapseConcept).IsAssignableFrom(type))
                throw new ArgumentException("Type must implement the ISinapseConcept interface", "type");

            this.directory = path ?? String.Empty;
            this.workbench = workbench;

            InitializeComponent();

            IconCache.CreateList(smallIcons, largeIcons);

            this.ViewMode = View.LargeIcon;

            createListView(type);
        }
        #endregion




        #region Properties
        public View ViewMode
        {
            get { return listView.View; }
            set
            {
                if (value == View.LargeIcon)
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

                    listView.Items.Add(listViewItem);
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
            SinapseDocumentInfo documentInfo = new SinapseDocumentInfo(path, workbench.Workplace, selectedType);
            documentInfo.Create();
            workbench.OpenDocument(documentInfo);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void btnView_Click(object sender, EventArgs e)
        {

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