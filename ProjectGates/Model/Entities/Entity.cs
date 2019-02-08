using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    interface IColor
    {
        Color Color { get; set; }
    }

    interface IField
    {
        PGField Field { get; }
    }

    interface ITransparent
    {
        PGPercent Transparency { get; set; }
    }

    interface IGraphic : IField, IColor, ITransparent
    {

    }

    interface IEntity : Drawable
    {

    }

    abstract class PassiveEntity : IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }

    abstract class ActiveEntity : IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }

    abstract class EphemeralEntity : IEntity
    {
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}
