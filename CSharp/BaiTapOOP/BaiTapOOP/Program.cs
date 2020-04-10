using System;

namespace BaiTapOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            int option = 0;

            Employee[] employees = new Employee[0];
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create employees array");
                Console.WriteLine("2. Show employees");
                Console.WriteLine("3. Search employee");
                Console.WriteLine("4. Exit");
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    option = num;
                }
                Console.Clear();
                Process(option, ref employees);
            } while (option != 4);
        }
        static void Process(int option, ref Employee[] employees)
        {
            switch (option)
            {
                case 1:
                    CreateEmployeeArray(ref employees);
                    break;
                case 2:
                    ShowEmployees(employees);
                    break;
                case 3:
                    SearchEmployees(employees);
                    break;
            }
        }
        static void SearchEmployees(Employee[] employees)
        {
            Console.Write("Enter the name to search: ");
            string nameToSearch = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("No\tName\tEmail\tDoB\tAddress");
            int counter = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Name.ToLower().Contains(nameToSearch.ToLower()))
                {
                    counter++;
                    Console.WriteLine(counter + ".\t" + employees[i].Name + "\t" + employees[i].Email + "\t" + employees[i].DoB.ToString("dd/MM/yyyy") + "\t" + employees[i].Address);
                }
            }
            if (counter == 0)
                Console.WriteLine("Not found.");
        }
        static void ShowEmployees(Employee[] employees)
        {
            Console.WriteLine("Employees list: ");
            Console.WriteLine("No\tName\tEmail\tDoB\tAddress");
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(i + 1 + ".\t" + employees[i].Name + "\t" + employees[i].Email + "\t" + employees[i].DoB.ToString("dd/MM/yyyy") + "\t" + employees[i].Address);
            }
        }
        static void CreateEmployeeArray(ref Employee[] employees)
        {
            int n = 1;
            do
            {
                Console.WriteLine("Create an employee:");
                Array.Resize(ref employees, employees.Length + 1);
                employees[employees.Length - 1] = CreateEmployee();
                Console.Write("Enter 0 to exit! or any to create another employee: ");
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    n = num;
                }
                Console.Clear();
            } while (n != 0);
        }
        static Employee CreateEmployee()
        {
            Console.Write("Employee's name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Date of Birth: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dob);
            Console.Write("Address: ");
            string address = Console.ReadLine();
            string nameToLower = name.ToLower();
            Employee newEmployee = new Employee(name, email, dob, address);
            return newEmployee;
        }
    }
}
