using ProjectGates.Model.Entities;
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
    class VistaStarted : Vista
    {
        private static ResourceTextures textures;

        private int count = 0;

        static VistaStarted()
        {
            textures = new ResourceTextures();
            textures.AddResource(TextureEnum.background, ".\\Model\\Resources\\Textures\\BACKGROUND.png");
        }

        enum TextureEnum
        {
            background
        }

        public VistaStarted()
        {
            AddEntity(new Background(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Background)));
            AddEntity(new Background(textures.GetResource(TextureEnum.background), true, false));

            Sink.WhenKeyPressed = ((sender, args) =>
            {
                var arguments = (KeyEventArgs)args;
                if (arguments.Code == Keyboard.Key.Escape)
                    Engine.Vista = Engine.SP_Closing;
                else
                {
                    Sink.WhenKeyPressed = null;
                    OnDraw += (() =>
                    {
                        int n = 300;
                        var view = Engine.MainWindow.GetView();
                        view.Zoom(0.998f);
                        Engine.MainWindow.SetView(view);
                        count++;
                        foreach (var entity in Entities)
                        {
                            if (entity is ITransparent e)
                                e.Transparency -= (PGPercent)0.005;
                        }
                        if (count >= n)
                        {
                            count = 0;
                            OnDraw = DefaultOnDraw;
                            Engine.SetVista(Engine.SP_Menu, Engine.SP_Menu.OnLoad);
                            Engine.MainWindow.SetView(Engine.MainWindow.DefaultView);
                        }
                    });
                }
            });
        }
    }
}
