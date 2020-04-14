using System;

namespace ClassStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Student student1 = new Student(1, "M. Công", "Hà Nội", 30);

            Student student2 = new Student();
            student2.SetId(2);
            student2.SetName("Ph. Quang Khánh");
            student2.SetAddress("Lạng Sơn");
            student2.SetAge(25);

            Console.WriteLine(student1.ToString());
            Console.WriteLine(student2.ToString());
            Console.Read();
        }
    }
    class Student
    {
        private int id;
        private string name;
        private string address;
        private int age;

        public Student() { }
        public Student(int _id, string _name, string _address, int _age)
        {
            this.id = _id;
            this.name = _name;
            this.address = _address;
            this.age = _age;
        }
        public int GetId()
        {
            return this.id;
        }

        public void SetId(int _id)
        {
            this.id = _id;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string _name)
        {
            this.name = _name;
        }

        public int GetAge()
        {
            return this.age;
        }

        public void SetAge(int _age)
        {
            this.age = _age;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public void SetAddress(string _address)
        {
            this.address = _address;
        }
        public override string ToString()
        {
            return "Id : " + id + " Name : " + name + " Address : " + address + " Age : " + age;
        }
    }
}
