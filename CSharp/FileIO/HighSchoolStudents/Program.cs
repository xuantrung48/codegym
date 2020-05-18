using System;

namespace HighSchoolStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonService jsonService = new JsonService(@"D:\codegym\github\codegym\CSharp\FileIO\HighSchoolStudents\JSON\", "data.json", "Outcome.json");
        }
    }
}
