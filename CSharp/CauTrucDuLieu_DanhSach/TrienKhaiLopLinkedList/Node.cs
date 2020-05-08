namespace TrienKhaiLopLinkedList
{
    class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node(object Data)
        {
            this.Data = Data;
            Next = null;
        }
    }
}
