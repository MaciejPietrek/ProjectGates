using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities.Active
{
    class Button : ActiveEntity, IColor, IField
    {
        private Text Text { get; set; }
        private RectangleShape Shape { get; set; }


        public Field Field
        {
            get
            {
                return new Field(Shape.Position, Shape.Size);
            }
        }
        public Color Color
        {
            get
            {
                return Shape.FillColor;
            }
            set
            {
                Shape.FillColor = value;
            }
        }


        public Button(string text, float fontSize, float positionX, float positionY)
        {
            ExceptionChecker.CheckPerceventagergumentException(fontSize, positionX, positionY);

            var tmp = Engine.MainWindow.Size;

            Text = new Text(text, Resources.ResourceHolderFonts.UniHolder.GetResource(Resources.ResourceHolderFonts.Key.Main))
            {
                Position = new Vector2f(tmp.X * positionX, tmp.Y * positionY),
                CharacterSize = (uint)(Engine.MainWindow.Size.Y * fontSize),
                Color = Color.White,
            };

            var bounds = Text.GetGlobalBounds();

            Shape = new RectangleShape(new Vector2f(bounds.Width, bounds.Height));
            Shape.Position = new Vector2f(bounds.Left, bounds.Top);
            Shape.FillColor = Color.Transparent;

            WhenMouseMoved = ((sender, args) =>
            {
                var rectangle = Field;
                var argument = (MouseMoveEventArgs)args;
                if (rectangle.Contains(new Vector2f(argument.X, argument.Y)))
                {
                    Color = new Color(200, 200, 200, 200);
                }
                else
                {
                    Color = Color.Transparent;
                }
            });
        }
        

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape);
            target.Draw(Text);
        }

    }
}
