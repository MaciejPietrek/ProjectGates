using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectGates.Model.Entities.Active
{
    class PointGrid : ActiveEntity, Drawable
    {
        List<Shape> shapes = new List<Shape>();
        
        public PointGrid(uint gridSize)
        {
            int a = 100;
            int b = 30;

            var size = Engine.MainWindow.Size;
            int Xremainder = (b % (int)gridSize)/2;
            int Yremainder = (a % (int)gridSize) / 2;

            var basePoint = new CircleShape(2);
            basePoint.Origin = new SFML.System.Vector2f(1f, 1f);
            basePoint.FillColor = new Color(100, 100, 100);

            for (int X = b + Xremainder; X <= Engine.MainWindow.Size.X - b - Xremainder; X += (int)gridSize)
            {
                for (int Y = a + Yremainder; Y <= size.Y - a + Yremainder; Y += (int)gridSize)
                {
                    var newPoint = new CircleShape(basePoint);
                    newPoint.Position = new SFML.System.Vector2f(X, Y);
                    shapes.Add(newPoint);
                }
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            foreach(var obj in shapes)
            {
                target.Draw(obj);
            }
        }
    }
}
