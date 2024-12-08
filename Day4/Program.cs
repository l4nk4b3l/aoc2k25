namespace Day4;

class Program
{
    static void Main(string[] args)
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        string[] input = File.ReadAllLines("./input.txt");
        
        // create matrix from input
        char[][] matrix = new char[input.Length][];

        for (int i = 0; i < input.Length; i++) 
            matrix[i] = input[i].ToCharArray();

        int count = 0; 
        
        for (int y = 0; y < matrix.Length; y++)
        {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                var c = matrix[y][x];
                
                if (c == 'X')
                {
                    // Look for M
                    string[] words =
                    [
                        GetWord(matrix, x, y, +1, 0),
                        GetWord(matrix, x, y, -1, 0),
                        GetWord(matrix, x, y, 0, -1),
                        GetWord(matrix, x, y, 0, +1),
                        GetWord(matrix, x, y, -1, -1),
                        GetWord(matrix, x, y, +1, -1),
                        GetWord(matrix, x, y, -1, +1),
                        GetWord(matrix, x, y, +1, +1)
                    ];
                    
                    foreach (var word in words)
                    {
                        if (word == "XMAS")
                            count++;
                    }
                }
            }
        }
        
        Console.WriteLine(count);
    }
    
    static void Part2()
    {
        string[] input = File.ReadAllLines("./input.txt");
        
        // create matrix from input
        char[][] matrix = new char[input.Length][];

        for (int i = 0; i < input.Length; i++) 
            matrix[i] = input[i].ToCharArray();

        int count = 0; 
        
        for (int y = 0; y < matrix.Length; y++)
        {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                var c = matrix[y][x];
                
                if (c == 'A')
                {
                    // Get 3x3  block
                    var bottomright = GetWord(matrix, x-1, y - 1, +1, +1, 3);
                    var buttomleft = GetWord(matrix, x+1, y - 1, -1, +1, 3);
                    
                    if (bottomright == "SAM")
                        bottomright = "MAS";
                    
                    if (buttomleft == "SAM")
                        buttomleft = "MAS";

                    if (bottomright == "MAS" && buttomleft == "MAS")
                        count++;
                }
            }
        }
        
        Console.WriteLine(count);
    }

    private static char GetChar(char[][] matrix, int xPos, int yPos)
    {
        if (yPos < 0 || yPos >= matrix.Length)
            return '.';
        
        if (xPos < 0 || xPos >= matrix[yPos].Length)
            return '.';
        
        return matrix[yPos][xPos];
    }

    public static string GetWord(char[][] matrix, int x, int y, int xModifier, int yModifier, int length = 4)
    {
        string word = String.Empty;

        for (int i = 0; i < length; i++)
            word += GetChar(matrix, x + (xModifier * i), y + (yModifier * i));

        return word;
    }
}