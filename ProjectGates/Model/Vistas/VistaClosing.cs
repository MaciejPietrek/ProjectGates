using ProjectGates.Model.Entities;
using ProjectGates.Model.Entities.Active;
using ProjectGates.Model.Entities.Passive;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaClosing : Vista
    {
        public VistaClosing()
        {
            var button1 = new Button("Are you sure?", 0.05f, 0.0f, 0.10f);
            var button2 = new Button("No, I want to return :)", 0.05f, 0.0f, 0.15f);
            var button3 = new Button("Hell yeah!", 0.05f, 0.0f, 0.20f);
            AddEntity(new Title("It has been good to have You here :)"), "Title");
            AddEntity(button1).AsEventSink().WhenMouseMoved = null;
            AddEntity(button2).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button2.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.Vista = Engine.SP_Menu;
                }
            });
            AddEntity(button3).AsEventSink().WhenMousePressed = ((sender, args) =>
            {
                var rectangle = button3.Field;
                var argument = (MouseButtonEventArgs)args;
                if (rectangle.Contains(argument.X, argument.Y))
                {
                    Engine.MainWindow.Close();
                }
            });
        }
    }
}
