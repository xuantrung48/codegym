using System;

namespace refactoring_method_extraction
{
    class CylinderTest
    {
        static void Main(string[] args)
        {
            double result = CylinderDemo.GetVolume(2,4);
            Console.WriteLine(result);
        }
    }
}
