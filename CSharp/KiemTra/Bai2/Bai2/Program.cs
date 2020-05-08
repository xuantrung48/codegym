using System;
using System.Net.Mime;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Forum forum = new Forum();
            string option;
            do
            {
                Console.WriteLine("POSTS MANAGEMENT SYSTEM");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Create Post\n2. Update Post\n3. Remove Post\n4. Show Posts\n5. Exit");
                Console.Write("Your option: ");
                option = Console.ReadLine();
                Process(option, ref forum);
            } while (option != "5");
        }
        static void Process(string option, ref Forum forum)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreatePost(ref forum);
                    break;
                case "2":
                    Console.Clear();
                    UpdatePost(ref forum);
                    break;
                case "3":
                    Console.Clear();
                    RemovePost(ref forum);
                    break;
                case "4":
                    Console.Clear();
                    ShowPosts(ref forum);
                    break;
            }
        }
        static void CreatePost(ref Forum forum)
        {
            Post newPost = new Post();
            Console.WriteLine("Create new post:");
            Console.Write("Title: ");
            newPost.Title = Console.ReadLine();
            Console.Write("Content: ");
            newPost.Content = Console.ReadLine();
            Console.Write("Author: ");
            newPost.Author = Console.ReadLine();

            for (int i = 0; i < newPost.Rates.Length; i++) {
                int rate = 0;
                do
                {
                    Console.Write($"Rates {i}: ");
                    if (int.TryParse(Console.ReadLine(), out rate))
                    {
                        newPost.Rates[i] = rate;
                    }
                } while (rate < 0 || rate > 5);
            }

            newPost.CalculatorRate();
            forum.Add(newPost);
        }
        static void UpdatePost(ref Forum forum)
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            Console.Write("Content: ");
            string content = Console.ReadLine();
            forum.Update(id, content);
            Console.WriteLine("Post updated!");
        }
        static void RemovePost(ref Forum forum)
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            forum.Remove(id);
            Console.WriteLine("Post removed!");
        }
        static void ShowPosts(ref Forum forum)
        {
            forum.Show();
        }
    }
}
