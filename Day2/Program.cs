using Day2;

Part1();
Part2();

void Part1()
{
    int safeLevelCount = 0;
    
    foreach (var report in File.ReadLines("./input.txt"))
    {
        var levels = report
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int lastLevel = 0;
        bool isDecreasing = false;
        bool isIncreasing = false;
        bool safe = true;
        
        for (int i = 0; i < levels.Length; i++)
        {
            int currentLevel = levels[i];
            
            try
            {
                if (i == 0)
                    continue;

                // Unsafe
                if (lastLevel == currentLevel)
                {
                    safe = false;
                    break;
                }

                if (lastLevel > currentLevel)
                {
                    // Unsafe
                    if (isIncreasing)
                    {
                        safe = false;
                        break;
                    }

                    isDecreasing = true;

                    // Unsafe
                    if (lastLevel - currentLevel > 3)
                    {
                        safe = false;
                        break;
                    }
                }
                else
                {
                    // Unsafe
                    if (isDecreasing)
                    {
                        safe = false;
                        break;
                    }

                    isIncreasing = true;

                    // Unsafe
                    if (currentLevel - lastLevel > 3)
                    {
                        safe = false;
                        break;
                    }
                }

            }
            finally
            {
                lastLevel = currentLevel;
            }
        }

        if (safe)
        {
            safeLevelCount++;
        }
    }
    
    Console.WriteLine($"Part 1: {safeLevelCount}");
}

void Part2()
{
    List<Report> reports = new List<Report>();
    
    foreach (var reportValue in File.ReadLines("./input.txt"))
    {
        var levelValues = reportValue
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var report = new Report();
        
        foreach (int levelValue in levelValues)
        {
            Level level = new Level(levelValue);
            report.Levels.Add(level);
        }
        
        reports.Add(report);
    }
    
    Console.WriteLine($"Part 2: {reports.Count(d => d.IsSafe())}");
}

