using System;
using System.Collections.Generic;
using System.Text;

namespace NextDayCalculator.Service
{
    public class NextDayCalculatorService
    {
        public DateTime Date { get; set; }
        public DateTime nextDay()
        {
            return Date.AddDays(1);
        }
    }
}
