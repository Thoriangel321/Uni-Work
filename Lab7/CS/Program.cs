namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpressionEvaluator[] evaluators = new ExpressionEvaluator[]
            {
                new ExpressionEvaluator(2, 4, 1, 1),   // Normal
                new ExpressionEvaluator(5, 0, 3, 12),  // Error (b = 0)
                new ExpressionEvaluator(1, 2, 5, -30), // Error (negative sqrt)
                new ExpressionEvaluator(1, 1, 6, 1)    // Error (denominator = 0)
            };

            for (int i = 0; i < evaluators.Length; i++)
            {
                Console.WriteLine($"Parameters: {evaluators[i]}");

                try
                {
                    double result = evaluators[i].Calculate();
                    Console.WriteLine($"Result: {result}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, if Present: {ex.Message}\n");
                }
            }

            Console.ReadLine();
        }
    }
}
