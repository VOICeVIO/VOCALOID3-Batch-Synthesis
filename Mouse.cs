using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int x
        {
            get
            {
                return this.X;
            }
            set
            {
                this.X = value;
            }
        }
        public int Y;
        public int y
        {
            get
            {
                return this.Y;
            }
            set
            {
                this.Y = value;
            }
        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Mouse
    {
        [DllImport("user32.dll")]
        public static extern bool Get(out Point lpPoint);
        
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        public static void Set(Point pos)
        {
            SetCursorPos(pos.X, pos.Y);
        }
    }
}
