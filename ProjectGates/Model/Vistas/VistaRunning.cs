using ProjectGates.Model.Entities.Active;
using ProjectGates.Model.Entities.Passive;
using ProjectGates.Model.Resources;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaRunning : Vista
    {
        private ResourceTextures Textures { get; set; }


        public VistaRunning()
        {
            AddEntity(new Title("Running"));
            AddEntity(new Logo(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Logo)));
            AddEntity(new PointGrid(15)).AsEventSink().Connect(Hub);

            Sink.WhenKeyPressed = ((sender, args) =>
            {
                var arguments = (KeyEventArgs)args;
                if (arguments.Code == Keyboard.Key.Escape)
                    Engine.Vista = Engine.SP_PausedMenu;
            });

            Sink.WhenKeyReleassed = ((sender, args) =>
            {
                var arg = (KeyEventArgs)args;
                Console.WriteLine(arg.Code.ToString());
            });
        }
    }
}
