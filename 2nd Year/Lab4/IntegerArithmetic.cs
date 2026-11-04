using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class IntegerArithmetic
    {
        public event EventHandler<OverflowEventArgs> OverflowOccurred;

        protected virtual void OnOverflowOccurred(string operation, int v1, int v2)
        {
            OverflowOccurred?.Invoke(this, new OverflowEventArgs(operation, v1, v2));
        }

        public int Add(int a, int b)
        {
            try
            {
                return checked(a + b);
            }
            catch (OverflowException)
            {
                OnOverflowOccurred("addition", a, b);
                return 0;
            }
        }

        public int Subtract(int a, int b)
        {
            try
            {
                return checked(a - b);
            }
            catch (OverflowException)
            {
                OnOverflowOccurred("subtraction", a, b);
                return 0;
            }
        }

        public int Multiply(int a, int b)
        {
            try
            {
                return checked(a * b);
            }
            catch (OverflowException)
            {
                OnOverflowOccurred("multiplying", a, b);
                return 0;
            }
        }
    }
}
