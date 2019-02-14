﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class PGRectangle : Drawable
    {
        private RectangleShape RectangleShape { get; set; }

        private PGField field;

        public PGField Field
        {
            get => field;
            set
            {
                field = value;
                RectangleShape.Position = (Vector2f)value.Position;
                RectangleShape.Size = (Vector2f)value.Size;
            }
        }

        public PGField Bounds
        {
            get => new PGField(field.Position - Origin, field.Size);
        }

        public PGVector Position
        {
            get => field.Position;
            set
            {
                field.Position = value;
                RectangleShape.Position = (Vector2f)value;
            }
        }

        public PGVector Size
        {
            get => field.Size;
            set
            {
                field.Size = value;
                RectangleShape.Size = (Vector2f)value;
            }
        }

        public PGColor Color
        {
            get => (PGColor)RectangleShape.FillColor;
            set => RectangleShape.FillColor = (Color)value;
        }

        public PGVector Origin
        {
            get => (PGVector)RectangleShape.Origin;
            set => RectangleShape.Origin = (Vector2f)value;
        }

        public PGRectangle()
        {
            RectangleShape = new RectangleShape();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(RectangleShape);
        }
    }
}