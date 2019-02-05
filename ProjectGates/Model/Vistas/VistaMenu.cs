using ProjectGates.Model.Entities;
using ProjectGates.Model.Entities.Active;
using ProjectGates.Model.Entities.Passive;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaMenu : Vista
    {
        public VistaMenu()
        {
            var button1 = new Button("Continue", 0.05f, 0.3f, 0.1f);
            var button2 = new Button("New", 0.05f, 0.3f, 0.15f);
            var button3 = new Button("Load", 0.05f, 0.3f, 0.2f);
            var button4 = new Button("Settings", 0.05f, 0.3f, 0.25f);
            var bg      = new Background(Resources.ResourceHolderTextures.UniHolder.GetResource(Resources.ResourceHolderTextures.Key.Background));
            var title   = new Title("Main Menu");
            var logo    = new Logo(Resources.ResourceHolderTextures.UniHolder.GetResource(Resources.ResourceHolderTextures.Key.Logo));
            var field   = new CenteredField(0.4f, 0.8f);
            AddEntity(bg);
            AddEntity(title);
            AddEntity(logo);
            AddEntity(field); 
            AddEntity(button1).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button1.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = Engine.SP_Running;
                }
            });
            AddEntity(button2).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button2.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = new VistaNotImplemented();
                }
            });
            AddEntity(button3).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button3.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = new VistaMenuLoad();
                }
            });
            AddEntity(button4).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button4.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = new VistaMenuSettings();
                }
            });
        }


        public override void OnKeyPressed(object sender, EventArgs args)
        {
            #region State change
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_Closing;
            #endregion
            base.OnKeyPressed(sender, args);
        }
    }
}