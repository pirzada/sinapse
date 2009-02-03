using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Sinapse.Core
{
    public static class IconCache
    {

        #region Native Methods
        [DllImport("shell32.dll")]
        private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);
        #endregion

        private static Dictionary<String, Icon> smallIcons; // <extension, icon>
        private static Dictionary<String, Icon> largeIcons;
        

        public static Icon GetIcon(string path, int index)
        {
            IntPtr processHandle = System.Diagnostics.Process.GetCurrentProcess().Handle;
            IntPtr oPtr = ExtractIcon(processHandle, path, index);
            if (oPtr != IntPtr.Zero)
                return Icon.FromHandle(oPtr);
            else return null;
        }


        public static void Build()
        {
            smallIcons = new Dictionary<String, Icon>();
            largeIcons = new Dictionary<String, Icon>();

            IntPtr processHandle = System.Diagnostics.Process.GetCurrentProcess().Handle;
            IntPtr iconPtr;

            foreach (Type type in DocumentCache.TypeList)
            {
                object[] attr = type.GetCustomAttributes(typeof(DocumentDescription), false);
                if (attr.Length > 0)
                {
                    DocumentDescription desc = (attr[0] as DocumentDescription);
                    iconPtr = ExtractIcon(processHandle, desc.SmallIconPath, desc.SmallIconIndex);
                    if (iconPtr != IntPtr.Zero)
                        smallIcons.Add(desc.Extension, Icon.FromHandle(iconPtr));

                    iconPtr = ExtractIcon(processHandle, desc.LargeIconPath, desc.LargeIconIndex);
                    if (iconPtr != IntPtr.Zero)
                        largeIcons.Add(desc.Extension, Icon.FromHandle(iconPtr));
                }
            }
        }

        public static void CreateList(ImageList smallImages, ImageList largeImages)
        {
            if (smallIcons == null || largeIcons == null) Build();

            foreach (String ext in DocumentCache.Extensions)
            {
                smallImages.Images.Add(ext, smallIcons[ext]);
                largeImages.Images.Add(ext, largeIcons[ext]);
            }
        }


    }
}
