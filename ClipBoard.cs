using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    class ClipBoard
    {
        [DllImport("User32")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32")]
        internal static extern bool CloseClipboard();

        [DllImport("User32")]
        internal static extern bool EmptyClipboard();

        [DllImport("User32")]
        internal static extern bool IsClipboardFormatAvailable(int format);

        [DllImport("User32")]
        internal static extern IntPtr GetClipboardData(int uFormat);

        [DllImport("User32", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetClipboardData(int uFormat, IntPtr hMem);

        public static void Set(string text)
        {
            if (!OpenClipboard(IntPtr.Zero))
            {
                Set(text);
                return;
            }
            EmptyClipboard();
            SetClipboardData(13, Marshal.StringToHGlobalUni(text));
            CloseClipboard();
        }

        public static string Get(int format = 13)
        {
            string value = string.Empty;
            OpenClipboard(IntPtr.Zero);
            if (IsClipboardFormatAvailable(format))
            {
                IntPtr ptr = GetClipboardData(format);
                if (ptr != IntPtr.Zero)
                {
                    value = Marshal.PtrToStringUni(ptr);
                }
            }
            CloseClipboard();
            return value;
        }
    }
}
