using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    abstract class Shape
    {
        protected Location location = new Location();

        public abstract override string ToString();
        public abstract double Area();
        public abstract double Perimeter();
    }
}
