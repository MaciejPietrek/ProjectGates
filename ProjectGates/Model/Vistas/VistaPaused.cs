using ProjectGates.Model.Entities;
using ProjectGates.Model.Entities.Active;
using ProjectGates.Model.Entities.Passive;
using ProjectGates.Model.Resources;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaPaused : Vista
    {
        public VistaPaused()
        {
            var button1 = new Button("return", 0.05f, 0.0f, 0.95f);
            AddEntity(new Background(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Background)));
            AddEntity(new Title("Paused"));
            AddEntity(new CenteredField(0.9f, 0.75f));
            AddEntity(new Logo(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Logo)));
            AddEntity(button1).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button1.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = new VistaRunning();
                }
            });
        }

        public override void OnKeyPressed(object sender, EventArgs args)
        {
            #region State change
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Space)
                Engine.Vista = Engine.SP_Running;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_Menu;
            #endregion
        }
    }
}
