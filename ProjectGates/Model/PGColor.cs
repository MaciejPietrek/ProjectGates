using SFML.Graphics;

namespace ProjectGates.Model
{
    public struct PGColor
    {
        private Color Color;
        
        public static explicit operator Color(PGColor color)
        {
            return color.Color;
        }
        public static explicit operator PGColor(Color color)
        {
            return new PGColor()
            {
                R = (PGPercent)(color.R / 255f),
                G = (PGPercent)(color.G / 255f),
                B = (PGPercent)(color.B / 255f),
                T = (PGPercent)(color.A / 255f)
            };
        }
        
        public PGColor(PGPercent red, PGPercent green, PGPercent blue)
        {
            r = red;
            g = green;
            b = blue;
            t = 0f;
            Color = new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }
        public PGColor(PGPercent red, PGPercent green, PGPercent blue, PGPercent transparency)
        {
            r = red;
            g = green;
            b = blue;
            t = transparency;
            Color = new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255), (byte)(t * 255));
        }

        private PGPercent r;
        public PGPercent R
        {
            get => r;
            set
            {
                r = value;
                Color.R = (byte)(value * 255);
            }
        }

        private PGPercent g;
        public PGPercent G
        {
            get => g;
            set
            {
                g = value;
                Color.G = (byte)(value * 255);
            }
        }

        private PGPercent b;
        public PGPercent B
        {
            get => b;
            set
            {
                b = value;
                Color.B = (byte)(value * 255);
            }
        }

        private PGPercent t;
        public PGPercent T
        {
            get => t;
            set
            {
                t = value;
                Color.A = (byte)(value * 255);
            }
        }

    }
}