using ProjectGates.Model.Resources;
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


        public PGField Field
        {
            get
            {
                return new PGField(Shape.Position, Shape.Size);
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
            
            Text = new Text();
            Text.DisplayedString = text;
            Text.Font = ResourceFonts.GetGlobalResource(ResourceFonts.Key.Main);
            Text.Position = new Vector2f(tmp.X * positionX, tmp.Y * positionY);
            Text.CharacterSize = (uint)(Engine.MainWindow.Size.Y * fontSize);
            Text.Color = Color.White;
            

            PGField bounds = Text.GetGlobalBounds();
            Shape = (RectangleShape)bounds;
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
