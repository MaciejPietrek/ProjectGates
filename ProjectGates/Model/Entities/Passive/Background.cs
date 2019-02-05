using ProjectGates.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace ProjectGates.Model.Entities.Passive
{
    class Background : PassiveEntity
    {
        private Sprite Sprite { get; }

        private bool fillWidth = false;
        private bool fillHeight = false;

        public bool FillWidth
        {
            get
            {
                return fillWidth;
            }
            set
            {
                if (value != fillWidth)
                {
                    float tmpX = (float)Engine.MainWindow.Size.X / (float)Sprite.TextureRect.Width;
                    float tmpY = (float)Engine.MainWindow.Size.Y / (float)Sprite.TextureRect.Height;

                    if (value == true)
                    {
                        Sprite.Scale =  new Vector2f(tmpX, fillHeight ? tmpY : tmpX);
                    }
                    else
                    {
                        Sprite.Scale = new Vector2f(fillHeight ? tmpY : 1, Sprite.Scale.Y);
                    }
                    fillWidth = value;
                }
            }
        }
        public bool FillHeight
        {
            get
            {
                return fillHeight;
            }
            set
            {
                if(value != fillHeight)
                {
                    float tmpX = (float)Engine.MainWindow.Size.X / (float)Sprite.TextureRect.Width;
                    float tmpY = (float)Engine.MainWindow.Size.Y / (float)Sprite.TextureRect.Height;

                    if (value == true)
                    {
                        Sprite.Scale = new Vector2f(fillWidth ? tmpX : tmpY, tmpY);
                    }
                    else
                    {
                        Sprite.Scale = new Vector2f(Sprite.Scale.X, fillWidth ? tmpX : 1);
                    }
                    fillWidth = value;
                }
            }
        }


        public Background(Texture texture, bool fillWidth = true, bool fillHeight = true)
        {
            Sprite = new Sprite
            {
                Texture = texture
            };
            Sprite.Origin = texture.Size.ToVector2f() / 2;
            Sprite.Position = Engine.MainWindow.Size.ToVector2f() / 2;
            FillWidth = fillWidth;
            FillHeight = fillHeight;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Sprite);
        }
    }
}
