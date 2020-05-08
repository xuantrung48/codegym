using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Bai2
{
    class Post : IPost
    {
        static int counter = 0;
        private int id = ++counter;
        private string title;
        private string content;
        private string author;
        private float average;
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Title
        {
            get => title;
            set => title = value;
        }
        public string Content
        {
            get => content;
            set => content = value;
        }
        public string Author
        {
            get => author;
            set => author = value;
        }
        public float Average
        {
            get => average;
        }
        public int[] Rates = new int[3];
        public void CalculatorRate()
        {
            int sumRates = 0;
            for (int i = 0; i < Rates.Length; i++)
            {
                sumRates += Rates[i];
            }
            average = (float)sumRates / Rates.Length;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}\tTitle: {Title}\tContent: {Content}\tAuthor: {Author}\tAverage: {Average}");
        }
    }
}
