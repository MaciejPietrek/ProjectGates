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
    abstract class Vista : Drawable
    {
        #region Entities.
        private Dictionary<string, IEntity> EntityDictionary { get; set; }
        private HashSet<IEntity> EntitySet { get; set; }

        public IEntity AddEntity(IEntity entity, string ID)
        {
            if (entity is IEventConsumer consumer)
            {
                this.WhenKeyPressed             += consumer.WhenKeyPressed;
                this.WhenKeyReleased            += consumer.WhenKeyReleased;
                this.WhenMouseButtonPressed     += consumer.WhenMouseButtonPressed;
                this.WhenMouseButtonReleased    += consumer.WhenMouseButtonReleased;
                this.WhenMouseMoved             += consumer.WhenMouseMoved;
                this.WhenMouseWeelMoved         += consumer.WhenMouseWeelMoved;
            }
            EntityDictionary.Add(ID, entity);
            return entity;
        }
        public IEntity AddEntity(IEntity entity)
        {
            if (entity is IEventConsumer consumer)
            {
                this.WhenKeyPressed             += consumer.WhenKeyPressed;
                this.WhenKeyReleased            += consumer.WhenKeyReleased;
                this.WhenMouseButtonPressed     += consumer.WhenMouseButtonPressed;
                this.WhenMouseButtonReleased    += consumer.WhenMouseButtonReleased;
                this.WhenMouseMoved             += consumer.WhenMouseMoved;
                this.WhenMouseWeelMoved         += consumer.WhenMouseWeelMoved;
            }
            EntitySet.Add(entity);
            return entity;
        }
        public IEntity GetEntity(string ID)
        {
            IEntity result = null;
            EntityDictionary.TryGetValue(ID, out result);
            return result;
        }

        protected IEnumerable<IEntity> Entities
        {
            get
            {
                var result = EntityDictionary.Values;
                var reesult = result.Concat(EntitySet);
                return reesult;
            }
        }
        #endregion

        #region OnDraw & OnUpdate Actions.
        public readonly Action<RenderTarget, RenderStates> DefaultOnDraw;
        public readonly Action<Time> DefaultOnUpdate;

        public Action<RenderTarget, RenderStates> OnDraw { get; set; }
        public Action<Time> OnUpdate { get; set; }
        #endregion
        
        #region Constructor.
        protected Vista()
        {
            EntityDictionary = new Dictionary<string, IEntity>();
            EntitySet = new HashSet<IEntity>();
            
            DefaultOnDraw = ((target, states) =>
            {
                foreach (var entity in Entities)
                    target.Draw(entity);
            });
            DefaultOnUpdate = ((time) =>
            {
                return;
            });
            
            OnDraw = DefaultOnDraw;
            OnUpdate = DefaultOnUpdate;
        }
        #endregion

        #region Event handlers.
        public EventHandler<KeyEventArgs>           WhenKeyPressed = null;
        public EventHandler<KeyEventArgs>           WhenKeyReleased = null;
        public EventHandler<MouseButtonEventArgs>   WhenMouseButtonPressed = null;
        public EventHandler<MouseButtonEventArgs>   WhenMouseButtonReleased = null;
        public EventHandler<MouseMoveEventArgs>     WhenMouseMoved = null;
        public EventHandler<MouseWheelEventArgs>    WhenMouseWeelMoved = null;
        #endregion

        #region Draw & Update methods.
        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            OnDraw(target, states);
        }
        public virtual void Update(Time time)
        {
            OnUpdate(time);
        }
        #endregion
    }
}
