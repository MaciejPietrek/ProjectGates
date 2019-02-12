using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    interface IEventConsumer
    {
        EventHandler<KeyEventArgs> WhenKeyPressed { get; set; }
        EventHandler<KeyEventArgs> WhenKeyReleased { get; }
        EventHandler<MouseButtonEventArgs> WhenMouseButtonPressed { get; }
        EventHandler<MouseButtonEventArgs> WhenMouseButtonReleased { get; }
        EventHandler<MouseMoveEventArgs> WhenMouseMoved { get; }
        EventHandler<MouseWheelEventArgs> WhenMouseWeelMoved { get; }
    }
}
