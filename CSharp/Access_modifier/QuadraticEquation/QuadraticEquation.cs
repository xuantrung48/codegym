using System;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        private double a;
        private double b;
        private double c;

        public QuadraticEquation() { }

        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double GetDiscriminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }

        public double GetRoot1(double a, double b, double delta)
        {
            var r1 = (-b + Math.Sqrt(delta)) / (2 * a);
            return r1;
        }

        public double GetRoot2(double a, double b, double delta)
        {
            var r2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return r2;
        }
    }
}