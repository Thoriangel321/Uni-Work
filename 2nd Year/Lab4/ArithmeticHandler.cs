using Lab4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class ArithmeticHandler
    {
        public void HandleOverflow(object sender, OverflowEventArgs e)
        {
            Console.WriteLine($"error: overflow occurred. Op: {e.OperationName}. Args: {e.Value1} & {e.Value2}.");
        }
    }
}
