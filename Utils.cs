using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Utils
    {
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, short State);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public static string GetTitle(IntPtr hWnd)
        {
            StringBuilder s = new StringBuilder(512);
            int i = GetWindowText(hWnd, s, s.Capacity);
            return s.ToString();
        }
        public static bool Focus(IntPtr hWnd)
        {
            ShowWindow(hWnd, 1);
            return SetForegroundWindow(hWnd);
        }
    }
}
