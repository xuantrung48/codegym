using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Teacher
{
    class Teacher : Person
    {
        private string subject;
        public void Explain()
        {
            Console.WriteLine("Explanation begins.");
        }
    }
}
