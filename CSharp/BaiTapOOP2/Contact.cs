namespace BaiTapOOP2
{
    class Contact
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public Contact(string name, int phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public string ShowContact()
        {
            return $"Name: {Name} |Phone number: {PhoneNumber}.";
        }
    }
}
