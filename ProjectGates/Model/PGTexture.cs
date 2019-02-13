using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    struct PGTexture
    {
        private Texture Texture { get; set; }

        public PGTexture(string fileName)
        {
            Texture = new Texture(fileName);
        }
        public PGTexture(PGTexture copy)
        {
            Texture = new Texture(copy.Texture);
        }

        private PGTexture(Texture texture)
        {
            Texture = texture;
        }

        public static explicit operator PGTexture(Texture texture)
        {
            return new PGTexture(texture);
        }
        public static explicit operator Texture(PGTexture texture)
        {
            return texture.Texture;
        }

        public PGVector Size
        {
            get
            {
                return (PGVector)Texture.Size;
            }
        }
    }
}
