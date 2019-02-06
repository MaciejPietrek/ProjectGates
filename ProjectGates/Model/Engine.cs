using ProjectGates.Model.Entities;
using ProjectGates.Model.Vistas;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class Engine
    {
        #region private fields
        private static Time timePerFrame;
        private static Vista vista;
        #endregion

        #region Static fields
        //Do not change those!
        public static Engine Instance { get; }
        public static RenderWindow MainWindow { get; }
        public static Vista Vista
        {
            get
            {
                return vista;
            }
            set
            {
                if (vista != null)
                {
                    Console.WriteLine(vista.ToString() + " -> " + value.ToString());
                    MainWindow.MouseWheelMoved -= vista.Sink.OnMouseScrolled;
                    MainWindow.MouseMoved -= vista.Sink.OnMouseMoved;
                    MainWindow.MouseButtonPressed -= vista.Sink.OnMousePressed;
                    MainWindow.KeyPressed -= vista.Sink.OnKeyPressed;
                    MainWindow.KeyReleased -= vista.Sink.OnKeyReleassed;
                }
                vista = value;
                MainWindow.MouseWheelMoved += vista.Sink.OnMouseScrolled;
                MainWindow.MouseMoved += vista.Sink.OnMouseMoved;
                MainWindow.MouseButtonPressed += vista.Sink.OnMousePressed;
                MainWindow.KeyPressed += vista.Sink.OnKeyPressed;
                MainWindow.KeyReleased += vista.Sink.OnKeyReleassed;
            }
        }
        public static void SetVista(Vista vista, Action action)
        {
            Vista = vista;
            Vista.OnDraw = action;
            Vista.OnDraw += Vista.DefaultOnDraw;
        }
        
        //Here add ALL possible contant vistas!
        public static VistaStarted      SP_Started      { get; }
        public static VistaMenu         SP_Menu         { get; }
        public static VistaRunning      SP_Running      { get; }
        public static VistaPaused       SP_PausedMenu   { get; }
        public static VistaClosing      SP_Closing      { get; }
        #endregion

        #region Contructors
        static Engine()
        {
            // Private static field initilizations.
            timePerFrame    = Time.FromSeconds(1.0f / 30.0f);
            // Private public field initializations.
            Instance        = new Engine();
            MainWindow      = new RenderWindow(VideoMode.DesktopMode, "ProjectGates", Styles.Fullscreen);
            
            SP_Started      = new VistaStarted();
            SP_Menu         = new VistaMenu();
            SP_Running      = new VistaRunning();
            SP_PausedMenu   = new VistaPaused();
            SP_Closing      = new VistaClosing();

            Vista = SP_Started;

            MainWindow.Closed += ((sender, args) => MainWindow.Close());
        }
        private Engine()
        {
            return;
        }
        #endregion

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;
            while (MainWindow.IsOpen)
            {
                timeSinceLastUpdate += clock.Restart();
                while (timeSinceLastUpdate > timePerFrame)
                {
                    timeSinceLastUpdate -= timePerFrame;
                    Vista.Update(timePerFrame);
                    MainWindow.DispatchEvents();
                }
                Render();
            }
        }

        private void Render()
        {
            MainWindow.Clear(Color.Black);
            Vista.Draw();
            MainWindow.Display();
        }
    }
}
