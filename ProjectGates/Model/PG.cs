using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    struct PGFloat
    {
        public float Value { get; set; }
        public PGFloat(float value)
        {
            Value = value;
        }
        public static implicit operator PGFloat(float value)
        {
            return new PGFloat(value);
        }
        public static implicit operator float(PGFloat pGFloat)
        {
            return pGFloat.Value;
        }
    }

    struct PGPercent
    {
        private float value;
        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value > 1)
                    throw new Exception("Percept over 100%");
                if (value < 0)
                    throw new Exception("Percept under 0%");
                this.value = value;
            }
        }
        public PGPercent(float value)
        {
            this.value = value;
        }
        public static implicit operator PGPercent(PGFloat value)
        {
            if (value > 1) return new PGPercent(0);
            if (value < 0) return new PGPercent(1);
            return new PGPercent(value);
        }
        public static implicit operator PGPercent(float value)
        {
            if (value > 1) return new PGPercent(1);
            if (value < 0) return new PGPercent(0);
            return new PGPercent(value);
        }
        public static implicit operator float(PGPercent value)
        {
            return value.Value;
        }
        public static implicit operator PGFloat(PGPercent value)
        {
            return value.value;
        }
    }
    struct PGPoint
    {
        public PGFloat X { get; set; }
        public PGFloat Y { get; set; }
        public PGPoint(PGFloat X, PGFloat Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator PGPoint(Vector2f point)
        {
            return new PGPoint(point.X, point.Y);
        }
        public static implicit operator PGPoint(Vector2i point)
        {
            return new PGPoint(point.X, point.Y);
        }
        public static implicit operator PGPoint(Vector2u point)
        {
            return new PGPoint(point.X, point.Y);
        }

        public static explicit operator PGPoint(PGSize size)
        {
            return new PGPoint(size.X, size.Y);
        }
        public static explicit operator PGPoint(PGVector vector)
        {
            return new PGPoint(vector.X, vector.Y);
        }
        public static explicit operator Vector2f(PGPoint point)
        {
            return new Vector2f(point.X, point.Y);
        }
    }

    struct PGSize
    {
        public PGFloat X { get; set; }
        public PGFloat Y { get; set; }
        public PGSize(PGFloat X, PGFloat Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator PGSize(Vector2f size)
        {
            return new PGSize(size.X, size.Y);
        }
        public static implicit operator PGSize(Vector2i size)
        {
            return new PGSize(size.X, size.Y);
        }
        public static implicit operator PGSize(Vector2u size)
        {
            return new PGSize(size.X, size.Y);
        }

        public static explicit operator PGSize(PGPoint point)
        {
            return new PGSize(point.X, point.Y);
        }
        public static explicit operator PGSize(PGVector vector)
        {
            return new PGSize(vector.X, vector.Y);
        }
        public static explicit operator Vector2f(PGSize size)
        {
            return new Vector2f(size.X, size.Y);
        }
    }

    struct PGVector
    {
        public PGFloat X { get; set; }
        public PGFloat Y { get; set; }
        public PGVector(PGFloat X, PGFloat Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator PGVector(Vector2f vector)
        {
            return new PGVector(vector.X, vector.Y);
        }
        public static implicit operator PGVector(Vector2i vector)
        {
            return new PGVector(vector.X, vector.Y);
        }
        public static implicit operator PGVector(Vector2u vector)
        {
            return new PGVector(vector.X, vector.Y);
        }

        public static explicit operator PGVector(PGPoint point)
        {
            return new PGVector(point.X, point.Y);
        }
        public static explicit operator PGVector(PGSize size)
        {
            return new PGVector(size.X, size.Y);
        }
        public static explicit operator Vector2f(PGVector vector)
        {
            return new Vector2f(vector.X, vector.Y);
        }

        public static PGVector operator +(PGVector first, PGVector second)
        {
            return new PGVector(first.X + second.X, first.Y + second.Y);
        }
        public static PGVector operator -(PGVector first, PGVector second)
        {
            return new PGVector(first.X - second.X, first.Y - second.Y);
        }
        public static PGVector operator *(PGVector first, PGVector second)
        {
            return new PGVector(first.X * second.X, first.Y * second.Y);
        }
        public static PGVector operator /(PGVector first, PGVector second)
        {
            return new PGVector(first.X / second.X, first.Y / second.Y);
        }
    }

    struct PGField
    {
        public PGPoint Position { get; set; }
        public PGSize Size { get; set; }
        public PGField(PGPoint position, PGSize size)
        {
            Position = position;
            Size = size;
        }

        public static implicit operator PGField(RectangleShape field)
        {
            return new PGField(field.Position, field.Size);
        }
        public static implicit operator PGField(FloatRect field)
        {
            return new PGField(new PGPoint(field.Left, field.Top), new PGSize(field.Width, field.Height));
        }

        public static explicit operator RectangleShape(PGField field)
        {
            var result = new RectangleShape((Vector2f)field.Size);
            result.Position = (Vector2f)field.Position;
            return result;
        }

        public bool Contains(PGPoint point)
        {
            if (point.X > Position.X + Size.X)
                return false;
            if (point.X < Position.X)
                return false;
            if (point.Y > Position.Y + Size.Y)
                return false;
            if (point.Y < Position.Y)
                return false;
            return true;
        }
        public bool Contains(float X, float Y)
        {
            if (X > Position.X + Size.X)
                return false;
            if (X < Position.X)
                return false;
            if (Y > Position.Y + Size.Y)
                return false;
            if (Y < Position.Y)
                return false;
            return true;
        }
    }
}
