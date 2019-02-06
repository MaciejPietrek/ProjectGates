using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace ProjectGates.Model.Entities.Passive
{
    class CenteredField : PassiveEntity, ITransparent
    {
        private RectangleShape shape;

        public CenteredField(PGPercent screenXShare, PGPercent screenYShare)
        {
            var size = new Vector2f(Engine.MainWindow.Size.X * screenXShare, Engine.MainWindow.Size.Y * screenYShare);
            shape = new RectangleShape(size);
            
            shape.Origin = shape.Size / 2;
            shape.Position = Engine.MainWindow.Size.ToVector2f() / 2;

            shape.FillColor = new Color(23, 23, 23, 210);
            shape.OutlineColor = new Color(50, 50, 50, 210);
            shape.OutlineThickness = 10;
        }
        
        public PGPercent Transparency
        {
            get
            {
                return (PGPercent)((PGFloat)shape.FillColor.A/255);
            }
            set
            {
                var a = (byte)((float)value * 255);
                shape.FillColor = new Color(shape.FillColor.R, shape.FillColor.G, shape.FillColor.B, a);
                shape.OutlineColor = new Color(shape.OutlineColor.R, shape.OutlineColor.G, shape.OutlineColor.B, a);
            }
        }
        
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape);
        }
    }
}
