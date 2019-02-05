using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceHolder<T>
    {
        protected Dictionary<Enum, T> resource;
        protected static Dictionary<Enum, T> globalResource;

        public ResourceHolder()
        {
            resource = new Dictionary<Enum, T>();
        }
        static ResourceHolder()
        {
            globalResource = new Dictionary<Enum, T>();
        }

        public void AddResource(Enum key, T resource)
        {
            this.resource.Add(key, resource);
        }
        public virtual void AddResource(Enum key, string path)
        {
            throw new NotImplementedException();
        }

        public static void AddGlobalResource(Enum key, T resource)
        {
            globalResource.Add(key, resource);
        }

        public T GetResource(Enum key)
        {
            resource.TryGetValue(key, out T result);
            return result;
        }

        public static T GetGlobalResource(Enum key)
        {
            globalResource.TryGetValue(key, out T result);       
            return result;
        }
    }
}
