using System;

namespace Bai2
{
    class Post : IPost
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public float Average { get; private set; }
        public int[] Rates;

        static int counter = 0;
        public Post(string title, string content, string author, int[] rates)
        {
            Id = ++counter;
            this.Title = title;
            this.Content = content;
            this.Author = author;
            this.Rates = rates;
            CalculatorRate();
        }
        public void CalculatorRate()
        {
            int sumRates = 0;
            for (int i = 0; i < Rates.Length; i++)
                sumRates += Rates[i];
            Average = (float)sumRates / Rates.Length;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {Id}\tTitle: {Title}\tContent: {Content}\tAuthor: {Author}\tAverage: {Average}");
        }
    }
}
