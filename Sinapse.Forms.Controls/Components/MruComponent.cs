/*******************************************************************************
 *  The MIT License                                                            *
 *                                                                             *
 *  Yet Another Most Recently Used Menu Component for Windows.Forms (.NET 2.0) *                                           *
 *  Copyright (c) 2008 César Roberto de Souza <cesarsouza@gmail.com>           *
 *                                                                             *
 *  Permission is hereby granted, free of charge, to any person obtaining a    *
 *  copy of this software and associated documentation files (the "Software"), *
 *  to deal in the Software without restriction, including without limitation  *
 *  the rights to use, copy, modify, merge, publish, distribute, sublicense,   *
 *  and/or sell copies of the Software, and to permit persons to whom the      *
 *  Software is furnished to do so, subject to the following conditions:       *
 *                                                                             *
 *   The above copyright notice and this permission notice shall be included   *
 *   in all copies or substantial portions of the Software.                    *
 *                                                                             *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR *
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,   *
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL    *
 *  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER *
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING    *
 *  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER        *
 *  DEALINGS IN THE SOFTWARE.                                                  *
 *                                                                             * 
 *******************************************************************************/

/*******************************************************************************
 *  This class was loosely based on work made by Joe Woodbury                  *
 *   - http://joewoodbury.net                                                  *
 *                                                                             *
 *  Original CodeProject Article may be found at                               *
 *   - http://www.codeproject.com/KB/cs/mrutoolstripmenu.aspx                  *
 *                                                                             *
 *******************************************************************************/

using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.IO;


namespace Sinapse.WinForms.Controls
{

    /// <summary>
    ///   Represents the method that will handle
    ///   the MenuItemClicked of a MruComponent.
    /// </summary>
    /// <param name="filename">
    ///   The full path for the clicked item filename.
    /// </param>
    public delegate void MruMenuItemClickedEventHandler(string filename);

    /// <summary>
    ///   Specifies whether the Most Recently Used menu should
    ///   be created below, above, or as a DropDown menu inside
    ///   the ToolStripMenuItem specified by the KeyMenuItem
    ///   property.
    /// </summary>
    public enum MruMenuLocation
    {
        /// <summary>
        ///   Creates the Most Recently Used menu above the
        ///   ToolStriMenuItem specified by the KeyMenuItem
        ///   property.
        /// </summary>
        Above,

        /// <summary>
        ///   Creates the Most Recently Used menu inside the
        ///   ToolStriMenuItem specified by the KeyMenuItem
        ///   property.
        /// </summary>
        Inside,

        /// <summary>
        ///   Creates the Most Recently Used menu below the
        ///   ToolStriMenuItem specified by the KeyMenuItem
        ///   property.
        /// </summary>
        Below,
    }

    /// <summary>
    ///  Provides a Most Recently Used (MRU) menu that can
    ///  be used in a Windows.Forms environment.
    /// </summary>
    public class MruComponent : System.ComponentModel.Component
    {

        private int maxEntries = 6;
        private int maxPathLength = 96;
        private bool showIndex = true;
        private bool enabled = true;
        private bool disableWhenEmpty = true;
        private MruMenuLocation layout = MruMenuLocation.Inside;
  
        private ToolStripMenuItem keyMenuItem;
        private List<ToolStripMenuItem> menuItems;
        private StringCollection lastFilePaths;



        #region Constructor
        /// <summary>
        ///   Constructs a new Most Recently Used Menu provider.
        /// </summary>
        public MruComponent()
        {
           this.menuItems = new List<ToolStripMenuItem>();
        }
        #endregion



        #region Properties
        /// <summary>
        ///   Occurs when a generated recent file menu item is clicked.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when a generated recent file menu item is clicked.")]
        public event MruMenuItemClickedEventHandler MenuItemClicked;

        /// <summary>
        ///   Gets or sets a ToolStripMenuItem to be used as key. Depending on how the
        ///   MenuLayout property is set, the Most Recently Used Menu may be created below,
        ///   above, or inside this ToolStripMenuItem as a DropDown Menu.
        /// </summary>
        [Category("Data")]
        [Description("The Key ToolStripMenuItem used to indicate where the Most Recently Used menu will be generated.")]
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
                        if (this.keyMenuItem != null)
                            this.UpdateMenu();
                    }
                }
            }
        }

        /// <summary>
        ///  Gets or sets the Most Recently Used list as a StringCollection.
        ///  This property can be bound to an Application Setting providing
        ///  automatic local storage. The StringCollection must be initialized
        ///  first, or the property binding will not work. Please do not insert
        ///  files directly on this collection, use the Insert() method instead.
        /// </summary>
        /// <remarks>
        ///  Any manual changes made to this object will not be reflected
        ///  on the generated ToolStripMenu until UpdateMenu() is called.
        /// </remarks>
        [Category("Data")]
        [Description("The Most Recently Used file list. This value can be bound to an Application Setting.")]
        [SettingsBindable(true)]
        public StringCollection Files
        {
            get { return this.lastFilePaths; }
            set
            {
                if (!this.DesignMode)
                {
                    if (value == null)
                        throw new ArgumentNullException();

                    this.lastFilePaths = value;

                    if (keyMenuItem != null)
                      this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets the maximum number of recently used files
        ///   to be remembered by the Most Recently Used file list.
        /// </summary>
        [Category("Appearance")]
        [Description("The maximum number of recently used files that should be kept on the list.")]
        [DefaultValue(6)]
        public int MaxItemCount
        {
            get { return this.maxEntries; }
            set
            {
                this.maxEntries = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                    this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets the maximum shortened path length
        ///   to be displayed on the Most Recently Used list.
        /// </summary>
        [Category("Appearance")]
        [Description("The maximum path length displayed by a file entry on the generated menu.")]
        [DefaultValue(64)]
        public int MaxPathLength
        {
            get { return this.maxPathLength; }
            set
            {
                this.maxPathLength = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                    this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating where the Most Recently Used
        ///   should be created below, above, or as a DropDown menu inside
        ///   the ToolStripMenuItem specified by the KeyMenuItem property.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether the Most Recently Used menu should be created" + 
            " below, above, or as a DropDown menu inside  the ToolStripMenuItem" +
            " specified by the KeyMenuItem property.")]
        [DefaultValue(MruMenuLocation.Inside)]
        public MruMenuLocation MenuLocation
        {
            get { return this.layout; }
            set
            {
                this.layout = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                        this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets a boolean value indicating whether the index
        ///   number for the recently used file should be shown on the 
        ///   ToolStripMenuItem text.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether a index number should be shown before the file name in the menu list entries.")]
        [DefaultValue(true)]
        public bool ShowIndex
        {
            get { return this.showIndex; }
            set
            {
                this.showIndex = value; 

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                        this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets a boolean value indicating whether the created
        ///   ToolStripMenuItems can respond to user interaction.
        /// </summary>
        [Category("Behaviour")]
        [Description("Indicates whether the created menu items can respond to user interaction.")]
        [DefaultValue(true)]
        public bool Enabled
        {
            get { return this.enabled; }
            set
            {
                this.enabled = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                        this.UpdateMenu();
                }
            }
        }

        /// <summary>
        ///   Gets or sets a boolean value indicating whether the key
        ///   MenuItem should be disabled when the file list is empty.
        /// </summary>
        [Category("Behaviour")]
        [Description("Indicates whether the Key ToolStripMenuItem should be disabled when the file list is empty.")]
        [DefaultValue(true)]
        public bool DisableWhenEmpty
        {
            get { return this.disableWhenEmpty; }
            set
            {
                this.disableWhenEmpty = value;

                if (!this.DesignMode)
                {
                    if (this.keyMenuItem != null)
                        this.UpdateMenu();
                }
            }
        }
        #endregion


        
        #region Public Methods
        /// <summary>
        ///   Inserts a new file on the top of the Most Recently Used list.
        /// </summary>
        /// <param name="filename"></param>
        public void Insert(string filename)
        {
            if (this.lastFilePaths.Count > this.maxEntries)
                this.lastFilePaths.RemoveAt(lastFilePaths.Count - 1);

            if (this.lastFilePaths.Contains(filename))
                this.lastFilePaths.Remove(filename);

            this.lastFilePaths.Insert(0, filename);

            this.UpdateMenu();
        }

        /// <summary>
        ///   Updates the created menu.
        /// </summary>
        public void UpdateMenu()
        {
            if (this.keyMenuItem == null)
                throw new InvalidOperationException(
                    "The KeyMenuItem should be set before calling UpdateMenu()");

            // Clears the current menu items before updating
            this.clearMenu();

            if (lastFilePaths != null && lastFilePaths.Count > 0)
            {
                this.keyMenuItem.Enabled = !this.disableWhenEmpty;

                // Re-creates the menu items
                for (int i = 0; i < this.lastFilePaths.Count; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();

                    if (this.showIndex)
                        item.Text = i + 1 + " ";
                    item.Text += this.shortenPathname(this.lastFilePaths[i], maxPathLength);
                    item.Tag = this.lastFilePaths[i];
                    item.Click += new EventHandler(fileMenuItem_Clicked);
                    item.Enabled = this.enabled;

                    // Keep track of all created menu items.
                    this.menuItems.Add(item);
                }

                if (this.layout == MruMenuLocation.Inside)
                {
                    // Adds the most recently used entry list inside the key menu item.
                    keyMenuItem.DropDownItems.AddRange(this.menuItems.ToArray());
                }
                else
                {
                    int keyIndex = keyMenuItem.Owner.Items.IndexOf(keyMenuItem);

                    if (this.layout == MruMenuLocation.Below)
                    {
                        // Adds each most recently used entry below the key menu item.
                        for (int i = 0; i < this.menuItems.Count; i++)
                        {
                            keyMenuItem.Owner.Items.Insert(keyIndex + i + 1, this.menuItems[i]);
                        }
                    }
                    else
                    {
                        // Adds each most recently used entry above the key menu item.
                        for (int i = 0; i < this.menuItems.Count; i++)
                        {
                            keyMenuItem.Owner.Items.Insert(keyIndex + i, this.menuItems[i]);
                        }
                    }
                }
            }
            else
            {
                this.keyMenuItem.Enabled = !this.disableWhenEmpty;
            }
        }

        /// <summary>
        ///   Clears the Most Recently Used file list.
        /// </summary>
        public void Clear()
        {
            this.lastFilePaths.Clear();
            this.UpdateMenu();
        }

        /// <summary>
        ///   Creates a array of menu items currently handled by this component.
        /// </summary>
        public ToolStripMenuItem[] GetMenuItems()
        {
            return this.menuItems.ToArray();
        }
        #endregion

        
                
        #region Private Methods
        /// <summary>
        ///   Clears the most recently used ToolStripMenuItem list.
        /// </summary>
        private void clearMenu()
        {
            for (int i = 0; i < this.menuItems.Count; i++)
            {
                this.menuItems[i].Owner.Items.Remove(menuItems[i]);
            }
            this.menuItems.Clear();
        }

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

        /// <summary>
        ///   Called whenever a generated ToolStripMenuItem
        ///   containing a recently used file path is clicked.
        /// </summary>
        private void fileMenuItem_Clicked(object sender, System.EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            // The Tag property stores the full file path for the
            // recently used file linked to this ToolStripMenuItem.

            if (this.MenuItemClicked != null)
                this.MenuItemClicked.Invoke(menuItem.Tag as String);
        }
        #endregion


    }
}