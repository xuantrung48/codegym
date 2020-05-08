using System;

namespace Bai2
{
    class Program
    {
        private static readonly Forum forum = new Forum();
        static void Main(string[] args)
        {
            string option;
            do
            {
                Console.WriteLine("_______________________\n" +
                                  "FORUM MANAGEMENT SYSTEM\n" +
                                  "Menu:\n" +
                                  "1. Create Post\n" +
                                  "2. Update Post\n" +
                                  "3. Remove Post\n" +
                                  "4. Show Posts\n" +
                                  "5. Exit");
                Console.Write("Your option: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "5");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreatePost();
                    break;
                case "2":
                    Console.Clear();
                    UpdatePost();
                    break;
                case "3":
                    Console.Clear();
                    RemovePost();
                    break;
                case "4":
                    Console.Clear();
                    ShowPosts();
                    break;
            }
        }
        static void CreatePost()
        {
            Console.WriteLine("Create new post:");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Content: ");
            string content = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            int[] rates = new int[3];
            for (int i = 0; i < rates.Length; i++) 
            {
                int rate;
                do
                {
                    Console.Write($"Rates {i}: ");
                    if (int.TryParse(Console.ReadLine(), out rate))
                        rates[i] = rate;
                } while (rate < 0 || rate > 5);
            }
            Post newPost = new Post(title, content, author, rates);
            forum.Add(newPost.Id, newPost);
        }
        static bool CheckExist(int id, out int key)
        {
            key = -1;
            foreach(var item in forum.Posts)
            {
                if (item.Value.Id == id)
                {
                    key = item.Key;
                    return true;
                }
            }
            return false;
        }
        static void UpdatePost()
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (CheckExist(id, out int key))
            {
                Console.Write("Content: ");
                forum.Posts[key].Content = Console.ReadLine();
                Console.WriteLine("Post updated!");
            }
            else
                Console.WriteLine("Post is not exists!");
        }
        static void RemovePost()
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            if (CheckExist(id, out _))
            {
                forum.Remove(id);
                Console.WriteLine("Post removed!");
            }
            else
                Console.WriteLine("Post is not exists!");
        }
        static void ShowPosts()
        {
            forum.Show();
        }
    }
}
