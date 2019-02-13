using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class PGSprite : Drawable
    {
        private Sprite Sprite { get; set; }

        public PGTexture Texture
        {
            get => (PGTexture)Sprite.Texture;
            set => Sprite.Texture = (Texture)value;
        }

        public PGVector Position
        {
            get => (PGVector)Sprite.Position;
            set => Sprite.Position = (Vector2f)value;
        }

        public PGVector Scale
        {
            get => (PGVector)Sprite.Scale;
            set => Sprite.Scale = (Vector2f)value;
        }

        public PGField Field
        {
            get => new PGField((PGVector)Sprite.Position, (PGVector)((PGVector)Sprite.Texture.Size * Scale));
        }

        public PGVector Origin
        {
            get => (PGVector)Sprite.Origin;
            set => Sprite.Origin = (Vector2f)value;
        }

        public PGColor Color
        {
            get => (PGColor)Sprite.Color;
            set => Sprite.Color = (Color)value;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Sprite);
        }
    }
}
