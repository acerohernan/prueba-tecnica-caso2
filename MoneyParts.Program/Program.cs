namespace MoneyParts.Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new MoneyParts().Build("10.5");
            for (int i = 0; i < result.Length; i++) {
                Console.WriteLine($"Item {i}: {string.Join(", ", result[i])}");
            }
        }
    }
}
