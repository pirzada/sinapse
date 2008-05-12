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
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;

using Microsoft.Office.Core;


namespace Sinapse.ExcelExtension.Forms
{

    internal sealed partial class ExcelAnchor
    {

        private Excel.Application objApp;
        private CommandBar MainMenuBar;
        private CommandBarControl MenuSinapse;
        private CommandBarButton MenuSinapseMark;
        private CommandBarButton MenuSinapseMarkValidation;
        private CommandBarButton MenuSinapseMarkTraining;
        private CommandBarButton MenuSinapseMarkTesting;
        private CommandBarButton MenuSinapseAbout;



        private void InitializeHook()
        {
            try
            {
                //
                // objApp
                //
                objApp = new Excel.Application();
                // 
                // MainMenuBar
                // 
                MainMenuBar = objApp.CommandBars["Worksheet Menu Bar"];
                // 
                // MenuSinapse
                // 
                MenuSinapse = MainMenuBar.Controls.Add(
                    MsoControlType.msoControlPopup,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapse.Caption = "Sinapse";
                // 
                // MenuSinapseMark
                // 
                MenuSinapseMark = (CommandBarButton)((CommandBarPopup)MenuSinapse).Controls.Add(
                    MsoControlType.msoControlButton,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapseMark.Caption = "Choose columns as...";

              /*// 
                // MenuSinapseMarkTraining
                // 
                MenuSinapseMarkTraining = (CommandBarButton)((CommandBarPopup)MenuSinapseMark).Controls.Add(
                    MsoControlType.msoControlButton,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapseMarkTraining.Caption = "Training";
                // 
                // MenuSinapseMarkValidation
                // 
                MenuSinapseMarkValidation = (CommandBarButton)((CommandBarPopup)MenuSinapseMark).Controls.Add(
                    MsoControlType.msoControlButton,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapseMarkValidation.Caption = "Validation";
                // 
                // MenuSinapseMarkTesting
                // 
                MenuSinapseMarkTesting = (CommandBarButton)((CommandBarPopup)MenuSinapseMark).Controls.Add(
                    MsoControlType.msoControlButton,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapseMarkTesting.Caption = "Testing";
           */   // 
                // MenuSinapseAbout
                // 
                MenuSinapseAbout = (CommandBarButton)((CommandBarPopup)MenuSinapse).Controls.Add(
                    MsoControlType.msoControlButton,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    true);
                MenuSinapseAbout.Caption = "About";
                MenuSinapseAbout.Click += new _CommandBarButtonEvents_ClickEventHandler(MenuSinapseAbout_Click);


                objApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        
    }
}
