using System.Text;
using System.Text.RegularExpressions;

namespace Day3;

class Program
{
    static void Main(string[] args)
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        string input = File.ReadAllText("./input.txt");
        MatchCollection matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");
        int sum = matches.Select(d => int.Parse(d.Groups[1].Value) * int.Parse(d.Groups[2].Value)).Sum();
        Console.WriteLine(sum);
    }

    static void Part2()
    { 
        string input = File.ReadAllText("./input.txt");
        string[] parts = input.Split("do()");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string part in parts) 
            stringBuilder.Append(part.Split("don't()")[0]);
        
        MatchCollection matches = Regex.Matches(stringBuilder.ToString(), @"mul\((\d+),(\d+)\)");
        int sum = matches.Select(d => int.Parse(d.Groups[1].Value) * int.Parse(d.Groups[2].Value)).Sum();
        Console.WriteLine(sum);
    }
}