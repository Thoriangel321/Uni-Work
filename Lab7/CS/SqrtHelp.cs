using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    internal class SqrtHelp
    {
        public static double CalculateSquareRoot(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Impossible to calculate a square root of a negative value: {value}.");
            }
            return Math.Sqrt(value);
        }
    }
}
