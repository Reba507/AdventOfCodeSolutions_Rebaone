using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Load the input from the file
        string filePath = "input.txt";
        string input = File.ReadAllText(filePath);

        // Regex pattern to match only valid mul(X,Y) instructions
        // Explanation:
        // - Starts with "mul("
        // - Then 1 to 3 digits
        // - A comma
        // - Then 1 to 3 digits
        // - Ends with ")"
        // - No whitespace, symbols, or invalid characters allowed
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        int total = 0;

        // Match all valid mul instructions
        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            // Extract the two numbers from the match groups
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            // Calculate the product and add to the total
            int product = x * y;
            total += product;
        }

        // Output the final result
        Console.WriteLine("Sum of all valid multiplications: " + total);
    }
}
