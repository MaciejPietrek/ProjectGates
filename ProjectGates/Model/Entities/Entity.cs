using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    struct Field
    {
        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }

        public Field(Vector2f position, Vector2f size)
        {
            Position = position;
            Size = size;
        }
        public bool Contains(Vector2f point)
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

    interface IColor
    {
        Color Color { get; }
    }

    interface IField
    {
        Field Field { get; }
    }

    interface IEntity : Drawable
    {

    }

    abstract class PassiveEntity : IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }

    abstract class ActiveEntity : EventSink, IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }

    abstract class EphemeralEntity : IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}
