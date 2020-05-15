using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    class TotalNumbers
    {
        public List<int> Total = new List<int>();
        public TotalNumbers(NumbersList numbers)
        {
            Total.Add(numbers.Numbers[0].Total());
            Total.Add(numbers.Numbers[1].Total());
            Total.Add(numbers.Numbers[2].Total());
        }
    }
}
