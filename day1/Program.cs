
var day1 = CountZeros(false);
Console.WriteLine($"Day1: {day1}");

var day2 = CountZeros(true);
Console.WriteLine($"Day2: {day2}");

int CountZeros(bool countAll)
{
    using var file = File.Open("./input.txt", FileMode.Open);
    using var reader = new StreamReader(file);
    
    int position = 50;
    int i = 0;
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine()!;
        char direction = line[0];
        int number = int.Parse(line[1..]);

        for (int j = 0; j < number; j++)
        {
            switch (direction)
            {
                case 'L':
                    position -= 1;
                    break;
                default:
                    position += 1;
                    break;
            }

            if (position < 0) 
                position = 99;

            if (position > 99) 
                position = 0;
            
            if (countAll && position == 0)
                i++;
        }
        
        if (!countAll)
        {
            if (position == 0)
                i++;
        }
    }

    return i;
}