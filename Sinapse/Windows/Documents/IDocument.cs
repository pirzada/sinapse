using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Sinapse.Windows.Documents
{
    interface IWorkplaceDocument
    {
        
        void Save();
        void SaveAs();

     //   string Name { get; }

        ToolStripMenuItem[] MenuItems { get; }
        ToolStrip[] ToolStrips { get; }
    }
}
