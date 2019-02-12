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
        static void Main()
        {
            Engine engine = Engine.Instance;
            engine.Run();
        }
    }
}
