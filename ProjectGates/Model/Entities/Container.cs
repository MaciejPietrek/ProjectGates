using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace ProjectGates.Model.Entities
{
    class Container<T> : IEntity, IEventConsumer where T : IField, IOrigin, IEntity
    {
        private T _entity;

        public EventHandler<KeyEventArgs> WhenKeyPressed { get => (_entity is IEventConsumer con) ? con.WhenKeyPressed : null; set { } }

        public EventHandler<KeyEventArgs> WhenKeyReleased { get => (_entity is IEventConsumer con) ? con.WhenKeyReleased : null; set { } }

        public EventHandler<MouseButtonEventArgs> WhenMouseButtonPressed { get => (_entity is IEventConsumer con) ? con.WhenMouseButtonPressed : null; set { } }

        public EventHandler<MouseButtonEventArgs> WhenMouseButtonReleased { get => (_entity is IEventConsumer con) ? con.WhenMouseButtonReleased : null; set { } }

        public EventHandler<MouseMoveEventArgs> WhenMouseMoved { get => (_entity is IEventConsumer con) ? con.WhenMouseMoved : null; set { } }

        public EventHandler<MouseWheelEventArgs> WhenMouseWeelMoved { get => (_entity is IEventConsumer con) ? con.WhenMouseWeelMoved : null; set { } }

        public enum Aligment
        {
            UpperLeft,
            Upper,
            UpperRight,
            Right,
            BottomRight,
            Bottom,
            BottomLeft,
            Left,
            Center
        }

        public Container(PGField field, Aligment aligment, T entity)
        {
            _entity = entity;
            PGVector tmp;
            switch (aligment)
            {
                case Aligment.UpperLeft:
                    _entity.Origin = new PGVector(0, 0);
                    tmp = field.Position;
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.Upper:
                    _entity.Origin = new PGVector(_entity.Field.Size.X / 2, 0);
                    tmp = new PGVector(field.Position.X + field.Size.X / 2, field.Position.Y);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.UpperRight:
                    _entity.Origin = new PGVector(_entity.Field.Size.X, 0);
                    tmp = new PGVector(field.Position.X + field.Size.X, field.Position.Y);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.Right:
                    _entity.Origin = new PGVector(_entity.Field.Size.X, _entity.Field.Size.Y / 2);
                    tmp = new PGVector(field.Position.X + field.Size.X, field.Position.Y + field.Size.Y / 2);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.BottomRight:
                    _entity.Origin = new PGVector(_entity.Field.Size.X, _entity.Field.Size.Y);
                    tmp = new PGVector(field.Position.X + field.Size.X, field.Position.Y + field.Size.Y);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.Bottom:
                    _entity.Origin = new PGVector(_entity.Field.Size.X / 2, _entity.Field.Size.Y);
                    tmp = new PGVector(field.Position.X + field.Size.X / 2, field.Position.Y + field.Size.Y);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.BottomLeft:
                    _entity.Origin = new PGVector(0, _entity.Field.Size.Y);
                    tmp = new PGVector(field.Position.X, field.Position.Y + field.Size.Y);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.Left:
                    _entity.Origin = new PGVector(0, _entity.Field.Size.Y / 2);
                    tmp = new PGVector(field.Position.X, field.Position.Y + field.Size.Y / 2);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
                case Aligment.Center:
                    _entity.Origin = new PGVector(_entity.Field.Size.X / 2, _entity.Field.Size.Y / 2);
                    tmp = new PGVector(field.Position.X + field.Size.X / 2, field.Position.Y + field.Size.Y / 2);
                    _entity.Field = new PGField(tmp, _entity.Field.Size);
                    break;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_entity);
        }
    }
}
