using ProjectGates.Model.Entities;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Vistas
{
    abstract class Vista : EventSink, IEventHub, Drawable
    {
        private Dictionary<string, IEntity> EntityDictionary { get; set; }
        private HashSet<IEntity> EntitySet { get; set; }
        
        protected IEntity AddEntity(IEntity entity, string ID)
        {
            EntityDictionary.Add(ID, entity);
            return entity;
        }
        protected IEntity AddEntity(IEntity entity)
        {
            EntitySet.Add(entity);
            return entity;
        }
        protected IEntity GetEntity(string ID)
        {
            IEntity result = null;
            EntityDictionary.TryGetValue(ID, out result);
            return result;
        }

        protected Vista()
        {
            EntityDictionary = new Dictionary<string, IEntity>();
            EntitySet = new HashSet<IEntity>();
        }
        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            foreach(var entity in EntityDictionary)
                target.Draw(entity.Value);
            foreach (var entity in EntitySet)
                target.Draw(entity);
        }

        public virtual void Update(Time time) { return; }

        #region Event handlers
        public override void OnMouseScrolled(object sender, EventArgs args)
        {
            base.OnMouseScrolled(sender, args);
            MouseScrolled?.Invoke(sender, args);
        }
        public override void OnMousePressed(object sender, EventArgs args)
        {
            base.OnMousePressed(sender, args);
            MousePressed?.Invoke(sender, args);
        }
        public override void OnMouseMoved(object sender, EventArgs args)
        {
            base.OnMouseMoved(sender, args);
            MouseMoved?.Invoke(sender, args);
        }
        public override void OnKeyPressed(object sender, EventArgs args)
        {
            base.OnMousePressed(sender, args);
            KeyPressed?.Invoke(sender, args);
        }
        public override void OnKeyReleassed(object sender, EventArgs args)
        {
            base.OnKeyReleassed(sender, args);
            KeyReleassed?.Invoke(sender, args);
        }
        #endregion

        public event EventHandler MouseScrolled;
        public event EventHandler MousePressed;
        public event EventHandler MouseMoved;
        public event EventHandler KeyPressed;
        public event EventHandler KeyReleassed;

    }
}
