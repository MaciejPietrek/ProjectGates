﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class PGText : Drawable
    {
        private Text Text { get; set; }
        private PGPercent PGPercent { get; set; }
        
        public PGText()
        {
            Text = new Text();
        }

        public string String
        {
            get => Text.DisplayedString;
            set => Text.DisplayedString = value;
        }
        public PGFont Font
        {
            get => (PGFont)Text.Font;
            set => Text.Font = (Font)value;
        }
        public PGPercent Size
        {
            get => PGPercent;
            set
            {
                PGPercent = value;
                Text.CharacterSize = (uint)(Engine.MainWindow.Size.Y * (float)value);
            }   
        }
        public PGVector Origin
        {
            get => (PGVector)Text.Origin;
            set => Text.Origin = (Vector2f)value;
        }
        public PGVector Position
        {
            get => (PGVector)Text.Position;
            set => Text.Position = (Vector2f)value;
        }
        public PGField Field
        {
            get
            {
                return new PGField((PGVector)Text.Position, new PGVector(Text.GetGlobalBounds().Width, Text.GetGlobalBounds().Height));
            }
            set
            {
                Text.Position = (Vector2f)value.Position;
                Text.CharacterSize = (uint)value.Size.Y;
            }
        }
        public PGField Bounds
        {
            get
            {
                var a = (PGField)Text.GetGlobalBounds();
                return new PGField(a.Position + Origin, a.Size);
            }
        }
        public PGColor Color
        {
            get => (PGColor)Text.Color;
            set => Text.Color = (Color)value;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text);
        }
    }
}
