using System;
using System.Text;

namespace ClassAnimalAndInterfaceEdible
{
    abstract class Animal
    {
        public abstract string MakeSound();
    }
    class Tiger : Animal
    {
        public override string MakeSound()
        {
            return "Gừ gừ!!!";
        }
    }
    interface IEdible
    {
        public string HowToEat();
    }
    abstract class Fruit : IEdible
    {
        public abstract string HowToEat();
    }
    class Orange : Fruit
    {
        public override string HowToEat()
        {
            return "Vắt lấy nước uống";
        }
    }
    class Apple : Fruit
    {
        public override string HowToEat()
        {
            return "Ăn trực tiếp";
        }
    }
    class Chicken : Animal, IEdible
    {
        public override string MakeSound()
        {
            return "Ò ó o!!!";
        }
        public string HowToEat()
        {
            return "Nướng rồi ăn";
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Tiger tiger = new Tiger();
            Console.WriteLine(tiger.MakeSound());
            Chicken chicken = new Chicken();
            Console.WriteLine(chicken.MakeSound());
            Console.WriteLine(chicken.HowToEat());
            Orange orange = new Orange();
            Console.WriteLine(orange.HowToEat());
            Apple apple = new Apple();
            Console.WriteLine(apple.HowToEat());
        }
    }
}