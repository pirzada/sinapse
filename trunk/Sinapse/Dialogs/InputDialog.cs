using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Dialogs
{
    sealed public partial class InputDialog : Form
    {

        public static DialogResult Show(string text, string title, string defaultInput, out string userInput)
        {
            InputDialog dialog = new InputDialog();
            dialog.lbText.Text = text;
            dialog.Text = title;
            dialog.tbInput.Text = defaultInput;

            DialogResult result = dialog.ShowDialog();
            userInput = dialog.tbInput.Text;

            return result;
        }


        private InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            tbInput.Focus();
            tbInput.SelectAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



    }
}