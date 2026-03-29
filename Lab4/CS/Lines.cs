using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Lines
    {
        protected double x1, y1, x2, y2;
        public double x1d, y1d, x2d, y2d;

        public Lines() 
        {
            
        }
        public Lines(double X1, double Y1, double X2, double Y2)
        {
            x1d = X1;
            this.x1 = x1d;
            y1d = Y1;
            this.y1 = y1d;
            x2d = X2;
            this.x2 = x2d;
            y2d = Y2;
            this.y1 = y2d;
        }

        public Lines(Lines line) 
        {
            x1d = line.x1;
            this.x1 = x1d;
            y1d = line.y1;
            this.y1 = y1d;
            x2d = line.x2;
            this.x2 = x2d;
            y2d = line.y2;
            this.y2 = y2d;
        }

        public double Length(Lines line) 
        {
            return (Math.Sqrt(Math.Pow(line.x2 - line.x1, 2) + Math.Pow(line.y2 - line.y1, 2)));
        }
    }
}
