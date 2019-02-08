using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    class TextureNullReferenceException : Exception
    {
        public TextureNullReferenceException(string message) : base(message)
        {
            return;
        }
    }

    class FontNullReferenceException : Exception
    {
        public FontNullReferenceException(string message) : base(message)
        {
            return;
        }
    }
}
