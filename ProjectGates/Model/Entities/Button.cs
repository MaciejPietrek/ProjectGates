using ProjectGates.Model.Resources;
using ProjectGates.Model.Vistas;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    class Button : IActiveEntity, IColor, IField, ITransparent, IEventConsumer, IOrigin
    {


        protected PGText Text { get; set; }
        protected PGRectangle Shape { get; set; }

        public PGVector Origin
        {
            get
            {
                return Shape.Origin;
            }
            set
            {
                Shape.Origin = value;
            }
        }
        public PGField Field
        {
            get => Shape.Field;
            set
            {
                Shape.Field = value;

                Text.Origin = Shape.Origin;
                Text.Position = Shape.Field.Position;
            }
        }
        public PGColor Color
        {
            get
            {
                return Shape.Color;
            }
            set
            {
                Shape.Color = value;
            }
        }
        public PGPercent Transparency
        {
            get
            {
                return Text.Color.T;
            }
            set
            {
                var old = Text.Color;
                Text.Color = new PGColor(old.R, old.G, old.B, value);
            }
        }

        public EventHandler<KeyEventArgs>           WhenKeyPressed
        {
            get; set;
        }

        public EventHandler<KeyEventArgs>           WhenKeyReleased
        {
            get; set;
        }

        public EventHandler<MouseButtonEventArgs>   WhenMouseButtonPressed
        {
            get; set;
        }
        
        public EventHandler<MouseButtonEventArgs>   WhenMouseButtonReleased
        {
            get; set;
        }

        public EventHandler<MouseMoveEventArgs>     WhenMouseMoved
        {
            get; set;
        }

        public EventHandler<MouseWheelEventArgs>    WhenMouseWeelMoved
        {
            get; set;
        }
        
        public Button(string text, PGPercent fontSize, PGPercent positionX, PGPercent positionY)
        {
            var tmp = Engine.MainWindow.Size;

            Text = new PGText
            {
                String = text,
                Font = ResourceFonts.GetGlobalResource(ResourceFonts.Key.Main),
                Position = new PGVector(tmp.X * positionX, tmp.Y * positionY),
                Size = fontSize,
                Color = new PGColor(1, 1, 1)
            };

            WhenMouseMoved = ((sender, args) =>
            {

                if (Field.Contains(new PGVector(args.X, args.Y)))
                {
                    Color = new PGColor(0.7f, 0.7f, 0.7f, 0.7f);
                }
                else
                {
                    Color = new PGColor(0, 0, 0, 1);
                }
            });

            Shape = new PGRectangle()
            {
                Field = Text.Field,
                Color = new PGColor(0, 0, 0, 1)                
            };
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape);
            target.Draw(Text);
        }
    }
}