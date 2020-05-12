using System;

namespace BubbleSort_SlectionSort_InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bubble sort example
            IntArray array1 = new IntArray(5);

            Console.WriteLine("Array before sort: ");
            array1.Show();

            array1.BubbleSort();

            Console.WriteLine("Array after Bubble sort: ");
            array1.Show();
            Console.WriteLine("________________________");

            //Selection sort example
            IntArray array2 = new IntArray(5);

            Console.WriteLine("Array before sort: ");
            array2.Show();

            array2.SelectionSort();

            Console.WriteLine("Array after Selection sort: ");
            array2.Show();
            Console.WriteLine("________________________");

            //Insertion sort example
            IntArray array3 = new IntArray(5);

            Console.WriteLine("Array before sort: ");
            array3.Show();

            array3.InsertionSort();

            Console.WriteLine("Array after Insertion sort: ");
            array3.Show();
            Console.WriteLine("________________________");
        }
    }
}
