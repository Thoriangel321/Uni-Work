using Lab1;
using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //----------------------
            Square square1 = new Square();
            List<double> points = new List<double> {2, 6, 8, 6, 2, 1, 8, 1};
            square1.AddPoints(points);
            //----------------------

            System.Console.WriteLine("square's coordinates are: ");
            for (int i = 0; i <= 7; i++) 
            {
                Console.Write(points[i] + " ");
                if(i % 2 == 1) 
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("square is - " + square1.square() + " perimeter is - " + square1.perimeter());
        }
    }
}
