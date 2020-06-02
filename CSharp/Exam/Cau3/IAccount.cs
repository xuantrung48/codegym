using System;
using System.Collections.Generic;
using System.Text;

namespace Cau3
{
    interface IAccount
    {
        string ShowInfo();
        void PayInto(float amount);
    }
}
