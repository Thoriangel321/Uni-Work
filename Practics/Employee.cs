using System;
using System.Collections.Generic;
using System.Text;

namespace Practics
{
    internal class Employee
    {
        public Department Dept { get; set; }
        public double Salary { get; set; }
        public bool IsRemote { get; set; }

        public override string ToString() =>
            $"{Dept,-10} | {Salary,-10:C} | {(IsRemote ? "Yes" : "No"),-10}";
    }
}
