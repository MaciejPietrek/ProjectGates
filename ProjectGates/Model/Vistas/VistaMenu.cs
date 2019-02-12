using ProjectGates.Model.Entities;
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
    class VistaMenu : Vista
    {
        public Action<RenderTarget, RenderStates> OnLoad;
        private int count = 0;

        public VistaMenu()
        {
            OnLoad = ((state, target) =>
            {
                if (count == 0)
                {
                    foreach (var entity in Entities)
                    {
                        if (entity is ITransparent e)
                            e.Transparency = 0;
                    }
                }
                foreach (var entity in Entities)
                {
                    if (entity is ITransparent e)
                        e.Transparency = e.Transparency + 0.02f;
                }
                count++;
                if (count >= 100)
                {
                    count = 0;
                    OnDraw = DefaultOnDraw;
                }
            });

            OnDraw = OnLoad;
            OnDraw += DefaultOnDraw;

            AddEntity(new Background(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Background)));

            var button1 = new Button("Continue", 0.05f, 0.3f, 0.1f);
            var button2 = new Button("New", 0.05f, 0.3f, 0.15f);
            var button3 = new Button("Load", 0.05f, 0.3f, 0.2f);
            var button4 = new Button("Settings", 0.05f, 0.3f, 0.25f);
            var button5 = new Button("Exit", 0.05f, 0.3f, 0.30f);
            button5.WhenMouseButtonPressed = ((sender, args) =>
            {
                if(button5.Field.Contains(new PGPoint(args.X, args.Y)))
                    Engine.MainWindow.Close();
            });
            AddEntity(button1);
            AddEntity(button2);
            AddEntity(button3);
            AddEntity(button4);
            AddEntity(button5);

        }
        
    }
}