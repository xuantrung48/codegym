using System;

namespace HienThiCacLoaiHinh
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Print a rectangle");
                Console.WriteLine("2. Print a square triangle");
                Console.WriteLine("3. Print an isosceles triangle");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    option = n;
                }
                Process(option);
            }
            while (option != 4);
        }
        static void Process(int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    printRectangle();
                    break;
                case 2:
                    printSquareTriangle();
                    break;
                case 3:
                    printIsoscelesTriangle();
                    break;
            }
        }

        static void printRectangle()
        {
            int width = 0;
            int height = 0;

            Console.Write("Please enter the rectangle's width: ");
            if (int.TryParse(Console.ReadLine(), out int w))
            {
                width = w;
            }

            Console.Write("Please enter the rectangle's height: ");
            if (int.TryParse(Console.ReadLine(), out int h))
            {
                height = h;
            }

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        static void printSquareTriangle()
        {
            int angle;
            int edge = 0;
            int e;
            Console.WriteLine("Where is the angle the square place?");
            Console.WriteLine("1. Bottom-left");
            Console.WriteLine("2. Top-left");
            Console.WriteLine("3. Top-right");
            Console.WriteLine("4. Bottom-right");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                angle = n; 
            }
            switch (n)
            {
                case 1:
                    Console.Clear();
                    ;
                    Console.Write("Please enter the height of the triangle edge: ");
                    if (int.TryParse(Console.ReadLine(), out e))
                    {
                        edge = e;
                    }
                    for (int i = 1; i <= edge; i++)
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Please enter the height of the triangle edge: ");
                    if (int.TryParse(Console.ReadLine(), out e))
                    {
                        edge = e;
                    }
                    for (int i = edge; i >= 1; i--)
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Please enter the height of the triangle edge: ");
                    if (int.TryParse(Console.ReadLine(), out e))
                    {
                        edge = e;
                    }
                    for (int i = 1; i <= edge; i++)
                    {
                        for (int k = 1; k <= i - 1; k++)
                        {
                            Console.Write("  ");
                        }
                        for (int j = 1; j <= edge - i; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Please enter the height of the triangle edge: ");
                    if (int.TryParse(Console.ReadLine(), out e))
                    {
                        edge = e;
                    }
                    for (int i = edge; i >= 1; i--)
                    {
                        for (int k = 1; k <= i - 1; k++)
                        {
                            Console.Write("  ");
                        }
                        for (int j = 1; j <= edge - i; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }

        static void printIsoscelesTriangle()
        {
            int height = 0;
            int e;
            Console.Clear();
            Console.Write("Please enter the height of the triangle: ");
            if (int.TryParse(Console.ReadLine(), out e))
            {
                height = e;
            }
            for (int i = 1; i <= height; i++)
            {
                for (int k = 1; k <= height - i; k++)
                {
                    Console.Write("  ");
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
