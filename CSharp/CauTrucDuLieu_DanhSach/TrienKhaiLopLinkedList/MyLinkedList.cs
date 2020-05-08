using System;

namespace TrienKhaiLopLinkedList
{
    class MyLinkedList
    {
        Node Head;
        int NodeCnt = 0;
        public MyLinkedList(object Data)
        {
            Head = new Node(Data);
        }
        public void Add(object Data, int idx)
        {
            Node temp = Head;
            Node holder;
            for (int i = 0; i < idx - 1 && temp.Next != null; i++)
            {
                temp = temp.Next;
            }

            holder = temp.Next;
            temp.Next = new Node(Data);
            temp.Next.Next = holder;
            NodeCnt++;
        }
        public void AddFirst(object Data)
        {
            Node temp = Head;
            Head = new Node(Data);
            Head.Next = temp;
            NodeCnt++;
        }
        public Node GetData(int idx)
        {
            Node temp = Head;
            for (int i = 0; i < idx; i++)
            {
                temp = temp.Next;
            }
            return temp;
        }
        public void PrintList()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
