using HWcs;

namespace HWcs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] Data = 
            {
                { 1, 5, 3, 6, 2},
                { 5, 1, 6, 9, 0},
                { 4, 1, 7, 6, 8},
                { 2, 4, 5, 9, 9},
                { 3, 2, 2, 7, 9}
            };
            SuperCoolClass obj1 = new SuperCoolClass(Data);

            Console.Write("Enter a column: ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum of column: " + i + " is - " + obj1[3]);
            Console.WriteLine("The Something Value is - " + obj1.MegaValue);
        }
    }
}
