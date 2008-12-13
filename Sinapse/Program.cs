/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

using Sinapse.Properties;
using Sinapse.Forms;

namespace Sinapse
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [LoaderOptimization(LoaderOptimization.SingleDomain)]
        static void Main()
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.Initialize();


            Application.Run(new MainForm());
           

            Settings.Default.Save();
            Debug.Listeners.Clear();
        }


        static void Initialize()
        {
            if (Settings.Default.mruDocuments == null)
                Settings.Default.mruDocuments = new System.Collections.Specialized.StringCollection();

            if (Settings.Default.mruWorkplaces == null)
                Settings.Default.mruWorkplaces = new System.Collections.Specialized.StringCollection();

        }

    }
}