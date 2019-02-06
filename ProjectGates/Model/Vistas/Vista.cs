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
    abstract class Vista : IEventNode
    {
        private Dictionary<string, IEntity> EntityDictionary { get; set; }
        private HashSet<IEntity> EntitySet { get; set; }

        protected IEntity AddEntity(IEntity entity, string ID)
        {
            if (entity is IEventSink eventSink)
            {
                eventSink.Sink.Connect(Hub);
            }
            EntityDictionary.Add(ID, entity);
            return entity;
        }
        protected IEntity AddEntity(IEntity entity)
        {
            if (entity is IEventSink eventSink)
            {
                eventSink.Sink.Connect(Hub);
            }
            EntitySet.Add(entity);
            return entity;
        }
        protected IEntity GetEntity(string ID)
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
        
        /* OnStart & OnExit deprecated
        private int Count = 100;

        public Action OnStart
        {
            get
            {
                return () =>
                {
                    if (Count == 200)
                    {
                        foreach (var entity in Entities)
                        {
                            if (entity is ITransparent e)
                            {
                                e.Transparency = (PGPercent)0;
                            }
                        }
                    }
                    foreach (var entity in Entities)
                    {
                        if (entity is ITransparent e)
                        {
                            e.Transparency += (PGPercent)0.005;
                        }
                    }
                    Count--;
                    if (Count <= 0)
                    {
                        Count = 200;
                        OnDraw = DefaultOnDraw;
                    }
                };
            }
        }
        public Action OnExit
        {
            get
            {
                return () =>
                {
                    foreach (var entity in Entities)
                    {
                        if (entity is ITransparent e)
                        {
                            e.Transparency -= (PGPercent)0.01;
                        }
                    }
                    Count--;
                    if (Count <= 0)
                    {
                        foreach(var entity in Entities)
                        {
                            if (entity is ITransparent e)
                            {
                                e.Transparency = (PGPercent)1;
                            }
                        }
                        Count = 100;
                        OnDraw = DefaultOnDraw;
                    }
                };
            }
        }
        */

        public readonly Action DefaultOnDraw;
        public readonly Action<Time> DefaultOnUpdate;

        public Action OnDraw { get; set; }
        public Action<Time> OnUpdate { get; set; }

        public EventHub Hub { get; }

        public EventSink Sink { get; }

        public virtual void Draw()
        {
            OnDraw();
        }
        public virtual void Update(Time time)
        {
            OnUpdate(time);
        }

        protected Vista()
        {
            EntityDictionary = new Dictionary<string, IEntity>();
            EntitySet = new HashSet<IEntity>();

            DefaultOnDraw = (() =>
            {
                foreach (var entity in Entities)
                    Engine.MainWindow.Draw(entity);
            });
            DefaultOnUpdate = ((time) =>
            {
                return;
            });

            OnDraw = DefaultOnDraw;
            OnUpdate = DefaultOnUpdate;
        }
    }
}
