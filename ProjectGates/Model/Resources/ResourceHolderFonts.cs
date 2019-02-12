using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceFonts : ResourceHolder<Font>
    {
        public enum Key
        {
            Main
        }

        static ResourceFonts()
        {
            AddGlobalResource(Key.Main, new Font(".\\Model\\Resources\\Fonts\\Blacktroops Inline.ttf"));
        }

        public override void AddResource(Enum key, string path)
        {
            resource.Add(key, new Font(path));
        }

        public static new Font GetGlobalResource(Enum key)
        {
            globalResource.TryGetValue(key, out Font result);
            return result;
        }
    }
}
