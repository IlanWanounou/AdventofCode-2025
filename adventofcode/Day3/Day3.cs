string[] lines = File.ReadAllLines("Day3/input.txt");

void Day3(int limit)
{
    long total = 0;
    foreach (string line in lines)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < line.Length; i++)
        {
            int nb = line[i] - '0';

            while (0 < result.Count && result.Last() < nb && result.Count + (line.Length - i) > limit)
            {
                result.RemoveAt(result.Count - 1);
            }

            if (result.Count < limit)
            {
                result.Add(nb);
            }
        }
        total += long.Parse(string.Concat(result));
    }
    Console.WriteLine(total);
}
Day3(2);
Day3(12);
