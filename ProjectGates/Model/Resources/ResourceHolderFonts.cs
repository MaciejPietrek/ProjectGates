using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceFonts : ResourceHolder<PGFont>
    {
        public enum Key
        {
            Main
        }

        static ResourceFonts()
        {
            AddGlobalResource(Key.Main, new PGFont(".\\Model\\Resources\\Fonts\\Blacktroops Inline.ttf"));
        }

        public override void AddResource(Enum key, string path)
        {
            resource.Add(key, new PGFont(path));
        }

        public static new PGFont GetGlobalResource(Enum key)
        {
            globalResource.TryGetValue(key, out PGFont result);
            return result;
        }
    }
}
