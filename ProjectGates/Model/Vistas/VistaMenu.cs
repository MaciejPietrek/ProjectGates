﻿using ProjectGates.Model.Entities;
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
            button1.WhenMouseButtonPressed = ((sender, args) =>
            {
                if (button1.Bounds.Contains(new PGVector(args.X, args.Y)))
                    Popup.Pop(new Button[] { new Button("ok", 0.05f) }, "Not implemented");
            });
            var button2 = new Button("New", 0.05f, 0.3f, 0.15f);
            button2.WhenMouseButtonPressed = ((sender, args) =>
            {
                if (button2.Bounds.Contains(new PGVector(args.X, args.Y)))
                    Popup.Pop(new Button[] { new Button("ok", 0.05f) }, "Not implemented");
            });
            var button3 = new Button("Load", 0.05f, 0.3f, 0.2f);
            button3.WhenMouseButtonPressed = ((sender, args) =>
            {
                if (button3.Bounds.Contains(new PGVector(args.X, args.Y)))
                    Popup.Pop(new Button[] { new Button("ok", 0.15f), new Button("ok", 0.10f), new Button("ok", 0.5f) }, "Not implemented");
            });
            var button4 = new Button("Settings", 0.05f, 0.3f, 0.25f);
            button4.WhenMouseButtonPressed = ((sender, args) =>
            {
                if (button4.Bounds.Contains(new PGVector(args.X, args.Y)))
                    Popup.Pop(new Button[] { new Button("ok", 0.05f) }, "Not implemented");
            });
            var button5 = new Button("Exit", 0.05f, 0.3f, 0.30f);
            button5.WhenMouseButtonPressed = ((sender, args) =>
            {
                if(button5.Bounds.Contains(new PGVector(args.X, args.Y)))
                    Engine.MainWindow.Close();
            });
            
            var container1 = new Container<Button>(new PGField(0.5f, 0.2f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button1);
            var container2 = new Container<Button>(new PGField(0.5f, 0.25f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button2);
            var container3 = new Container<Button>(new PGField(0.5f, 0.3f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button3);
            var container4 = new Container<Button>(new PGField(0.5f, 0.35f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button4);
            var container5 = new Container<Button>(new PGField(0.5f, 0.4f, 0f, 0f, (PGVector)Engine.MainWindow.Size), Container<Button>.Aligment.Center, button5);


            AddEntity(container1);
            AddEntity(container2);
            AddEntity(container3);
            AddEntity(container4);
            AddEntity(container5);
        }
        
    }
}