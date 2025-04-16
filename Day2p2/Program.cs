using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ReactorSafetyWithDampener
{
    static void Main()
    {
        string filePath = "input1.txt"; 
        int safeReportCount = 0;

        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var levels = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse).ToList();

            if (IsSafeReport(levels) || CanBeSafeWithOneRemoval(levels))
            {
                safeReportCount++;
            }
        }

        Console.WriteLine("Number of safe reports (with Problem Dampener): " + safeReportCount);
    }

    // Check original safety rules
    static bool IsSafeReport(List<int> levels)
    {
        if (levels.Count < 2)
            return false;

        bool isIncreasing = levels[1] > levels[0];
        bool isDecreasing = levels[1] < levels[0];

        if (!isIncreasing && !isDecreasing)
            return false;

        for (int i = 1; i < levels.Count; i++)
        {
            int diff = levels[i] - levels[i - 1];
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            if (isIncreasing && diff <= 0)
                return false;

            if (isDecreasing && diff >= 0)
                return false;
        }

        return true;
    }

    // Check if removing one element can make it safe
    static bool CanBeSafeWithOneRemoval(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
   // Removes the i-th item
            var modified = levels.Where((_, idx) => idx != i).ToList();
            if (IsSafeReport(modified))
                return true;
        }
        return false;
    }
}
