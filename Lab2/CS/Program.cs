using Lab2;
using System.Threading.Channels;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] points;
            points = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
            Squares square = new Squares(points);

            Console.WriteLine("square - " + square.square() + " perimeter - " + square.perimeter());
        }
    }
}
