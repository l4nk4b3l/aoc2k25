var part1 = SolvePart1();
Console.WriteLine(part1);

var part2 = SolvePart2();
Console.WriteLine(part2);

long SolvePart1()
{
    string input = File.ReadAllText(@".\input.txt");
    IEnumerable<Range> ranges = input.Split(',').Select(d => new Range(d));

    return ranges.Sum(d=> d.GetInvalidIds().Sum());
}

long SolvePart2()
{
    string input = File.ReadAllText(@".\input.txt");
    IEnumerable<Range> ranges = input.Split(',').Select(d => new Range(d));

    return ranges.Sum(d=> d.GetInvalidIdsWithSequenceOfAtLeastTwice().Sum());
}

public class Range
{
    public long Start { get; }
    public long End { get; }

    public Range(string range)
    {
        var parts = range.Split('-');
        
        Start = long.Parse(parts[0]);
        End = long.Parse(parts[1]);
    }

    public List<long> GetInvalidIds()
    {
        List<long> invalidIds = new List<long>();
        
        for (long i = Start; i <= End; i++)
        {
            string s = i.ToString();
            
            if (s.Length % 2 != 0)
                continue;
            
            int mid = s.Length / 2;
            
            string left = s.Substring(0, mid);
            string right = s.Substring(mid, mid);
            
            if (left != right)
                continue;
            
            invalidIds.Add(long.Parse($"{left}{right}"));
        }

        return invalidIds;
    }
    
    public HashSet<long> GetInvalidIdsWithSequenceOfAtLeastTwice()
    {
        HashSet<long> invalidIds = new HashSet<long>();
        
        for (long i = Start; i <= End; i++)
        {
            string s = i.ToString();

            for (int j = 1; j <= s.Length / 2; j++)
            {
                var sequence = s.Substring(0, j);

                var str = sequence;

                while (str.Length < s.Length)
                {
                    str += sequence;
                }
                
                if (s == str)
                    invalidIds.Add(long.Parse($"{str}"));
            }
        }

        return invalidIds;
    }
}