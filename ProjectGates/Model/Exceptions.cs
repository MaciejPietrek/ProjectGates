using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGates.Model
{
    static class ExceptionChecker
    {
        static public void CheckPerceventagergumentException(params float[] values)
        {
            foreach(var value in values)
            {
                if (value > 1)
                    throw new PercentageArgumentException("Value over one");
                if (value < 0)
                    throw new PercentageArgumentException("Value below zero");
            }
        }
    }

    class PercentageArgumentException : Exception
    {
        public PercentageArgumentException(string message)
            : base(message)
        {

        }
    }
}
