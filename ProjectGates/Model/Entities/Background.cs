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
        private readonly PGSprite sprite = new PGSprite();

        public Background(PGTexture texture, bool fillWidth = true, bool FillHeight = true)
        {
            sprite.Texture = texture ?? throw new TextureNullReferenceException("Null reference in class Background");
           
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
                return ((PGFloat)sprite.Color.T / 255);
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
