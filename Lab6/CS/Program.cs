namespace Lab6CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();

            Line line1 = new Line("First Beautiful Line");
            Line line2 = new Line("Some Random text to fill the screen");
            Line line3 = new Line("Suspicious 4th line");
            Line line4 = new Line("Real 4th line, bwahahahhahah");
            Line line5 = new Line("Who are you, the one, who's reading this ?");

            container.AddLine(line1);
            container.AddLine(line2);
            container.AddLine(line3);
            container.AddLine(line4);
            container.AddLine(line5);

            Console.WriteLine("Start Text: ");
            container.Print();

            char charToCount = 'l';
            double freq = container.GetCharFrequency(charToCount);
            Console.WriteLine("Counting time: ");
            Console.WriteLine("How many l's: " + freq);

            Console.WriteLine("Replace Demo: ");
            container.ReplaceString("4th", "5th");
            container.Print();

            Console.WriteLine("Duplicate deleting demo: ");
            container.FindDuplicate();
            container.Print();

            Console.WriteLine("Line Remove Demo: ");
            container.RemoveLine(line1);
            container.Print();

            Console.WriteLine("Clear Demo: ");
            container.Clear();
        }
    }
}
