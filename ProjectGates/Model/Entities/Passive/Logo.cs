using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectGates.Model.Entities.Passive
{
    class Logo : PassiveEntity
    {
        private Sprite Sprite { get; }
        
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
