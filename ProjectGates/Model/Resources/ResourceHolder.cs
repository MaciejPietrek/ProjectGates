using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model.Resources
{
    class ResourceHolder<T>
    {
        protected Dictionary<Enum, T> dictionary;

        public ResourceHolder()
        {
            dictionary = new Dictionary<Enum, T>();
        }

        public void AddResource(Enum key, T resource)
        {
            dictionary.Add(key, resource);
        }

        public virtual void AddResource(Enum key, string path)
        {
            return;
        }

        public T GetResource(Enum key)
        {
            T result;
            dictionary.TryGetValue(key, out result);
            return result;
        }
    }
}
