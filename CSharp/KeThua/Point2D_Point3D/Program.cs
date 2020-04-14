using System;

namespace Point2D_Point3D
{
    class Point2D
    {
        private float x = 0.00f;
        private float y = 0.00f;
        public float GetX()
        {
            return x;
        }
        public void SetX (float x)
        {
            this.x = x;
        }
        public float GetY()
        {
            return y;
        }
        public void SetY(float y)
        {
            this.y = y;
        }
        public float GetXY()
        {
            return GetX() * GetY();
        }
        public void SetXY(float x, float y)
        {

        }
        public Point2D() { }
        public Point2D(float x, float y) { }
        public override string ToString()
        {
            return "x = " + x + ", y = " + y;
        }
    }
    class Point3D : Point2D
    {
        private float z = 0.00f;
        public float GetZ()
        {
            return z;
        }
        public void SetZ(float z)
        {
            this.z = z;
        }
        public float GetXYZ()
        {
            return GetX() * GetY() * GetZ();
        }
        public void SetXYZ(float x, float y, float z)
        {

        }
        public Point3D() { }
        public Point3D(float x, float y, float z) { }
        public override string ToString()
        {
            return "x = " + GetX() + ", y = " + GetY() + ", z = " + GetZ();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
