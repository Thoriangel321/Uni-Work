namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lettersStr = "abcdefg";
            string digitsStr = "2026";

            Letters letters = new Letters(lettersStr);
            Digits digits = new Digits(digitsStr);

            Console.WriteLine("the length of letters string is - " + letters.Length() + " and the processed string is - " + letters.Process());
            Console.WriteLine("the length of digits string is - " + digits.Length() + " and the processed string is - " + digits.Process());
        }
    }
}
