using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Dotnetrix.Controls;

namespace Sinapse.Controls.TrainingTabs
{
    public partial class TrainingTabCreator
    {
        public TrainingTabCreator()
        {
            
            
        }

        public TabPage CreateTab(UserControl control, string text, int imageIndex)
        {
            TabPageEX tabPage = new TabPageEX(text);
            tabPage.ImageIndex = imageIndex;
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);           
        }
    }
}