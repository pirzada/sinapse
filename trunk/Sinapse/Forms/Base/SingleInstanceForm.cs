/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
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
using System.Text;
using System.Windows.Forms;

namespace Sinapse.Forms.Base
{

    internal class SingleInstanceForm : System.Windows.Forms.Form
    {

        #region Static
        private static bool hasInstance = false;

        public static bool HasInstance
        {
            get { return hasInstance; }
        }
        #endregion


        //----------------------------------------


        #region Constructor & Destructor
        internal SingleInstanceForm()
        {
            hasInstance = true;
        }

        ~SingleInstanceForm()
        {
            hasInstance = false;
        }
        #endregion


        //----------------------------------------


        #region Events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            hasInstance = false;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            hasInstance = false;
        }
        #endregion

    }
}
