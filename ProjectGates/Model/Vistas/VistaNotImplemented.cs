using ProjectGates.Model.Entities.Passive;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaNotImplemented : Vista
    {
        public VistaNotImplemented()
        {
            AddEntity(new Title("Not Implemented"));
            AddEntity(new CenteredField(0.9f, 0.75f));

            Sink.WhenKeyPressed = ((sender, args) =>
            {
                var arguments = (KeyEventArgs)args;
                if (arguments.Code == Keyboard.Key.Escape)
                    Engine.Vista = Engine.SP_Menu;
            });
        }
    }
}
