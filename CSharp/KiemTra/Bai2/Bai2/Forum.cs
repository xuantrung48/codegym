using System;
using System.Collections.Generic;

namespace Bai2
{
    class Forum
    {
        public SortedList<int, Post> Posts= new SortedList<int, Post>();
        public void Add(int key, Post newPost)
        {
            Posts.Add(key, newPost);
        }
        public void Update(int id, string content)
        {
            foreach(var item in Posts)
            {
                if (id == item.Value.Id)
                {
                    item.Value.Content = content;
                }
            }
        }
        public void Remove(int id)
        {
            Posts.Remove(id);
        }
        public void Show()
        {
            if (Posts.Count == 0)
                Console.WriteLine("No posts!");
            else
            {
                foreach (var item in Posts)
                {
                    item.Value.Display();
                }
            }
        }
    }
}
