using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    class Background : IEntity, Drawable, ITransparent
    {
        private PGSprite sprite;

        public Background(PGTexture texture, bool fillWidth = true, bool FillHeight = true)
        {
            sprite = new PGSprite(texture);
           
            var WindowSize = (PGVector)Engine.MainWindow.Size;

            float xScale = 1;
            float yScale = 1;

            if (fillWidth && FillHeight)
            {
                xScale = texture.Size.X > WindowSize.X ? texture.Size.X / WindowSize.X : WindowSize.X / texture.Size.X;
                yScale = texture.Size.Y > WindowSize.Y ? texture.Size.Y / WindowSize.Y : WindowSize.Y / texture.Size.Y;
            }
            else if (fillWidth)
            {
                xScale = texture.Size.X > WindowSize.X ? texture.Size.X / WindowSize.X : WindowSize.X / texture.Size.X;
                yScale = xScale;
            }
            else if(FillHeight)
            {
                yScale = texture.Size.Y > WindowSize.Y ? texture.Size.Y / WindowSize.Y : WindowSize.Y / texture.Size.Y;
                xScale = yScale;
            }

            sprite.Scale = new PGVector(xScale, yScale);

            sprite.Origin = texture.Size / 2f;
            sprite.Position = WindowSize / 2;
        }

        public PGPercent Transparency
        {
            get
            {
                return sprite.Color.T;
            }
            set
            {
                var old = sprite.Color;
                sprite.Color = new PGColor(old.R, old.G, old.B, value);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite);
        }
    }
}
