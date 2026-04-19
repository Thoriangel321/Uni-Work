using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    internal class Digits : Lines
    {
        private string mainDigits;
        public string digits;

        public Digits() 
        {
        }
        public Digits(string retdigits) 
        {
            digits = retdigits;
            mainDigits = digits;
        }

        public override int Length() 
        {
            return digits.Length;
        }
        public override string Process()
        {
            string ret = digits;
            return ret + digits;
        }
    }
}
