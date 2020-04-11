using System;

namespace Fan
{
    class Program
    {
        static void Main(string[] args)
        {
            Fan fan1 = new Fan();
            fan1.Speed = Fan.FAST;
            fan1.Radius = 10;
            fan1.Color = "yellow";
            fan1.On = true;
            Console.WriteLine(fan1.ToString());
            Fan fan2 = new Fan();
            fan2.Speed = Fan.MEDIUM;
            Console.WriteLine(fan2.ToString());
        }
    }
    class Fan
    {
        public const int SLOW = 1;
        public const int MEDIUM = 2;
        public const int FAST = 3;
        private int speed = SLOW;
        private bool on = false;
        private double radius = 5;
        private string color = "blue";
        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        public bool On
        {
            get => on;
            set => on = value;
        }
        public double Radius
        {
            get => radius;
            set => radius = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public Fan() { }
        public string ToString()
        {
            string info = "";
            if (this.on == true)
                info += "Speed: " + this.speed + ", color: " + this.color + ", radius: " + this.radius + ", fan is on.";
            else
                info += "Color: " + this.color + ", radius: " + this.radius + ", fan is off.";
            return info;
        }
    }
}
