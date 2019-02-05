using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceHolderTextures : ResourceHolder<Texture>
    {
        public enum Key
        {
            Logo,
            Background
        }

        public static ResourceHolderTextures UniHolder;

        static ResourceHolderTextures()
        {
            UniHolder = new ResourceHolderTextures();
            UniHolder.AddResource(Key.Logo, ".\\Model\\Resources\\Textures\\LOGO.png");
            UniHolder.AddResource(Key.Background, ".\\Model\\Resources\\Textures\\BACKGROUND_GRID.jpg");
        }

        public override void AddResource(Enum key, string path)
        {
            dictionary.Add(key, new Texture(path));
        }
    }
}
