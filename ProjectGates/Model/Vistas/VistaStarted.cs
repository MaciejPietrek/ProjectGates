using ProjectGates.Model.Entities;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaStarted : Vista
    {
        private readonly Resources.ResourceTextures textures = new Resources.ResourceTextures();
        private enum Key
        {
            Background
        }
        private int count = 0;
        public VistaStarted()
        {
            textures.AddResource(Key.Background, ".\\Model\\Resources\\Textures\\BACKGROUND.png");
            AddEntity(new Background(Resources.ResourceTextures.GetGlobalResource(Resources.ResourceTextures.Key.Background)));
            AddEntity(new Background(textures.GetResource(Key.Background), true, false));

            WhenKeyPressed = ((sender, args) =>
            {
                var arguments = args;
                OnDraw += ((target, state) =>
                {
                    int n = 300;
                    var view = Engine.MainWindow.GetView();
                    view.Zoom(0.998f);
                    Engine.MainWindow.SetView(view);
                    count++;
                    foreach (var entity in Entities)
                    {
                        if (entity is ITransparent e)
                            e.Transparency = (PGPercent)(e.Transparency - (float)1 / 200);
                    }
                    if (count >= n)
                    {
                        count = 0;
                        OnDraw = DefaultOnDraw;
                        Engine.Vista = Program.PG_VistaMenu;
                        Engine.MainWindow.SetView(Engine.MainWindow.DefaultView);
                    }
                });
            });
        }
    }
}
