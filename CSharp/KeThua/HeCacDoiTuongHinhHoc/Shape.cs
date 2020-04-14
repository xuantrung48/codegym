using System;
using System.Collections.Generic;
using System.Text;

namespace HeCacDoiTuongHinhHoc
{
    class Shape
    {
        private string color = "green";
        private bool filled = true;
        public Shape() { }
        public Shape(string color, bool filled)
        {
            this.color = color;
            this.filled = filled;
        }
        public string GetColor()
        {
            return this.color;
        }
        public void SetColor(string color)
        {
            this.color = color;
        }
        public bool IsFilled()
        {
            return this.filled;
        }
        public void SetFilled(bool filled)
        {
            this.filled = filled;
        }
        public override string ToString()
        {
            return "A Shape with color of " + this.color + " and " + (this.IsFilled() ? "filled" : "not filled") + ".";
        }
    }
}
