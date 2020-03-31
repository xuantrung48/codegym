using System;

namespace ThietKeMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                do
                {
                    displayMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                while (choice != 1 && choice != 2 && choice != 3 && choice != 4);

                switch (choice)
                {
                    case 1:
                        drawTriangle();
                        break;
                    case 2:
                        drawSquare();
                        break;
                    case 3:
                        drawRectangle();
                        break;
                }
            }
            while (choice != 4);
        }
        static void displayMenu()
        {
            Console.WriteLine("1. Draw a triangle");
            Console.WriteLine("2. Draw a square");
            Console.WriteLine("3. Draw a rectangle");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }
        
        static void drawTriangle()
        {
            Console.WriteLine();
            Console.WriteLine("1. Draw a triangle:");
            Console.Write("Please enter the length of the triangle edge:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void drawSquare()
        {
            Console.WriteLine();
            Console.WriteLine("2. Draw a square:");
            Console.Write("Please enter the length of the square edge:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= length; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        
        static void drawRectangle()
        {
            Console.WriteLine();
            Console.WriteLine("3. Draw a rectangle:");
            Console.Write("Please enter the width of the rectangle:");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the height of the rectangle:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }    
        }
    }
}
