using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Solution
{
    public string solution(int[] A)
    {
        if (A == null || A.Length == 0)
            return string.Empty;  // Handle null or empty array

        StringBuilder result = new StringBuilder(A.Length);

        foreach (int num in A)
        {
            if (num < 0)
                result.Append('<');
            else if (num > 0)
                result.Append('>');
            else
                result.Append('=');
        }

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prompt user for the file path
            Console.Write("Enter the path of the file containing the integers: ");
            string filePath = Console.ReadLine();

            // Read all lines from the file
            List<int> numbers = new List<int>();
            foreach (string line in File.ReadLines(filePath))
            {
                // Attempt to parse each line as an integer
                if (int.TryParse(line, out int value))
                {
                    numbers.Add(value);
                }
                else
                {
                    Console.WriteLine($"Warning: Could not parse '{line}' as an integer. Skipping.");
                }
            }

            // Convert the list to an array
            int[] A = numbers.ToArray();

            // Create a Solution object and get the result string
            Solution sol = new Solution();
            string resultString = sol.solution(A);

            // Print the resulting string
            Console.WriteLine("Result:");
            Console.WriteLine(resultString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The specified file was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
