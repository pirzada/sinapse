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

/***************************************************************************
 * Please note: This class is not covered by the same license (GPL) as     *
 *  the rest of this software and belongs instead to the public domain     *
 ***************************************************************************/

/***************************************************************************
 * This class was loosely based on the original work made by Joe Woodbury  *
 * - http://joewoodbury.net                                                *
 *                                                                         *
 * Original CodeProject Article may be found at                            *
 * - http://www.codeproject.com/KB/cs/mrutoolstripmenu.aspx                *
 *                                                                         *
 ***************************************************************************/
                                                                             
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Sinapse.Forms.Controls
{

    public delegate void MostRecentlyMenuItemClickedEventHandler(string filename);

    /// <summary>
    /// Provides a most recently used (MRU) menu.
    /// </summary>
    public class MostRecentlyProvider : System.ComponentModel.Component
    {

        private ToolStripMenuItem toolStripMenuItem;
        private int maxEntries = 6;
        private int maxShortenPathLength = 96;
        private StringCollection fileList;

        private event MostRecentlyMenuItemClickedEventHandler menuItemClicked;


        //---------------------------------------------


        #region Constructor
        public MostRecentlyProvider()
        {
            
        }
        #endregion


        //---------------------------------------------


        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItemCollection MenuItems
        {
            get { return toolStripMenuItem.DropDownItems; }
        }

        public ToolStripMenuItem MenuItem
        {
            get { return this.toolStripMenuItem; }
            set
            {
                this.toolStripMenuItem = value;
                if (!this.DesignMode)
                {
                    this.UpdateMenu();
                }
            }
        }

        [SettingsBindable(true)]
        public StringCollection FilePathList
        {
            get { return this.fileList; }
            set
            {
                if (!this.DesignMode)
                {
                    if (value == null)
                        value = new StringCollection();

                    this.fileList = value;
                    this.UpdateMenu();
                }
            }
        }

        [DefaultValue(6)]
        public int MaxEntries
        {
            get { return maxEntries; }
            set { this.maxEntries = value; }
        }

        [DefaultValue(96)]
        public int MaxShortenPathLength
        {
            get { return this.maxShortenPathLength; }
            set { this.maxShortenPathLength = value; }
        }

        [Browsable(true)]
        public MostRecentlyMenuItemClickedEventHandler MenuItemClicked
        {
            get { return this.menuItemClicked; }
            set { this.menuItemClicked = value; }
        }

   /* 
        [DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                if (this.toolStripMenuItem != null)
                    return this.toolStripMenuItem.Enabled;
                else return false;
            }
            set
            {
                if (this.toolStripMenuItem != null)
                    this.toolStripMenuItem.Enabled = value;
            }
        }
    */ 
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void Insert(string filename)
        {
            if (this.fileList.Count > this.maxEntries)
                this.fileList.RemoveAt(fileList.Count - 1);

            if (this.fileList.Contains(filename))
                this.fileList.Remove(filename);

            this.fileList.Insert(0,filename);

            this.UpdateMenu();
        }

        /// <summary>
        /// Creates the menu containing the last used files
        /// </summary>
        public void UpdateMenu()
        {
            if (toolStripMenuItem == null)
                return;

            if (fileList.Count == 0)
            {
                toolStripMenuItem.Enabled = false;

            }
            else
            {
                toolStripMenuItem.Enabled = true;

                toolStripMenuItem.DropDownItems.Clear();

                foreach (string filename in fileList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = this.shortenPathname(filename, maxShortenPathLength);
                    item.Tag = filename;
                    item.Click += new EventHandler(fileItem_Click);

                    toolStripMenuItem.DropDownItems.Add(item);
                }
            }
        }
        #endregion


        //---------------------------------------------


        #region Component Events
        private void fileItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (this.menuItemClicked != null)
                this.menuItemClicked.Invoke(menuItem.Tag as String);
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        /// <summary>
        /// Shortens a pathname for display purposes.
        /// </summary>
        private string shortenPathname(string pathname, int maxLength)
        {
            if (pathname.Length <= maxLength)
                return pathname;

            string root = Path.GetPathRoot(pathname);
            if (root.Length > 3)
                root += Path.DirectorySeparatorChar;

            string[] elements = pathname.Substring(root.Length).Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            int filenameIndex = elements.GetLength(0) - 1;

            if (elements.GetLength(0) == 1) // pathname is just a root and filename
            {
                if (elements[0].Length > 5) // long enough to shorten
                {
                    // if path is a UNC path, root may be rather long
                    if (root.Length + 6 >= maxLength)
                    {
                        return root + elements[0].Substring(0, 3) + "...";
                    }
                    else
                    {
                        return pathname.Substring(0, maxLength - 3) + "...";
                    }
                }
            }
            else if ((root.Length + 4 + elements[filenameIndex].Length) > maxLength) // pathname is just a root and filename
            {
                root += "...\\";

                int len = elements[filenameIndex].Length;
                if (len < 6)
                    return root + elements[filenameIndex];

                if ((root.Length + 6) >= maxLength)
                {
                    len = 3;
                }
                else
                {
                    len = maxLength - root.Length - 3;
                }
                return root + elements[filenameIndex].Substring(0, len) + "...";
            }
            else if (elements.GetLength(0) == 2)
            {
                return root + "...\\" + elements[1];
            }
            else
            {
                int len = 0;
                int begin = 0;

                for (int i = 0; i < filenameIndex; i++)
                {
                    if (elements[i].Length > len)
                    {
                        begin = i;
                        len = elements[i].Length;
                    }
                }

                int totalLength = pathname.Length - len + 3;
                int end = begin + 1;

                while (totalLength > maxLength)
                {
                    if (begin > 0)
                        totalLength -= elements[--begin].Length - 1;

                    if (totalLength <= maxLength)
                        break;

                    if (end < filenameIndex)
                        totalLength -= elements[++end].Length - 1;

                    if (begin == 0 && end == filenameIndex)
                        break;
                }

                // assemble final string

                for (int i = 0; i < begin; i++)
                {
                    root += elements[i] + '\\';
                }

                root += "...\\";

                for (int i = end; i < filenameIndex; i++)
                {
                    root += elements[i] + '\\';
                }

                return root + elements[filenameIndex];
            }
            return pathname;
        }
        #endregion


    }
}