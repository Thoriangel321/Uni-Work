using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    internal class Square
    {
        
        private List<double> points;

        public Square() 
        {
            points = new List<double>();
        }

        public void AddPoints(IEnumerable<double> morepoints) 
        {
            points.AddRange(morepoints);
        }

        public double square()
        {
            double length = System.Math.Sqrt(System.Math.Pow((points[2] - points[0]), 2) + System.Math.Pow((points[3] - points[1]), 2));
            return (length * length);
        }
        public double perimeter()
        {
            double length = System.Math.Sqrt(System.Math.Pow((points[2] - points[0]), 2) + System.Math.Pow((points[3] - points[1]), 2));
            return 4 * length;
        }
    }
}
