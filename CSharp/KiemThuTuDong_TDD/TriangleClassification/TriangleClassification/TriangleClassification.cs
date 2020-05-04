using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleClassificationDemo
{
    public class TriangleClassification
    {
        public double side1;
        public double side2;
        public double side3;
        public string ClassifyTriangle()
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0 || side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
                return "not a triangle";
            if (side1 == side2 && side2 == side3)
                return "equilateral triangle";
            if (side1 == side2 || side1 == side3 || side2 == side3)
                return "isosceles triangle";
            return "regular triangle";
        }
    }
}
