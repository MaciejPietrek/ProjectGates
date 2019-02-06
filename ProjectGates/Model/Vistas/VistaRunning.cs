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
        public VistaRunning()
        {
            AddEntity(new Title("Running"));
            AddEntity(new Logo(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Logo)));
        }

        public override void OnKeyPressed(object sender, EventArgs args)
        {
            #region State change
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_PausedMenu;
            #endregion
        }
    }
}
