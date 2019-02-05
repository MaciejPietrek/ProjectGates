using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceTextures : ResourceHolder<Texture>
    {
        public enum Key
        {
            Logo,
            Background
        }
        
        static ResourceTextures()
        {
            AddGlobalResource(Key.Logo, new Texture(".\\Model\\Resources\\Textures\\LOGO.png"));
            AddGlobalResource(Key.Background, new Texture(".\\Model\\Resources\\Textures\\BACKGROUND_GRID.jpg"));
        }

        public override void AddResource(Enum key, string path)
        {
            resource.Add(key, new Texture(path));
        }
    }
}
