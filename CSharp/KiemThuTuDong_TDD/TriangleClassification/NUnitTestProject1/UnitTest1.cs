using NUnit.Framework;
using System;
using TriangleClassificationDemo;
namespace NUnitTestProject1
{
    public class Tests
    {
        private TriangleClassification triangle;
        [SetUp]
        public void Setup()
        {
            triangle = new TriangleClassification();
        }

        [Test]
        public void Test1()
        {
            triangle.side1 = 2;
            triangle.side2 = 2;
            triangle.side3 = 2;
            Assert.AreEqual(triangle.ClassifyTriangle(), "equilateral triangle");
        }
        [Test]
        public void Test2()
        {
            triangle.side1 = 2;
            triangle.side2 = 2;
            triangle.side3 = 3;
            Assert.AreEqual(triangle.ClassifyTriangle(), "isosceles triangle");
        }
        [Test]
        public void Test3()
        {
            triangle.side1 = 3;
            triangle.side2 = 4;
            triangle.side3 = 5;
            Assert.AreEqual(triangle.ClassifyTriangle(), "regular triangle");
        }
        [Test]
        public void Test4()
        {
            triangle.side1 = 8;
            triangle.side2 = 2;
            triangle.side3 = 3;
            Assert.AreEqual(triangle.ClassifyTriangle(), "not a triangle");
        }
        [Test]
        public void Test5()
        {
            triangle.side1 = -1;
            triangle.side2 = 2;
            triangle.side3 = 1;
            Assert.AreEqual(triangle.ClassifyTriangle(), "not a triangle");
        }
        [Test]
        public void Test6()
        {
            triangle.side1 = 0;
            triangle.side2 = 1;
            triangle.side3 = 1;
            Assert.AreEqual(triangle.ClassifyTriangle(), "not a triangle");
        }
    }
}