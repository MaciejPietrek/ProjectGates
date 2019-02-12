﻿using ProjectGates.Model.Resources;
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
    class Button : ActiveEntity, IColor, IField, ITransparent, IEventConsumer
    {


        protected Text Text { get; set; }
        protected RectangleShape Shape { get; set; }
        
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

        public PGPercent Transparency
        {
            get
            {
                return ((PGFloat)Text.Color.A / 255);
            }
            set
            {
                var old = Text.Color;
                var newColor = new Color(old.R, old.G, old.B, (byte)(value * 255));
                Text.Color = newColor;
            }
        }

        public EventHandler<KeyEventArgs> WhenKeyPressed
        {
            get; set;
        }

        public EventHandler<KeyEventArgs> WhenKeyReleased
        {
            get; set;
        }

        public EventHandler<MouseButtonEventArgs> WhenMouseButtonPressed
        {
            get; set;
        }
        
        public EventHandler<MouseButtonEventArgs> WhenMouseButtonReleased
        {
            get; set;
        }

        public EventHandler<MouseMoveEventArgs> WhenMouseMoved
        {
            get; set;
        }

        public EventHandler<MouseWheelEventArgs> WhenMouseWeelMoved
        {
            get; set;
        }

        
        public Button(string text, PGPercent fontSize, PGPercent positionX, PGPercent positionY)
        {
            var tmp = Engine.MainWindow.Size;

            Text = new Text();
            Text.DisplayedString = text;
            Text.Font = ResourceFonts.GetGlobalResource(ResourceFonts.Key.Main);
            Text.Position = new Vector2f(tmp.X * (PGFloat)positionX, tmp.Y * (PGFloat)positionY);
            Text.CharacterSize = (uint)(Engine.MainWindow.Size.Y * (PGFloat)fontSize);
            Text.Color = Color.White;

            WhenMouseMoved = ((sender, args) =>
            {

                if (Field.Contains(new Vector2f(args.X, args.Y)))
                {
                    Color = new Color(200, 200, 200, 200);
                }
                else
                {
                    Color = Color.Transparent;
                }
            });

            PGField bounds = Text.GetGlobalBounds();
            Shape = (RectangleShape)bounds;
            Shape.FillColor = Color.Transparent;
        }
        
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Shape);
            target.Draw(Text);
        }
    }
}