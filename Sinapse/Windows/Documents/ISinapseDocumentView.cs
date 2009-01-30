using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;


namespace Sinapse.Windows.Documents
{
    interface ISinapseDocumentView : IDockContent
    {

        SinapseDocumentInfo Item { get; set; }

        void Save();
        void SaveAs();
        void Show();
        void Close();
        
        bool HasChanges { get; }
        string Name { get; }

        ToolStripMenuItem[] MenuItems { get; }
        ToolStrip[] ToolStrips { get; }
    }
}
