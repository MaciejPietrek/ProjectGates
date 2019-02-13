using ProjectGates.Model;
using ProjectGates.Model.Resources;
using ProjectGates.Model.Vistas;
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
        public static VistaStarted PG_VistaStarted;
        public static VistaMenu PG_VistaMenu;

        static void Main()
        {

            PG_VistaStarted = new VistaStarted();
            PG_VistaMenu = new VistaMenu();

            Engine.Vista = PG_VistaStarted;

            Engine engine = Engine.Instance;
            engine.Run();
        }
    }
}
