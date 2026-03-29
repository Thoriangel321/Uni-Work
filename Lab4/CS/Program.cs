namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Segment seg = new Segment(1, 2, 6, 4);

            Console.WriteLine("Segments coordinates before extruding " + seg.x1d + " " + seg.y1d + " " + seg.x2d + " " + seg.y2d);
            Console.WriteLine("Segments length before extruding is - " + seg.Length(seg));
            seg.Extrude(seg);
            Console.WriteLine("Segments coordinates after extruding " + seg.x1d + " " + seg.y1d + " " + seg.x2d + " " + seg.y2d);
            Console.WriteLine("Segments length after extruding is - " + seg.Length(seg));
        }
    }
}
