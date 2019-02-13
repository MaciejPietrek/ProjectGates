using SFML.Graphics;
using SFML.Window;

namespace ProjectGates.Model
{
    class Engine
    {
        private RenderWindow mainWindow;
        private Vista mainVista;


        public Engine(Vista startingVista, VideoMode startingVideoMode)
        {
            mainWindow = new RenderWindow(VideoMode.DesktopMode, "ProjectGates V0.1");
            
        }
    }
}
