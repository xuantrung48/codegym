﻿using System;

namespace TrienKhaiLopList
{
    class MyList<T>
    {
        private int Capacity { get; set; }
        private T[] Items;
        public MyList()
        {
            Items = new T[10];
        }

        private void EnsureCapacity()
        {
            int newSize = Items.Length + 1;
            Array.Copy(Items, Items, newSize);
        }
        public void Add(T data)
        {
            if (Capacity == Items.Length)
                EnsureCapacity();
            Items[Capacity++] = data;
        }
        public T GetData(int idx)
        {
            if (idx >= Capacity || idx < 0)
                throw new IndexOutOfRangeException("Index: " + idx + ", Capacity: " + Capacity);
            return Items[idx];
        }
    }
}
