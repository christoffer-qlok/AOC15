namespace AOC15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            var entries = input.Split(',');
            
            Console.WriteLine(entries.Select(MakeHash).Sum());
        }

        static int MakeHash(string input)
        {
            int hash = 0;
            foreach(char c in input)
            {
                hash += (int)c;
                hash *= 17;
                hash = hash % 256;
            }
            return hash;
        }
    }
}
