using Lab4;

namespace Lab4
{
    internal class Program
    {
        delegate int MatrixSumDelegate(int[,] matrix);

        static void Main(string[] args)
        {
            int[,] matrix = {
                { 10, 20, 30 },
                { 40, 50, 60 }
            };

            MatrixSumDelegate sumAnonymous = delegate (int[,] arr)
            {
                int sum = 0;
                foreach (int item in arr)
                {
                    sum += item;
                }
                return sum;
            };

            MatrixSumDelegate sumLambda = arr =>
            {
                int sum = 0;
                foreach (int item in arr)
                {
                    sum += item;
                }
                return sum;
            };

            Console.WriteLine("--- 1: delegates, anonymous methods and lambda express ---");
            Console.WriteLine($"sum (anonymous method): {sumAnonymous(matrix)}");
            Console.WriteLine($"sum (lambda): {sumLambda(matrix)}");
            Console.WriteLine();

            Console.WriteLine("--- 2: events and handlers ---");
            IntegerArithmetic arithmetic = new IntegerArithmetic();
            ArithmeticHandler handler = new ArithmeticHandler();

            arithmetic.OverflowOccurred += handler.HandleOverflow;

            Console.WriteLine($"15 + 25 = {arithmetic.Add(15, 25)}");
            Console.WriteLine($"int.MaxValue + 1 = {arithmetic.Add(int.MaxValue, 1)}");

            Console.WriteLine($"100 * 50 = {arithmetic.Multiply(100, 50)}");
            Console.WriteLine($"int.MaxValue * 2 = {arithmetic.Multiply(int.MaxValue, 2)}");
        }
    }
}
