using ProjectGates.Model.Entities;
using SFML.Graphics;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities.Passive
{
    class Grid : PassiveEntity, Drawable
    {
        protected uint gridWidth;
        protected uint gridHeight;

        protected Line horizontalLine;
        protected Line verticalLine;

        public Grid(uint gridWidth, uint gridHeight, Color gridColor)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;

            horizontalLine = new Line(0, 0, 0, 0);
            verticalLine = new Line(0, 0, 0, 0);

            horizontalLine.Color = gridColor;
            verticalLine.Color = gridColor;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            float Xreminder = (target.Size.X % gridWidth) / 2;
            float Yreminder = (target.Size.Y % gridHeight) / 2;

            horizontalLine.Start = new Vector2f(-Xreminder, -Yreminder);
            verticalLine.Start = new Vector2f(-Xreminder, -Yreminder);

            horizontalLine.End = new Vector2f(target.Size.X + Xreminder, -Yreminder);
            verticalLine.End = new Vector2f(-Xreminder, target.Size.Y + Yreminder);

            while(horizontalLine.Start.Y <= target.Size.Y)
            { 
                target.Draw(horizontalLine);
                horizontalLine.MoveY(gridHeight);
            }

            while(verticalLine.Start.X <= target.Size.X)
            {
                target.Draw(verticalLine);
                verticalLine.MoveX(gridWidth);
            }
        }

        public Vector2f CatchToGrid(Vector2f vector)
        {
            return new Vector2f(vector.X - (vector.X % gridWidth), vector.Y - (vector.Y % gridHeight));
        }
    }
}
