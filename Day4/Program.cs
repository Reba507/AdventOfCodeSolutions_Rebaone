using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Read the input file into a grid (2D char array)
        string[] lines = File.ReadAllLines("input.txt");
        char[,] grid = new char[lines.Length, lines[0].Length];

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                grid[i, j] = lines[i][j];
            }
        }

        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int count = 0;

        // Define the word to search for
        string word = "XMAS";
        int wordLength = word.Length;

        // Directions: horizontal, vertical, diagonal (8 directions)
        int[] dx = { 1, 0, -1, 0, 1, -1, 1, -1 };
        int[] dy = { 0, 1, 0, -1, 1, 1, -1, -1 };

        // Iterate over every cell in the grid
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Check all 8 possible directions
                for (int dir = 0; dir < 8; dir++)
                {
                    bool match = true;
                    for (int k = 0; k < wordLength; k++)
                    {
                        int ni = i + k * dx[dir];
                        int nj = j + k * dy[dir];

                        // Check if the next position is out of bounds
                        if (ni < 0 || ni >= rows || nj < 0 || nj >= cols)
                        {
                            match = false;
                            break;
                        }

                        // Check if the character matches the word
                        if (grid[ni, nj] != word[k])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine($"Total occurrences of 'XMAS': {count}");
    }
}