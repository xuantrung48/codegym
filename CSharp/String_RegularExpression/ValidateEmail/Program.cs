using System;
using System.Text.RegularExpressions;

namespace ValidateEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailExample validateEmail = new EmailExample();
            Console.WriteLine(validateEmail.Validate("89$02sd@gmail.com"));
        }
    }
    public class EmailExample
    {
        private static string EMAIL_REGEX = "^[A-Za-z0-9]+[A-Za-z0-9]*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)$";
        public bool Validate(string regex)
        {
            return Regex.IsMatch(regex, EMAIL_REGEX);
        }
    }
}
