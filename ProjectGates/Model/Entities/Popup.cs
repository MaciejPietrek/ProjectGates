using ProjectGates.Model.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Entities
{
    static class Popup
    {
        static PGText Text { get; set; }
        static PGRectangle Shape { get; set; }
        static Button[] Buttons { get; set; }

        public static Button Pop(Button[] buttons, string text, Vista returnVista)
        {
            Button result = null;
            Vista remember = returnVista;
            var newVista = new VistaBlank();
            float i = 0.0f;
            bool cont = true;
            var textt = new Button(text, 0.05f, 0f, 0f);
            textt.WhenMouseMoved = null;
            Container<Button> container0 = new Container<Button>(new PGField(0.5f, 0.35f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, textt);
            newVista.AddEntity(container0);
            foreach (Button b in buttons)
            {
                b.WhenMouseButtonPressed += ((sender, args) =>
                {
                    if (b.Bounds.Contains(new PGVector(args.X, args.Y)))
                    {
                        result = b;
                        cont = false;
                    }
                });
                Container<Button> container = new Container<Button>(new PGField(0.5f, 0.4f +  i, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, b);
                newVista.AddEntity(container);
                i += b.Bounds.Size.Y / Engine.MainWindow.Size.Y;
            }
            Engine.Vista = newVista;
            while (cont)
            {
                Engine.MainWindow.DispatchEvents();
                Engine.Instance.Render();
            }
            Engine.Vista = remember;
            return result;
        }

        public static Button Pop(Button[] buttons, string text)
        {
            Button result = null;
            Vista remember = Engine.Vista;
            var newVista = new VistaBlank();
            int i = 0;
            bool cont = true;
            var textt = new Button(text, 0.05f, 0f, 0f);
            textt.WhenMouseMoved = null;
            Container<Button> container0 = new Container<Button>(new PGField(0.5f, 0.35f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, textt);
            newVista.AddEntity(container0);
            foreach (Button b in buttons)
            {
                b.WhenMouseButtonPressed += ((sender, args) =>
                {
                    if (b.Bounds.Contains(new PGVector(args.X, args.Y)))
                    {
                        result = b;
                        cont = false;
                    }
                });
                Container<Button> container = new Container<Button>(new PGField(0.5f, 0.4f + 0.05f * i, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, b);
                newVista.AddEntity(container);
                i++;
            }
            Engine.Vista = newVista;
            while (cont)
            {
                Engine.MainWindow.DispatchEvents();
                Engine.Instance.Render();
            }
            Engine.Vista = remember;
            return result;
        }
    }
}
