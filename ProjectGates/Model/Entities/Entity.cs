using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    interface IOrigin
    {
        PGPoint Origin { get; set; }
    }

    interface IColor
    {
        PGColor Color { get; set; }
    } 

    interface IField
    {
        PGField Field { get; set; }
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

    interface IPassiveEntity : IEntity
    {

    }

    interface IActiveEntity : IEntity
    {

    }

    interface IEphemeralEntity : IEntity
    {

    }
}
