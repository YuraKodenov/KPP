using System;
using System.IO;

public class RailwayCostCalculator
{
    private int[] costs;
    private int N;

    public RailwayCostCalculator(int numberOfStations, int[] costsArray)
    {
        N = numberOfStations;
        costs = costsArray;
    }

    public int CalculateMinimumCost()
    {
        int[] minCost = new int[N + 1];
        for (int i = 1; i <= N; i++)
        {
            minCost[i] = int.MaxValue;
        }
        minCost[0] = 0;

        int costIndex = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j <= N; j++)
            {
                if (costIndex < costs.Length && minCost[i] != int.MaxValue)
                {
                    int newCost = minCost[i] + costs[costIndex];
                    minCost[j] = Math.Min(minCost[j], newCost);
                    Console.WriteLine($"Updated cost from station {i} to station {j}: {minCost[j]} (using cost {costs[costIndex]})");
                }
                costIndex++;
            }
        }

        Console.WriteLine("Minimum costs to each station: " + string.Join(", ", minCost));
        return minCost[N];
    }

    public static void Main()
    {
        string inputPath = @"C:\Users\yurka\OneDrive\Рабочий стол\KPP\Lab2\INPUT.TXT";
        string outputPath = @"C:\Users\yurka\OneDrive\Рабочий стол\KPP\Lab2\OUTPUT.TXT";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The input file 'INPUT.TXT' was not found at the specified path.");
            return;
        }

        // Read input from file
        string[] lines = File.ReadAllLines(inputPath);
        int N = int.Parse(lines[0]); // Number of stations
        string[] costStrings = lines[1].Split(' ');
        int[] costs = Array.ConvertAll(costStrings, int.Parse);

        // Ensure correct number of cost entries
        int expectedCostEntries = N * (N + 1) / 2;
        if (costs.Length != expectedCostEntries)
        {
            Console.WriteLine($"Error: Expected {expectedCostEntries} costs but found {costs.Length}.");
            return;
        }

        // Initialize calculator
        var calculator = new RailwayCostCalculator(N, costs);

        // Calculate minimum cost
        int minimumCost = calculator.CalculateMinimumCost();

        // Check if minimumCost was unreachable
        if (minimumCost == int.MaxValue)
        {
            Console.WriteLine("No path found from station 0 to station N.");
            File.WriteAllText(outputPath, "-1"); // Indicate no path found
        }
        else
        {
            // Write output to file
            File.WriteAllText(outputPath, minimumCost.ToString());
            Console.WriteLine("The minimum cost has been written to OUTPUT.TXT.");
        }
    }
}