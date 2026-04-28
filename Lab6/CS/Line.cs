using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lab6CS
{
    internal class Line
    {
        public string str = "";

        public Line() 
        {
            
        }

        public Line(string coolString) 
        {
            str = coolString;
        }

        public int FindRate(char c)
        {
            int a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c) a++;
            }
            return a;
        }
        public int GetLength() 
        {
            return str.Length;
        }
        public void Replace(string oldStr, string newStr) 
        {
            str.Replace(oldStr, newStr);
        }
        public bool isEqualTo(Line other) 
        {
            return this.str == other.str;
        }

        public override string ToString()
        {
            return str;
        }
    }
}
