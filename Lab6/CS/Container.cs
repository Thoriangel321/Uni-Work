using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6CS
{
    internal class Container : IDuplicate
    {
        private List<Line> lines;

        public Container() 
        {
            lines = new List<Line>();
        }

        public void AddLine(Line line) 
        {
            lines.Add(line);
        }
        public void RemoveLine(Line line) 
        {
            lines.Remove(line);
        }

        public void Clear() 
        {
            lines.Clear();
        }

        public double GetCharFrequency(char c) 
        {
            int totalChars = 0;
            int targetChars = 0;

            foreach (Line line in lines) 
            {
                totalChars += line.GetLength();
                targetChars += line.FindRate(c);
            }

            return totalChars / targetChars;
        }

        public void ReplaceString(string Old, string New) 
        {
            foreach(Line line in lines) 
            {
                line.Replace(Old, New);
            }
        }
        public void Print() 
        {
            foreach (Line line in lines) 
            {
                Console.WriteLine(line.ToString());
            }
        }

        public void FindDuplicate()
        {
            List<Line> uniqueLines = new List<Line> ();

            foreach (Line currentLine in lines) 
            {
                bool isDup = false;
                foreach (Line unique in uniqueLines) 
                {
                    if (currentLine.isEqualTo(unique)) 
                    {
                        isDup = true; break;
                    }
                }

                if (!isDup) 
                {
                    uniqueLines.Add(currentLine);
                }
            }

            lines = uniqueLines;
        }



    }
}
