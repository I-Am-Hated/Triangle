using System;
using TriangleLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestZero()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = 0,
                SideB = 0,
                SideC = 0
            });

            Assert.AreEqual(0, result.Square);
        }

        [TestMethod]
        public void TestMinus()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = -1,
                SideB = 1,
                SideC = 2
            });

            Assert.AreEqual("Стороны треугольника не могут быть отрицательными", result.ErrorMessage);
        }

        [TestMethod]
        public void TestHypotenuseFail()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = 22,
                SideB = 1,
                SideC = 2
            });

            Assert.AreEqual("Неверно заданы стороны треугольника", result.ErrorMessage);
        }

        [TestMethod]
        public void TestSideOverflow()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = float.MaxValue + 1,
                SideB = 1,
                SideC = 2
            });

            Assert.AreEqual(String.Format("Стороны треугольника не могут превышать значение {0}", float.MaxValue), result.ErrorMessage);
        }

        [TestMethod]
        public void TestSquareOverflow()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = 3 * (float)Math.Pow(10, 25),
                SideB = 4 * (float)Math.Pow(10, 25),
                SideC = 5 * (float)Math.Pow(10, 25)
            });

            Assert.AreEqual("Переполнение. Заданы слишком большие стороны треугольника", result.ErrorMessage);
        }

        [TestMethod]
        public void TestSuccess()
        {
            var result = TriangleOperations.Square(new Triangle
            {
                SideA = 3,
                SideB = 4,
                SideC = 5
            });

            Assert.AreEqual(6, result.Square);
        }
    }
}
