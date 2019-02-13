using ProjectGates.Model.Entities;
using ProjectGates.Model.Resources;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    class VistaMenu : Vista
    {
        public Action<RenderTarget, RenderStates> OnLoad;
        private int count = 0;

        public VistaMenu()
        {
            OnLoad = ((state, target) =>
            {
                if (count == 0)
                {
                    foreach (var entity in Entities)
                    {
                        if (entity is ITransparent e)
                            e.Transparency = 0;
                    }
                }
                foreach (var entity in Entities)
                {
                    if (entity is ITransparent e)
                        e.Transparency = e.Transparency + 0.02f;
                }
                count++;
                if (count >= 100)
                {
                    count = 0;
                    OnDraw = DefaultOnDraw;
                }
            });

            OnDraw = OnLoad;
            OnDraw += DefaultOnDraw;

            AddEntity(new Background(ResourceTextures.GetGlobalResource(ResourceTextures.Key.Background)));

            var button1 = new Button("Continue", 0.05f, 0.3f, 0.1f);
            var button2 = new Button("New", 0.05f, 0.3f, 0.15f);
            var button3 = new Button("Load", 0.05f, 0.3f, 0.2f);
            var button4 = new Button("Settings", 0.05f, 0.3f, 0.25f);
            var button5 = new Button("Exit", 0.05f, 0.3f, 0.30f);
            button5.WhenMouseButtonPressed = ((sender, args) =>
            {
                if(button5.Field.Contains(new PGPoint(args.X, args.Y)))
                    Engine.MainWindow.Close();
            });
            
            var container1 = new Container<Button>(new PGField(0.5f, 0.2f, 0f, 0f, (PGSize)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button1);
            var container2 = new Container<Button>(new PGField(0.5f, 0.3f, 0f, 0f, (PGSize)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button2);
            var container3 = new Container<Button>(new PGField(0.5f, 0.4f, 0f, 0f, (PGSize)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button3);
            var container4 = new Container<Button>(new PGField(0.5f, 0.5f, 0f, 0f, (PGSize)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button4);
            var container5 = new Container<Button>(new PGField(0.5f, 0.6f, 0f, 0f, (PGSize)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button5);


            AddEntity(container1);
            AddEntity(container2);
            AddEntity(container3);
            AddEntity(container4);
            AddEntity(container5);
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.Left, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.Right, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.Bottom, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.Upper, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.UpperLeft, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.UpperRight, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.BottomLeft, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.BottomRight, new Button("Text", 0.05f, 0f, 0.5f)));
            AddEntity(new Container<Button>(new PGField(new PGPoint(0, 0), new PGSize(600, 600)), Container<Button>.Aligment.Center, new Button("Text", 0.05f, 0f, 0.5f)));
        }
        
    }
}