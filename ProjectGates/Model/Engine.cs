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
                    MainWindow.KeyPressed -= Vista.WhenKeyPressed;
                    MainWindow.KeyReleased -= Vista.WhenKeyReleased;
                    MainWindow.MouseButtonPressed -= Vista.WhenMouseButtonPressed;
                    MainWindow.MouseButtonReleased -= Vista.WhenMouseButtonReleased;
                    MainWindow.MouseMoved -= Vista.WhenMouseMoved;
                    MainWindow.MouseWheelMoved -= Vista.WhenMouseWeelMoved;
                }
                vista = value;
                if (vista != null)
                {
                    MainWindow.KeyPressed += Vista.WhenKeyPressed;
                    MainWindow.KeyReleased += Vista.WhenKeyReleased;
                    MainWindow.MouseButtonPressed += Vista.WhenMouseButtonPressed;
                    MainWindow.MouseButtonReleased += Vista.WhenMouseButtonReleased;
                    MainWindow.MouseMoved += Vista.WhenMouseMoved;
                    MainWindow.MouseWheelMoved += Vista.WhenMouseWeelMoved;
                }
            }
        }
        public static void SetVista(Vista vista, Action<RenderTarget, RenderStates> action)
        {
            Vista = vista;
            Vista.OnDraw = action;
            Vista.OnDraw += Vista.DefaultOnDraw;
        }

        public static void Connect(Vista vista)
        {
            Vista = vista;
        }

        public static void Disconnect()
        {
            Vista = null;
        }
        #endregion
        
        #region Contructors.
        static Engine()
        {
            // Private static field initilizations.
            timePerFrame    = Time.FromSeconds(1.0f / 30.0f);
            // Private public field initializations.
            Instance        = new Engine();
            MainWindow      = new RenderWindow(VideoMode.DesktopMode, "ProjectGates", Styles.Fullscreen);
            
            MainWindow.Closed += ((sender, args) =>
            {
                MainWindow.Close();
            });
            MainWindow.KeyPressed += ((sender, args) =>
            {
                if (args.Code == Keyboard.Key.Escape)
                    Engine.MainWindow.Close();
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

        public void Render()
        {
            MainWindow.Clear(Color.Black);
            MainWindow.Draw(Vista);
            MainWindow.Display();
        }
        #endregion
    }
}
