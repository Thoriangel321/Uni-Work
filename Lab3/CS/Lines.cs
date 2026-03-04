using System;
using System.Collections.Generic;
using System.Text;

namespace LinesClass
{
    internal class Lines
    {
        private double x1, y1, x2, y2;
        public double x1d, y1d, x2d, y2d;
        public Lines() 
        { 
        }
        public Lines(double x1, double y1, double x2, double y2)
        {
            this.x1d = x1;
            this.x1 = this.x1d;
            this.y1d = y1;
            this.y1 = this.y1d;
            this.x2d = x2;
            this.x2 = this.x2d;
            this.y2d = y2;
            this.y2 = this.y2d;
        }
        public Lines(Lines line) 
        {
            this.x1d = line.x1;
            this.x1 = this.x1d;
            this.y1d = line.y1;
            this.y1 = this.y1d;
            this.x2d = line.x2;
            this.x2 = this.x2d;
            this.y2d = line.y2;
            this.y2 = this.y2d;
        }

        ~Lines() 
        {
        }

        public double Length(Lines line1) 
        {
            return (Math.Sqrt(Math.Pow(line1.x2 - line1.x1, 2) + Math.Pow(line1.y2 - line1.y1, 2)));
        }
        public void MoveXL(double x1, double x2) 
        { 
            this.x1d -= x1;
            this.x1 = this.x1d;
            this.x2d -= x2;
            this.x2 = this.x2d;
        }
        public void Addition() 
        {
            Console.WriteLine("Dummy Addition for overloading");
        }
        public void Addition(Lines line, Lines line2)
        {
            x1d = line.x1 + line2.x1;
            x1 = x1d;
            y1d = line.y1 + line2.y1;
            y1 = y1d;
            x2d = line.x2 + line2.x2;
            x2 = x2d;
            y2d = line.y2 + line2.y2;
            y2 = y2d;
        }
        public void Subtraction() 
        {
            Console.WriteLine("Dummy Subtraction for overloading");
        }
        public void Subtraction(Lines line, Lines line2)
        {
            x1d = line.x1 - line2.x2;
            x1 = x1d;
            y1d = line.y1 - line2.y2;
            y1 = y1d;
            x2d = line.x2 - line2.x2;
            x2 = x2d;
            y2d = line.y2 - line2.y2;
            y2 = y2d;
        }
    }
}
