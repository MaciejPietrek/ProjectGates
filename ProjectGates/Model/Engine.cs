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
        #region private fields.
        private static Time timePerFrame;
        private static Vista vista;
        #endregion

        #region Static fields.
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
                    KeyPressed -= Vista.WhenKeyPressed;
                    KeyReleassed -= Vista.WhenKeyReleassed;
                    MouseButtonPressed -= Vista.WhenMouseButtonPressed;
                    MouseButtonReleassed -= Vista.WhenMouseButtonReleassed;
                    MouseMoved -= Vista.WhenMouseMoved;
                    MouseWheelMoved -= Vista.WhenMouseWeelMoved;
                }
                vista = value;
                KeyPressed += Vista.WhenKeyPressed;
                KeyReleassed += Vista.WhenKeyReleassed;
                MouseButtonPressed += Vista.WhenMouseButtonPressed;
                MouseButtonReleassed += Vista.WhenMouseButtonReleassed;
                MouseMoved += Vista.WhenMouseMoved;
                MouseWheelMoved += Vista.WhenMouseWeelMoved;
            }
        }
        public static void SetVista(Vista vista, Action<RenderTarget, RenderStates> action)
        {
            Vista = vista;
            Vista.OnDraw = action;
            Vista.OnDraw += Vista.DefaultOnDraw;
        }

        public static VistaStarted PG_VistaStarted;
        public static VistaMenu PG_VistaMenu;
        #endregion

        #region Events.
        private static event EventHandler KeyPressed;
        private static event EventHandler KeyReleassed;
        private static event EventHandler MouseButtonPressed;
        private static event EventHandler MouseButtonReleassed;
        private static event EventHandler MouseMoved;
        private static event EventHandler MouseWheelMoved;

        private static void OnKeyPressed(object sender, EventArgs args)
        {
            KeyPressed?.Invoke(sender, args);
        }
        private static void OnKeyReleassed(object sender, EventArgs args)
        {
            KeyReleassed?.Invoke(sender, args);
        }
        private static void OnMouseButtonPressed(object sender, EventArgs args)
        {
            MouseButtonPressed?.Invoke(sender, args);
        }
        private static void OnMouseButtonReleassed(object sender, EventArgs args)
        {
            MouseButtonReleassed?.Invoke(sender, args);
        }
        private static void OnMouseMoved(object sender, EventArgs args)
        {
            MouseMoved?.Invoke(sender, args);
        }
        private static void OnMouseWheelMoved(object sender, EventArgs args)
        {
            MouseWheelMoved?.Invoke(sender, args);
        }
        #endregion

        #region Contructors.
        static Engine()
        {
            // Private static field initilizations.
            timePerFrame    = Time.FromSeconds(1.0f / 30.0f);
            // Private public field initializations.
            Instance        = new Engine();
            MainWindow      = new RenderWindow(VideoMode.DesktopMode, "ProjectGates");

            MainWindow.KeyPressed += OnKeyPressed;
            MainWindow.KeyReleased += OnKeyReleassed;
            MainWindow.MouseButtonPressed += OnMouseButtonPressed;
            MainWindow.MouseButtonReleased += OnMouseButtonReleassed;
            MainWindow.MouseMoved += OnMouseMoved;
            MainWindow.MouseWheelMoved += OnMouseWheelMoved;

            PG_VistaStarted = new VistaStarted();
            PG_VistaMenu = new VistaMenu();

            Vista = PG_VistaStarted;

            MainWindow.Closed += ((sender, args) =>
            {
                MainWindow.Close();
            });
        }

        private Engine()
        {

        }
        #endregion

        #region Run() & Render().
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
            MainWindow.Draw(Vista);
            MainWindow.Display();
        }
        #endregion
    }
}
