using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    internal class ExpressionEvaluator
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public ExpressionEvaluator() { }

        public ExpressionEvaluator(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public void SetValues(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override string ToString()
        {
            return $"a = {A}, b = {B}, c = {C}, d = {D}";
        }

        private double CalculateNumerator()
        {
            return 1 + A - (B / 2.0);
        }

        private double CalculateDenominator()
        {
            try
            {
                if (B == 0)
                {
                    throw new DivideByZeroException("b = 0, what leads to an error");
                }

                double sqrtPart = SqrtHelp.CalculateSquareRoot(24 + D);

                double denominator = sqrtPart - C + (A / B);

                if (denominator == 0)
                {
                    throw new DivideByZeroException("Denominator equals zero. Division by zero is impossible");
                }

                return denominator;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException("Unresolved expression that led to an error in denominator", ex);
            }
        }

        public double Calculate()
        {
            try
            {
                double numerator = CalculateNumerator();
                double denominator = CalculateDenominator();

                return numerator / denominator;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unexpected error with this object -  [{this}].", ex);
            }
        }
    }
}
