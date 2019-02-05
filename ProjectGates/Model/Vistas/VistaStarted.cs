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
        private static ResourceHolderTextures textures;

        static VistaStarted()
        {
            textures = new ResourceHolderTextures();
            textures.AddResource(TextureEnum.background, ".\\Model\\Resources\\Textures\\BACKGROUND.png");
        }

        enum TextureEnum
        {
            background
        }

        public VistaStarted()
        {
            AddEntity(new Background(ResourceHolderTextures.UniHolder.GetResource(ResourceHolderTextures.Key.Background)));
            AddEntity(new Background(textures.GetResource(TextureEnum.background), true, false));
        }

        public override void OnKeyPressed(object sender, EventArgs args)
        {
            #region State change
            var arguments = (KeyEventArgs)args;
            if (arguments.Code == Keyboard.Key.Escape)
                Engine.Vista = Engine.SP_Closing;
            else
                Engine.Vista = Engine.SP_Menu;
            #endregion
        }
    }
}
