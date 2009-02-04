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

/***************************************************************************
 * This class is not covered by the same license (GPL) as does the rest of *
 * the project, and is scheduled to be transfered to a separate library.   *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sinapse.WinForms.Base
{

    internal class SingleInstanceForm : System.Windows.Forms.Form
    {

        #region Static
        private static bool hasInstance = false;
        private static Form instance = null;

        public static bool HasInstance
        {
            get { return hasInstance; }
        }

        public Form Instance
        {
            get { return instance; }
        }
        #endregion


        //----------------------------------------


        #region Constructor & Destructor
        internal SingleInstanceForm()
        {
            hasInstance = true;
            instance = this;
        }

        ~SingleInstanceForm()
        {
            hasInstance = false;
            instance = null;
        }
        #endregion


        //----------------------------------------


        #region Events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            hasInstance = false;
            instance = null;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            hasInstance = false;
            instance = null;
        }
        #endregion

    }
}
