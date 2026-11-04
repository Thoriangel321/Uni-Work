using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
        public class OverflowEventArgs : System.EventArgs
        {
            public string OperationName { get; }
            public int Value1 { get; }
            public int Value2 { get; }

            public OverflowEventArgs(string operationName, int value1, int value2)
            {
                OperationName = operationName;
                Value1 = value1;
                Value2 = value2;
            }
        }
}
