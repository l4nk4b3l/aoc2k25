Part1();
Part2();

void Part1()
{
    var left = new List<int>();
    var right = new List<int>();

    foreach (string line in File.ReadLines("./input.txt"))
    {
        string[] splitted = line.Split("   ");
    
        left.Add(int.Parse(splitted[0]));
        right.Add(int.Parse(splitted[1]));
    }

    left.Sort();
    right.Sort();
    
    int sum = 0;
    for (int i = 0; i < left.Count; i++) 
        sum += Math.Abs(left.ElementAt(i) - right.ElementAt(i));
    
    Console.WriteLine($"Part 1: {sum}");
}

void Part2()
{
    var left = new List<int>();
    var right = new List<int>();

    foreach (string line in File.ReadLines("./input.txt"))
    {
        string[] splitted = line.Split("   ");
    
        left.Add(int.Parse(splitted[0]));
        right.Add(int.Parse(splitted[1]));
    }

    var lookup = right.ToLookup(x => x);
    
    int sum = left.Sum(d=> d * lookup[d].Count());

    Console.WriteLine($"Part 2: {sum}");
}