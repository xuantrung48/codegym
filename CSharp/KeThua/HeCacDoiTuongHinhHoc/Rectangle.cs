using System;
using System.Collections.Generic;
using System.Text;

namespace HeCacDoiTuongHinhHoc
{
    class Rectangle : Shape
    {
        private double width = 1.0;
        private double length = 1.0;
        public Rectangle() { }
        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }
        public Rectangle(double width, double length, string color, bool filled) : base(color, filled)
        {
            this.width = width;
            this.length = length;
        }
        public double GetWidth()
        {
            return this.width;
        }
        public virtual void SetWidth(double width)
        {
            this.width = width;
        }
        public double GetLength()
        {
            return this.length;
        }
        public virtual void SetLength(double length)
        {
            this.length = length;
        }
        public double GetArea()
        {
            return this.length * this.length;
        }
        public double GetPerimeter()
        {
            return (this.length + this.length) * 2;
        }
        public override string ToString()
        {
            return "A Rectangle width width = " + this.width + " and length = " + this.length + ", which is a subclass of " + base.ToString();
        }
    } 
}
