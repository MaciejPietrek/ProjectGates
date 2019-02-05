using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceHolderFonts : ResourceHolder<Font>
    {
        public enum Key
        {
            Main
        }

        public static ResourceHolderFonts UniHolder;

        static ResourceHolderFonts()
        {
            UniHolder = new ResourceHolderFonts();
            UniHolder.AddResource(Key.Main, ".\\Model\\Resources\\Fonts\\BLACK.ttf");
        }

        public override void AddResource(Enum key, string path)
        {
            dictionary.Add(key, new Font(path));
        }
    }
}
