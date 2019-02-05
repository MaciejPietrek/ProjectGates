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
        }

        public override void OnKeyPressed(object sender, EventArgs args)
        {
            #region State change
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_Closing;
            else
            {
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
                            e.Transparency = (PGPercent)((float)e.Transparency - (float)1 / 200);
                    }
                    if (count >= n)
                    {
                        count = 0;
                        OnDraw = DefaultOnDraw;
                        Engine.SetVistaBefore(Engine.SP_Menu, Engine.SP_Menu.OnLoad);
                        Engine.MainWindow.SetView(Engine.MainWindow.DefaultView);
                    }
                });
            }
            #endregion
        }
    }
}
