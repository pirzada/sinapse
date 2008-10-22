using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core
{
    public class SystemOutput : SystemInputOutput
    {
    }

    public class SystemOutputCollection : System.ComponentModel.BindingList<SystemOutput>
    {
    }
}
