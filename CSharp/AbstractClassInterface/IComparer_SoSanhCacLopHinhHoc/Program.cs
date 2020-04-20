using System;
using System.Collections.Generic;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {

            // CircleComparer Test:

            Circle[] circles = new Circle[3];
            circles[0] = new Circle(3.6);
            circles[1] = new Circle();
            circles[2] = new Circle(3.5, "indigo", false);

            Console.WriteLine("Pre-sorted:");
            foreach (Circle circle in circles)
            {
                Console.WriteLine(circle);
            }

            IComparer<Circle> circleComparator = new CircleComparator();
            Array.Sort(circles, circleComparator);

            Console.WriteLine("After-sorted:");
            foreach (Circle circle in circles)
            {
                Console.WriteLine(circle);
            }

            //ComperableCircle Test:
            ComperableCircle[] circles2 = new ComperableCircle[3];
            circles2[0] = new ComperableCircle(3.6);
            circles2[1] = new ComperableCircle();
            circles2[2] = new ComperableCircle(3.5, "indigo", false);

            Console.WriteLine("Pre-sorted:");
            foreach (ComperableCircle circle in circles2)
            {
                Console.WriteLine(circle);
            }

            Array.Sort(circles2);

            Console.WriteLine("After-sorted:");
            foreach (ComperableCircle circle in circles2)
            {
                Console.WriteLine(circle);
            }
        }
    }
}
