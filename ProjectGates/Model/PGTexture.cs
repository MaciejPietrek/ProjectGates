using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class PGTexture
    {
        private Texture Texture { get; set; }

        public PGSize Size
        {
            get
            {
                return (PGSize)Texture.Size;
            }
        }
    }
}
