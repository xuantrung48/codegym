﻿using System;

namespace DisplaySystemTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime localDate = DateTime.Now;
            System.Console.WriteLine("Datetime Now is :" + localDate);
        }
    }
}
