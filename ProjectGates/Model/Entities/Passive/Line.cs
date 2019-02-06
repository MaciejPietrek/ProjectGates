using ProjectGates.Model;

using SFML.Graphics;
using SFML.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities.Passive
{
    class Line : Drawable
    {
        private Vertex[] vertices;

        public Line(float startX, float startY, float endX, float endY)
        {
            vertices = new Vertex[] { new Vertex(new Vector2f(startX, startY)), new Vertex(new Vector2f(endX, endY)) };
        }

        public Line(Vector2f start, Vector2f end)
        {
            vertices = new Vertex[] { new Vertex(start), new Vertex(end) };
        }

        public Line(Vertex start, Vertex end)
        {
            vertices = new Vertex[] { start, end };
        }

        public Line()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(vertices, PrimitiveType.Lines);
        }

        public Color Color
        {
            get
            {
                return vertices[0].Color;
            }
            set
            {
                vertices[0].Color = value;
                vertices[1].Color = value;
            }
        }

        public Vector2f Start
        {
            get
            {
                return vertices[0].Position;
            }
            set
            {
                vertices[0].Position = value;
            }
        }

        public Vector2f End
        {
            get
            {
                return vertices[1].Position;
            }
            set
            {
                vertices[1].Position = value;
            }
        }

        public void MoveX(float value)
        {
            vertices[0].Position.X += value;
            vertices[1].Position.X += value;
        }

        public void MoveY(float value)
        {
            vertices[0].Position.Y += value;
            vertices[1].Position.Y += value;
        }
    }
}
