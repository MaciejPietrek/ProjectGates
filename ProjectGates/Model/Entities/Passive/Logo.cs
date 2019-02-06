using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectGates.Model.Entities.Passive
{
    class Logo : PassiveEntity, ITransparent
    {
        private Sprite Sprite { get; }

        public PGPercent Transparency
        {
            get
            {
                return ((PGFloat)Sprite.Color.A / 255);
            }
            set
            {
                var old = Sprite.Color;
                var newColor = new Color(old.R, old.G, old.B, (byte)(value * 255));
                Sprite.Color = newColor;
            }
        }

        public Logo(Texture texture)
        {
            Sprite = new Sprite
            {
                Texture = texture
            };

            var scale = texture.Size.Y/50;
            Sprite.Position = Engine.MainWindow.Size.ToVector2f() - texture.Size.ToVector2f() / scale;
            Sprite.Scale = Sprite.Scale / scale;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Sprite);
        }
    }
}
