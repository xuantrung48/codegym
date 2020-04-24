using System;

namespace Student_Teacher
{
    class StudentAndTeacherTest
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.SetAge(20);
            Console.WriteLine(student.GetAge());
        }
    }
}
