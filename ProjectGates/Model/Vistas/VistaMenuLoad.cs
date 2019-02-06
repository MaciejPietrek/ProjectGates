using ProjectGates.Model.Entities.Passive;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaMenuLoad : Vista
    {
        public VistaMenuLoad()
        {
            AddEntity(new Title("Load screen"));
            AddEntity(new CenteredField(0.9f, 0.75f));
        }

        public override void OnKeyPressed(object sender, EventArgs args)
        {
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_Menu;
        }
    }
}
