using System;
using System.Collections.Generic;
using System.Text;

namespace HeCacDoiTuongHinhHoc
{
    class Circle : Shape
    {
        private double radius = 1.0;
        public Circle() { }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(string color, bool filled, double radius) : base(color, filled)
        {
            this.radius = radius;
        }
        public double GetRadius()
        {
            return this.radius;
        }
        public void SetRadius(double radius)
        {
            this.radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }
        public double GetPerimeter()
        {
            return 2 * Math.PI * this.radius;
        }
        public override string ToString()
        {
            return "A Circle with radius = " + this.radius + ", which is a subclass of " + base.ToString();
        }
    }
}
