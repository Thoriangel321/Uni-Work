using System;

namespace Domain.UI
{
    public static class InputHelper
    {
        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Error! Input cannot be empty.");
            }
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;

                Console.WriteLine($"Error! Enter an integer between {min} and {max}.");
            }
        }

        public static decimal ReadDecimal(string prompt, decimal min)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result) && result >= min)
                    return result;

                Console.WriteLine($"Error! Enter a number greater than or equal to {min}.");
            }
        }
    }
}