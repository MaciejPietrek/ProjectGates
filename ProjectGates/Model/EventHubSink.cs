using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    interface IEventHub
    {
        event EventHandler MouseScrolled;
        event EventHandler MousePressed;
        event EventHandler MouseMoved;
        event EventHandler KeyPressed;
        event EventHandler KeyReleassed;
    }

    abstract class EventSink
    {
        public virtual EventHandler WhenMouseScrolled { get; set; }
        public virtual EventHandler WhenMousePressed { get; set; }
        public virtual EventHandler WhenMouseMoved { get; set; }
        public virtual EventHandler WhenKeyPressed { get; set; }
        public virtual EventHandler WhenKeyReleassed { get; set; }

        public virtual void OnMouseScrolled(object sender, EventArgs args)
        {
            WhenMouseScrolled?.Invoke(sender, args);
            return;
        }
        public virtual void OnMousePressed(object sender, EventArgs args)
        {
            WhenMousePressed?.Invoke(sender, args);
            return;
        }
        public virtual void OnMouseMoved(object sender, EventArgs args)
        {
            WhenMouseMoved?.Invoke(sender, args);
            return;
        }
        public virtual void OnKeyPressed(object sender, EventArgs args)
        {
            WhenKeyPressed?.Invoke(sender, args);
            return;
        }
        public virtual void OnKeyReleassed(object sender, EventArgs args)
        {
            WhenKeyReleassed?.Invoke(sender, args);
            return;
        }
    }
}
