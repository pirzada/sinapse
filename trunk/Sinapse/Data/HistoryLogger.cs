using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sinapse.Data
{
    static class HistoryLogger
    {

        public static EventHandler NewActionLogged;

        private static string lastLoggedAction = String.Empty;

       
        public static void Write(string text)
        {

            lastLoggedAction = text;

            if (NewActionLogged != null)
                NewActionLogged.Invoke(null, EventArgs.Empty);
        }

        public static string GetLastLoggedAction()
        {
            return lastLoggedAction;
        }

    }
}
