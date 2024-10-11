using System;
using Xunit;

public class RailwayCostCalculatorTests
{
    [Fact]
    public void Test_SimplePath()
    {
        int N = 3;
        int[] costs = { 37, 10, 20, 4, 8, 2 }; // Expected result is 12 (0 -> 2 -> 3)
        var calculator = new RailwayCostCalculator(N, costs);
        int result = calculator.CalculateMinimumCost();
        Assert.Equal(12, result);
    }

    [Fact]
    public void Test_UnreachablePath()
    {
        int N = 2;
        int[] costs = { int.MaxValue, int.MaxValue, int.MaxValue }; // All paths are blocked
        var calculator = new RailwayCostCalculator(N, costs);
        int result = calculator.CalculateMinimumCost();
        Assert.Equal(int.MaxValue, result); // Represents no path found
    }

    [Fact]
    public void Test_DirectRoute()
    {
        int N = 1;
        int[] costs = { 5 }; // Direct path from station 0 to 1
        var calculator = new RailwayCostCalculator(N, costs);
        int result = calculator.CalculateMinimumCost();
        Assert.Equal(5, result); // Direct cost
    }

    [Fact]
    public void Test_MultiplePathsWithDifferentCosts()
    {
        int N = 4;
        int[] costs = { 1, 5, 9, 3, 7, 4, 8, 6, 2, 10 }; // Multiple routes with different costs
        var calculator = new RailwayCostCalculator(N, costs);
        int result = calculator.CalculateMinimumCost();
        Assert.Equal(7, result); // Expected result from choosing optimal path
    }

    [Fact]
    public void Test_LargeInput()
    {
        int N = 5;
        int[] costs = { 3, 5, 6, 2, 7, 4, 8, 1, 5, 6, 3, 7, 2, 4, 5 }; // Check with more stations
        var calculator = new RailwayCostCalculator(N, costs);
        int result = calculator.CalculateMinimumCost();
        Assert.Equal(10, result); // Expected minimum cost based on optimal route
    }
}