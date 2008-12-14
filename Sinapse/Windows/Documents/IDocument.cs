using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;

namespace Sinapse.Windows.Documents
{
    interface IWorkplaceDocument
    {

        WorkplaceItem Item { get; set; }

        void Save();
        void SaveAs();

     //   string Name { get; }

        ToolStripMenuItem[] MenuItems { get; }
        ToolStrip[] ToolStrips { get; }
    }
}
