using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class HistorianPuzzle
{
    static void Main()
    {
        string filePath = "input1.txt";

        // Read and parse lines using LINQ
        var pairs = File.ReadLines(filePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        .Where(parts => parts.Length == 2)
                        .Select(parts => (Left: int.Parse(parts[0]), Right: int.Parse(parts[1])))
                        .ToList();

// Extract and sort left/right lists using LINQ
        var leftList = pairs.Select(p => p.Left).OrderBy(x => x).ToList();
        var rightList = pairs.Select(p => p.Right).OrderBy(x => x).ToList();

        // Use LINQ to zip, compute differences, and sum
        int totalDistance = leftList.Zip(rightList, (l, r) => Math.Abs(l - r)).Sum();

        Console.WriteLine("Distance between lists = " + totalDistance);
    }
}