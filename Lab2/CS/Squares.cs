using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    internal class Squares
    {
        private double[]? _coords = new double[4];
        public double[]? Coords
        {
            get => _coords;
            set 
            {
                if (_coords?.Length > 4) 
                {
                    _coords = value?[0..4];
                }
                else 
                {
                    _coords = value;
                }
            }
        }
        public Squares() 
        {
            
        }
        public Squares(double[] Data) 
        {
            Coords = Data;
        }

        public double square() 
        {
            double length = System.Math.Sqrt(System.Math.Pow(Coords[2] - Coords[0], 2) + System.Math.Pow(Coords[3] - Coords[1], 2));
            return (length * length);
        }
        public double perimeter() 
        {
            double length = System.Math.Sqrt(System.Math.Pow(Coords[2] - Coords[0], 2) + System.Math.Pow(Coords[3] - Coords[1], 2));
            return length*4;
        }

        ~Squares() 
        {
            Console.WriteLine("It's dead");
        }
    }
}
