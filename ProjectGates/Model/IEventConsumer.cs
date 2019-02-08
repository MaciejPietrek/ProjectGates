using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    interface IEventConsumer
    {
        void Connect(Vistas.Vista vista);
    }
}
