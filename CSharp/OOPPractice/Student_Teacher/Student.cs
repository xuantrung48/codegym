﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Teacher
{
    class Student : Person
    {
        public void GoToClasses()
        {
            Console.WriteLine("I'm going to class.");
        }
        public void ShowAge()
        {
            Console.WriteLine($"My age is: {GetAge()}");
        }
    }
}
