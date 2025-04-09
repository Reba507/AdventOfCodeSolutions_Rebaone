using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class HistorianPuzzle
{
    static void Main()
    {
        // File path to the input file
        string filePath = "input1.txt";

        // Lists to hold the left and right column values
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        // Read each line from the input file
        foreach (var line in File.ReadLines(filePath))
        {
            // Skip the empty lines

            if (string.IsNullOrWhiteSpace(line)) continue; 
            // Split line into two parts by whitespace
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) continue; 

            // Parse values and add to the created lists
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }

        // Sorting both lists in increasing order
        leftList.Sort();
        rightList.Sort();

        // Calculate the total distance between paired elements
        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        // Output the result
        Console.WriteLine(" Distance between lists =  " + totalDistance);
    }
}
