using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            News[] newsArray = new News[0];
            byte option = 0;
            do
            {
                Console.WriteLine("1. Insert news\n2. View list news\n3. Average rate\n4. Exit");
                if (byte.TryParse(Console.ReadLine(), out byte op))
                {
                    option = op;
                }
                Process(option, ref newsArray);
            } while (option != 4);
        }
        static void Process(byte option, ref News[] newsArray)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    InsertNews(ref newsArray);
                    break;
                case 2:
                    Console.Clear();
                    ShowNews(newsArray);
                    break;
                case 3:
                    Console.Clear();
                    ShowNews2(newsArray);
                    break;
            }
        }
        static void InsertNews(ref News[] newsArray)
        {
            News news = new News();
            Console.Write("Title: ");
            news.Title = Console.ReadLine();
            Console.Write("Publish Date (dd/mm/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTime))
            {
                news.PublishDate = dateTime;
            }
            Console.Write("Author: ");
            news.Author = Console.ReadLine();
            Console.Write("Content: ");
            news.Content = Console.ReadLine();
            Console.WriteLine("3 Rates number: ");
            for (int i = 1; i < 4; i++)
            {
                Console.Write($"Rate {i}: ");
                if (float.TryParse(Console.ReadLine(), out float rate))
                {
                    news.RateList[i - 1] = rate;
                }
            }
            Array.Resize(ref newsArray, newsArray.Length + 1);
            newsArray[newsArray.Length - 1] = news;
        }
        static void ShowNews(News[] newsArray)
        {
            foreach(var news in newsArray)
            {
                news.Display();
                Console.WriteLine("______________________");
            }
        }
        static void ShowNews2(News[] newsArray)
        {
            foreach (var news in newsArray)
            {
                news.Calculate();
                news.Display();
                Console.WriteLine("______________________");
            }
        }
    }
}
