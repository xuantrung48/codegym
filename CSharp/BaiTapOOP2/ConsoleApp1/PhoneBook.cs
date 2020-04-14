using System;

namespace ConsoleApp1
{
    class PhoneBook
    {
        public Contact[] ContactList = new Contact[0];
        public void Add(Contact contact)
        {
            Array.Resize(ref ContactList, ContactList.Length + 1);
            ContactList[ContactList.Length - 1] = contact;
        }
        public bool Check(string name)
        {
            for (int i = 0; i < ContactList.Length; i++)
            {
                if (ContactList[i].Name == name)
                    return true;
            }
            return false;
        }
        public void Update(string name, int newphone)
        {
            foreach (var contact in ContactList)
            {
                if (contact.Name == name)
                {
                    contact.PhoneNumber = newphone;
                }
            }
        }
        public void Remove(string name)
        {
            bool found = false;
            for (int i = 0; i < ContactList.Length; i++)
            {
                if (ContactList[i].Name == name)
                {
                    found = true;
                    for (int j = i; j < ContactList.Length - 1; j++)
                    {
                        ContactList[i] = ContactList[i + 1];
                    }
                }
            }
            if (found == true)
                Array.Resize(ref ContactList, ContactList.Length - 1);
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
