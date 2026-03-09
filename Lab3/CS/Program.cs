using LinesClass;

namespace Lab3CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lines W1 = new Lines();
            Lines W2 = new Lines(1, 2, 6, 4);
            Lines W3 = new Lines(W2);

            Console.WriteLine("Line 3 Coordinates before moving: " + W3.x1d + " " + W3.y1d + " " + W3.x2d + " " + W3.y2d);

            W3.MoveXL(3, 3);
            Console.WriteLine("Line 3 Coordinates after moving: " + W3.x1d + " " + W3.y1d + " " + W3.x2d + " " + W3.y2d);

            W1 = W2 + W3;       
            Console.WriteLine("Line 1 Coordinates after adding Line 2 and Line 3: " + W1.x1d + " " + W1.y1d + " " + W1.x2d + " " + W1.y2d);

        }
    }
}
