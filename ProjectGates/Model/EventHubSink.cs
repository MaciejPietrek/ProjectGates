using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    interface IEventHub
    {
        EventHub Hub { get; }
    }

    interface IEventSink
    {
        EventSink Sink { get; }
    }

    interface IEventNode : IEventHub, IEventSink
    {

    }

    class EventHub : IEventHub
    {
        public event EventHandler MouseScrolled;
        public event EventHandler MousePressed;
        public event EventHandler MouseMoved;
        public event EventHandler KeyPressed;
        public event EventHandler KeyReleassed;

        public EventHub Hub { get { return this; } }
    } 

    class EventSink : IEventSink
    {
        public void Connect(EventHub hub)
        {
            hub.KeyPressed += this.OnKeyPressed;
            hub.KeyReleassed += this.OnKeyReleassed;
            hub.MouseMoved += this.OnMouseMoved;
            hub.MousePressed += this.OnMousePressed;
            hub.MouseScrolled += this.OnMouseScrolled;
        }
        public void Disconnect(EventHub hub)
        {
            hub.KeyPressed -= this.OnKeyPressed;
            hub.KeyReleassed -= this.OnKeyReleassed;
            hub.MouseMoved -= this.OnMouseMoved;
            hub.MousePressed -= this.OnMousePressed;
            hub.MouseScrolled -= this.OnMouseScrolled;
        }

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

        public EventSink Sink { get { return this; } }
    }

    class EventNode : IEventNode
    {
        public EventHub Hub { get; }
        public EventSink Sink { get; }

        public EventNode()
        {
            Sink.Connect(Hub);
        }
    }
}
