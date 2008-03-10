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
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sinapse.Controls
{

    public class DataGridViewEx : DataGridView
    {

        private bool m_enableCopy = true;
        private bool m_enablePaste = true;


        //----------------------------------------


        #region Constructor
        public DataGridViewEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw, true);

        }
        #endregion


        //----------------------------------------


        #region Properties
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowAutoClipboardPaste
        {
            get { return m_enablePaste; }
            set { m_enablePaste = value; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowAutoClipboardCopy
        {
            get { return m_enableCopy; }
            set { m_enableCopy = value; }
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void CopyToClipboard()
        {
            DataObject d = this.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }

        public void PasteFromClipboard()
        {
            string s = Clipboard.GetText();
            string[] lines = s.Split('\n');
            int row = this.CurrentCell.RowIndex;
            int col = this.CurrentCell.ColumnIndex;

            foreach (string line in lines)
            {

                if (row < this.RowCount && line.Length > 0)
                {
                    string[] cells = line.Split('\t');

                    for (int i = 0; i < cells.GetLength(0); i++)
                    {
                        if (col + i < this.ColumnCount)
                        {
                            this[col + i, row].Value = Convert.ChangeType(cells[i], this[col + i, row].ValueType);
                        }
                    }
                    ++row;
                }
            }
        }
        #endregion


        //----------------------------------------

        
        /// <summary>
        /// Provides paste support for the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (this.m_enableCopy && e.Control && e.KeyCode == Keys.C)
            {
                this.CopyToClipboard();
                e.Handled = true;
            }
            else if (this.m_enablePaste && e.Control && e.KeyCode == Keys.V)
            {
                this.PasteFromClipboard();
            }
        }
    }
}
