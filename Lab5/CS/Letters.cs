using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab5
{
    internal class Letters : Lines
    {
        private string mainStr;
        public string str;

        public Letters() 
        {
            
        }

        public Letters(string ret_string) 
        {
            str = ret_string;
            mainStr = str;
        }

        public override int Length()
        {
            return str.Length;
        }

        public override string Process()
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
