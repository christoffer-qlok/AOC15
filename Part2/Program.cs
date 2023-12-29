namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            var entries = input.Split(',');
            var boxes = new List<Lens>[256];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new List<Lens>();
            }

            var exists = new HashSet<string>();

            foreach ( var entry in entries )
            {
                if(entry.Contains('='))
                {
                    var parts = entry.Split('=');
                    string label = parts[0];
                    int box = MakeHash(label);
                    int focal = int.Parse(parts[1]);
                    if(exists.Contains(label))
                    {
                        foreach (var lens in boxes[box])
                        {
                            if(lens.Label == label)
                            {
                                lens.FocalLength = focal;
                                break;
                            }
                        }
                    } else // new label
                    {
                        exists.Add(label);
                        boxes[box].Add(new Lens() { Label = label, FocalLength = focal });
                    }
                } else // '-'
                {
                    string label = entry.TrimEnd('-');
                    if(exists.Contains(label))
                    {
                        int box = MakeHash(label);
                        for (int i = 0;i < boxes[box].Count();i++)
                        {
                            if (boxes[box][i].Label == label)
                            {
                                boxes[box].RemoveAt(i);
                                break;
                            }
                        }
                        exists.Remove(label);
                    }
                }
            }

            long sum = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = 0; j < boxes[i].Count(); j++)
                {
                    sum += (i + 1) * (j + 1) * boxes[i][j].FocalLength;
                }
            }
            Console.WriteLine(sum);
        }


        static int MakeHash(string input)
        {
            int hash = 0;
            foreach (char c in input)
            {
                hash += (int)c;
                hash *= 17;
                hash = hash % 256;
            }
            return hash;
        }
    }
}
