using ProjectGates.Model;
using ProjectGates.Model.Resources;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string sClassm, string sWindow);

        static void Main()
        {
            Engine engine = Engine.Instance;
            engine.Run();
        }
    }
}
