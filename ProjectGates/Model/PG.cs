using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    public struct PGFloat
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

    public struct PGPercent
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
    
    struct PGVector
    {
        public PGFloat X { get; set; }
        public PGFloat Y { get; set; }
        public PGVector(PGFloat X, PGFloat Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static explicit operator PGVector(Vector2f vector)
        {
            return new PGVector(vector.X, vector.Y);
        }
        public static explicit operator PGVector(Vector2i vector)
        {
            return new PGVector(vector.X, vector.Y);
        }
        public static explicit operator PGVector(Vector2u vector)
        {
            return new PGVector(vector.X, vector.Y);
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
        public static PGVector operator /(PGVector first, float second)
        {
            return new PGVector(first.X / second, first.Y / second);
        }
    }

    struct PGField
    {
        public PGVector Position { get; set; }
        public PGVector Size { get; set; }
        public PGField(PGVector position, PGVector size)
        {
            Position = position;
            Size = size;
        }
        public PGField(PGPercent positionX, PGPercent positionY, PGPercent sizeX, PGPercent sizeY, PGVector size)
        {
            Position = (PGVector)((PGVector)size * new PGVector(positionX, positionY));
            Size = (PGVector)((PGVector)size * new PGVector(sizeX, sizeY));
        }

        public static explicit operator PGField(RectangleShape field)
        {
            return new PGField((PGVector)field.Position, (PGVector)field.Size);
        }
        public static explicit operator PGField(FloatRect field)
        {
            return new PGField(new PGVector(field.Left, field.Top), new PGVector(field.Width, field.Height));
        }

        public static explicit operator RectangleShape(PGField field)
        {
            var result = new RectangleShape((Vector2f)field.Size);
            result.Position = (Vector2f)field.Position;
            return result;
        }

        public bool Contains(PGVector point)
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
