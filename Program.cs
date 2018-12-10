using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: xxx <vsqx dir> <output dir>");
            }
            else
            {
                Controller ctrl = new Controller(args[0], args[1]);
                ctrl.run();
            }
        }
    }
}
