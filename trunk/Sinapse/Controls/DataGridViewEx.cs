using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Controls
{
    class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw, true);
        }
    }
}
