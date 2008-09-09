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

    public delegate void MruMenuItemClickedEventHandler(string filename);

    /// <summary>
    ///  Provides a Most Recently Used (MRU) menu to be used in a Windows Forms environment.
    /// </summary>
    public class MruProvider : System.ComponentModel.Component
    {

        private int maxEntries = 6;
        private int maxShortenPathLength = 96;
        private bool inline;

        private ToolStripMenuItem  keyMenuItem;
        private List<ToolStripMenuItem> menuItemCollection;
        private StringCollection        filePathCollection;

        public event MruMenuItemClickedEventHandler MenuItemClicked;





        #region Constructor
        /// <summary>
        ///   Constructs a new Most Recently Used Menu provider.
        /// </summary>
        public MruProvider()
        {
           this.menuItemCollection = new List<ToolStripMenuItem>();
        }
        #endregion





        #region Properties
        /// <summary>
        ///   Gets a list of menu items currently created by this component.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripMenuItem[] GetMenuItems()
        {
            return menuItemCollection.ToArray();
        }

        /// <summary>
        ///  Gets or sets a ToolStripMenuItem to be used as key. If Inline mode is
        ///   set to false, the Most Recently Used list will be created inside in a
        ///   menu inside this menu item. If Inline mode is set to true, the Most
        ///   Recently Used list will be placed right below this menu item.
        /// </summary>
        [DefaultValue(null)]
        public ToolStripMenuItem KeyMenuItem
        {
            get { return this.keyMenuItem; }
            set
            {
                if (this.keyMenuItem != value)
                {
                    this.keyMenuItem = value;

                    if (!this.DesignMode)
                    {
                        if (keyMenuItem != null)
                            this.UpdateMenu();
                    }
                }
            }
        }

        /// <summary>
        ///  Gets or sets the Most Recently Used list as a StringCollection.
        ///  This property can be bound to a Visual Studio Setting to provide
        ///  automatic local storage. The StringCollection must be initialized
        ///  first, or the property binding will not work.
        /// </summary>
        [SettingsBindable(true)]
        public StringCollection FileList
        {
            get { return this.filePathCollection; }
            set
            {
                if (!this.DesignMode)
                {
                    if (value == null)
                        throw new ArgumentNullException();

                    this.filePathCollection = value;

                    if (keyMenuItem != null)
                      this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets the maximum number of entries to
        ///   be listed on the Most Recently Used list.
        /// </summary>
        [DefaultValue(6)]
        public int MaxEntries
        {
            get { return this.maxEntries; }
            set
            {
                this.maxEntries = value;

                if (!this.DesignMode)
                {
                    this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets the maximum shortened path length
        ///   to be displayed on the Most Recently Used list.
        /// </summary>
        [DefaultValue(96)]
        public int MaxShortenPathLength
        {
            get { return this.maxShortenPathLength; }
            set
            {
                this.maxShortenPathLength = value;
                if (!this.DesignMode)
                {
                    this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets a boolean value indicating the operation
        ///   mode for this control. Set this to true to create the 
        ///   Most Recently Used list below the key menu item informed by the
        ///   KeyMenuItem property. Set this to false to create the Most
        ///   Recently Used list inside the key menu item informed by the
        ///   KeyMenuItem property instead.
        /// </summary>
        [DefaultValue(false)]
        public bool Inline
        {
            get { return this.inline; }
            set
            {
                this.inline = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                        this.UpdateMenu();
                }
            }
        }
        #endregion





        /// <summary>
        ///   Inserts a new file on the top of the Most Recently Used list.
        /// </summary>
        /// <param name="filename"></param>
        #region Public Methods
        public void Insert(string filename)
        {
            if (this.filePathCollection.Count > this.maxEntries)
                this.filePathCollection.RemoveAt(filePathCollection.Count - 1);

            if (this.filePathCollection.Contains(filename))
                this.filePathCollection.Remove(filename);

            this.filePathCollection.Insert(0, filename);

            this.UpdateMenu();
        }

        /// <summary>
        ///   Updates the created menu.
        /// </summary>
        public void UpdateMenu()
        {
            if (keyMenuItem == null)
                throw new InvalidOperationException();

            this.Clear();

            if (filePathCollection != null && filePathCollection.Count > 0)
            {
                if (!this.inline)
                    this.keyMenuItem.Enabled = true;

                // Creates the menu items
                foreach (string filename in this.filePathCollection)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = this.shortenPathname(filename, maxShortenPathLength);
                    item.Tag = filename;
                    item.Click += new EventHandler(fileMenuItem_Click);

                    // Keeps track of all created menu items.
                    this.menuItemCollection.Add(item);
                }

                if (inline)
                {
                    int keyIndex = keyMenuItem.Owner.Items.IndexOf(keyMenuItem);

                    // Adds each most recently used entry below the key menu item.
                    for (int i = 0; i < this.menuItemCollection.Count; i++)
                    {
                        keyMenuItem.Owner.Items.Insert(keyIndex + i + 1, this.menuItemCollection[i]);
                    }
                }
                else
                {
                    // Adds the most recently used entry list inside the key menu item.
                    keyMenuItem.DropDownItems.AddRange(this.menuItemCollection.ToArray());
                }
            }
            else
            {
                if (!this.inline)
                    this.keyMenuItem.Enabled = false;
            }
        }

        /// <summary>
        ///   Clears the Most Recently Used list.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.menuItemCollection.Count; i++)
            {
                this.menuItemCollection[i].Owner.Items.Remove(menuItemCollection[i]);
            }
            this.menuItemCollection.Clear();
        }
        #endregion


       


        #region Component Events
        private void fileMenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (this.MenuItemClicked != null)
                this.MenuItemClicked.Invoke(menuItem.Tag as String);
        }
        #endregion


       



        #region Private Methods
        /// <summary>
        ///   Shortens a pathname for display purposes.
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