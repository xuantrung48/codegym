using System;
using System.Collections.Generic;

namespace BaiTapOOP2
{
    class PhoneBook
    {
        public Contact[] ContactList = new Contact[0];
        public void Add(Contact contact)
        {
            Array.Resize(ref ContactList, ContactList.Length + 1);
            ContactList[ContactList.Length - 1] = contact;
        }
        public bool Check(string name, out int index)
        {
            for (int i = 0; i < ContactList.Length; i++)
            {
                if (ContactList[i].Name == name)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        public void Update(string name, int newphone)
        {
            if (Check(name, out int index))
            {
                ContactList[index].PhoneNumber = newphone;
                Console.WriteLine("Contact updated!");
            }
            else
            {
                Console.WriteLine("Contact does not exist!");
            }
        }
        public void Remove(string name)
        {
            if (Check(name, out int index))
            {
                List<Contact> contactList = new List<Contact>(ContactList);
                contactList.RemoveAt(index);
                ContactList = contactList.ToArray();
                Console.WriteLine("Contact removed!");
            }
            else
            {
                Console.WriteLine("Contact does not exist!");
            }
        }
        public string Search(string name)
        {
            string result = "";
            foreach (var contact in ContactList)
            {
                if (contact.Name == name)
                    result += contact.ShowContact();
            }
            if (result == "")
                return "Not exists.";
            return result;
        }
        public string ShowContacts()
        {
            string result = "";
            foreach (var contact in ContactList)
            {
                result += contact.ShowContact() + '\n';
            }
            return result;
        }
    }
}
