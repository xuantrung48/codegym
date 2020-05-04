using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteCalculator.Service
{
    public class AbsoluteNumberCalulator
    {
        public int FindAbsolute(int number)
        {
            if (number < 0)
                return 0 - number;
            return number;
        }
    }
}
