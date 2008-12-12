using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Sinapse.Documents
{
    interface IDocument
    {
        void Save();
        void SaveAs();

        ToolStripMenuItem[] MenuItems { get; }
        ToolStrip[] ToolStrips { get; }
    }
}
