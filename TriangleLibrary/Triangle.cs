using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleLibrary
{
    public class Triangle
    {
        public float SideA { get; set; }
        public float SideB { get; set; }
        public float SideC { get; set; }
    }

    public class Result
    {
        public float? Square { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class TriangleOperations
    {
        public static Result Square(Triangle triangle)
        {
            float[] sides = { 
                                triangle.SideA, 
                                triangle.SideB, 
                                triangle.SideC 
                            };

            if (sides.Contains(0))
            {
                return new Result
                {
                    Square = 0
                };
            }

            if (sides.Select(s => s < 0).Contains(true))
            {
                return new Result
                {
                    Square = null,
                    ErrorMessage = "Стороны треугольника не могут быть отрицательными"
                };
            }

            if (sides.Select(s => s >= float.MaxValue).Contains(true))
            {
                return new Result
                {
                    Square = null,
                    ErrorMessage = String.Format("Стороны треугольника не могут превышать значение {0}", float.MaxValue)
                };
            }

            var hypotenuse = sides.Max();
            var cathetus = sides.Where(s => s != hypotenuse).ToArray();
            var cathetusA = cathetus[0];
            var cathetusB = cathetus[1];

            //Так как не происходит OverflowException, то проверим переполнение вот так:
            if (float.IsInfinity(cathetusA * cathetusA + cathetusB * cathetusB) || float.IsInfinity(cathetusA + cathetusB) || float.IsInfinity(cathetusA * cathetusB))
                return new Result
                {
                    Square = null,
                    ErrorMessage = "Переполнение. Заданы слишком большие стороны треугольника"
                };

            if (hypotenuse > cathetusA + cathetusB)
                return new Result
                {
                    Square = null,
                    ErrorMessage = "Неверно заданы стороны треугольника"
                };

            return new Result { Square = (cathetusA * cathetusB) / 2 };
        }
    }
}
