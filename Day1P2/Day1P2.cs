using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class HistorianSimilarity
{
    static void Main()
    {
        string filePath = "input1.txt";

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        // Read the file and fill both lists using a foreach loop
        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) continue;

            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }

        // Create a dictionary to count occurrences or similarities in the right list
        var rightCountMap = new Dictionary<int, int>();
        foreach (int number in rightList)
        {
            if (rightCountMap.ContainsKey(number))
                rightCountMap[number]++;
            else
                rightCountMap[number] = 1;
        }

        // Calculate the similarity score
        int similarityScore = 0;
        foreach (int number in leftList)
        {
            if (rightCountMap.TryGetValue(number, out int count))
            {
                similarityScore += number * count;
            }
        }

        Console.WriteLine("Similarity score between lists = " + similarityScore);
    }
}
