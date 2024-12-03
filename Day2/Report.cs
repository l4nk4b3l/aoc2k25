namespace Day2;

public class Report
{
    public List<Level> Levels { get; } = new List<Level>();
    
    public bool IsSafe(bool applyDamper = true)
    {
        List<Level> levels = new List<Level>(Levels);
        List<int> deltas = new List<int>();
        
        Level previousLevel = null;
        
        foreach (var level in levels)
        {
            deltas.Add((previousLevel?.Value ?? level.Value) - level.Value);
            previousLevel = level;
        }

        if (deltas.Count(d=> d == 0) <= 1)
        {
            if (deltas.All(d => d is >= 0 and <= 3))
                return true;

            if (deltas.All(d => d is <= 0 and >= -3))
                return true;
        }

        if (applyDamper)
        {
            // Report not safe!
            // Apply Damper!
            for (int i = 0; i < Levels.Count; i++)
            {
                var report = new Report();

                // Add all Levels except current one
                Levels
                    .Where((d, idx) => idx != i)
                    .ToList()
                    .ForEach(l => report.Levels.Add(l));

                if (report.IsSafe(applyDamper: false))
                    return true;
            }
            
            Console.WriteLine("Still Unsafe");
        }

        return false;
    }
}