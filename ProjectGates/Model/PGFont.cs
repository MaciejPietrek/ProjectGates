using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class PGFont
    {
        private Font Font { get; set; }

        public PGFont(string fileName)
        {
            Font = new Font(fileName);
        }

        public static explicit operator PGFont(Font font)
        {
            return new PGFont()
            {
                Font = font
            };
        }
        public static explicit operator Font(PGFont font)
        {
            return font.Font;
        }
    }
}
