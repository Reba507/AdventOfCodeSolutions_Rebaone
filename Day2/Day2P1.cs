using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Rules:

//1.The entire sequence must be strictly increasing or strictly decreasing.


//2. Each step (difference between adjacent numbers) must be between 1 and 3.

class ReactorSafety
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

            if (IsSafeReport(levels))
            {
                safeReportCount++;
            }
        }

        Console.WriteLine("Number of safe reports: " + safeReportCount);
    }

    // Check if a report is safe
    static bool IsSafeReport(List<int> levels)
    {
        if (levels.Count < 2)
            return false; // Not enough data to judge

        bool isIncreasing = levels[1] > levels[0];
        bool isDecreasing = levels[1] < levels[0];

        if (!isIncreasing && !isDecreasing)
            return false; // If first two elements are equal, it's invalid

        for (int i = 1; i < levels.Count; i++)
        {

//Calculates the difference from the previous number
            int diff = levels[i] - levels[i - 1];

            // Rule: adjacent difference must be between 1 and 3, if the trend breaks, it's not a valid sequence.

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            // Rule: all must be strictly increasing or decreasing
            if (isIncreasing && diff <= 0)
                return false;
            if (isDecreasing && diff >= 0)
                return false;
        }

        return true;
    }
}



