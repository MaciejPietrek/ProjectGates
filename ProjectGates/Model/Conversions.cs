using ProjectGates.Model.Entities;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    static class Conversions
    {
        public static Vector2f ToVector2f(this Vector2u vector)
        {
            return new Vector2f(vector.X, vector.Y);
        }
        public static ActiveEntity AsActive(this IEntity entity)
        {
            if (entity is ActiveEntity)
                return (ActiveEntity)entity;
            else
                return null;
        }
        public static EventSink AsEventSink(this IEntity entity)
        {
            if (entity is EventSink)
                return (EventSink)entity;
            else
                return null;
        }
        public static Vector2f Multiply(Vector2f first, Vector2f second)
        {
            return new Vector2f(first.X * second.X, first.Y * second.Y);
        }
    }
}
