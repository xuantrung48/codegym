using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook Codegym = new PhoneBook();
            int option = 0;
            do
            {
                Console.WriteLine("____________________________");
                Console.WriteLine("PhoneBook Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Update Contact");
                Console.WriteLine("3. Remove Contact");
                Console.WriteLine("4. Search Contact");
                Console.WriteLine("5. Show Contacts");
                Console.WriteLine("6. Exit");
                Console.WriteLine("____________________________");
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    option = n;
                }
                Process(option, ref Codegym);
            } while (option != 6);
        }
        static void Process(int option, ref PhoneBook contacts)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    AddContact(ref contacts);
                    break;
                case 2:
                    Console.Clear();
                    UpdateContact(ref contacts);
                    break;
                case 3:
                    Console.Clear();
                    RemoveContact(ref contacts);
                    break;
                case 4:
                    Console.Clear();
                    SearchContact(contacts);
                    break;
                case 5:
                    Console.Clear();
                    ShowContacts(contacts);
                    break;
            }
        }
        static void AddContact(ref PhoneBook contacts)
        {
            Console.WriteLine("Add Contact");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone number: ");
            int.TryParse(Console.ReadLine(), out int phoneNumber);
            Contact newContact = new Contact(name, phoneNumber);
            contacts.Add(newContact);
        }
        static void UpdateContact(ref PhoneBook contacts)
        {
            Console.WriteLine("Update Contact");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone number: ");
            int.TryParse(Console.ReadLine(), out int phoneNumber);
            contacts.Update(name, phoneNumber);
        }
        static void RemoveContact(ref PhoneBook contacts)
        {
            Console.WriteLine("Remove Contact");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            contacts.Remove(name);
        }
        static void SearchContact(PhoneBook contacts)
        {
            Console.WriteLine("Remove Contact");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("____________________________");
            Console.WriteLine("Search result: ");
            Console.WriteLine(contacts.Search(name));
        }
        static void ShowContacts(PhoneBook contacts)
        {
            Console.WriteLine(contacts.ShowContacts());
        }
    }
}
