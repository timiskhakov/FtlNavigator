using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FtlNavigator;

[MemoryDiagnoser]
public class Program
{
    public static IEnumerable<Dictionary<int, HashSet<int>>> Inputs() => new[]
    {
        new Dictionary<int, HashSet<int>>
        {
            [0] = new() { 6 },
            [1] = new() { 7, 2 },
            [2] = new() { 1, 7, 8, 9, 3 },
            [3] = new() { 2, 9, 4, 10 },
            [4] = new() { 3, 10, 5 },
            [5] = new() { 4, 10, 11 },
            [6] = new() { 0, 7, 12, 13 },
            [7] = new() { 1, 2, 8, 12, 6 },
            [8] = new() { 1, 2, 7, 9, 13, 14 },
            [9] = new() { 8, 2, 3, 10, 14, 15, 16 },
            [10] = new() { 3, 4, 5, 9, 11, 15, 16 },
            [11] = new() { 5, 10, 16, 17 },
            [12] = new() { 6, 7, 13 },
            [13] = new() { 12, 6, 7, 8, 19, 14 },
            [14] = new() { 8, 9, 13, 19, 20 },
            [15] = new() { 9, 10, 16, 21, 22 },
            [16] = new() { 10, 11, 9, 15, 22, 17 },
            [17] = new() { 16, 11, 22, 23 },
            [18] = new() { 19 },
            [19] = new() { 13, 14, 18, 20 },
            [20] = new() { 19, 14, 21 },
            [21] = new() { 15, 20, 22 },
            [22] = new() { 15, 16, 17, 21, 23 },
            [23] = new() { 17, 22 }
        }
    };
    
    [Benchmark]
    [ArgumentsSource(nameof(Inputs))]
    public void Dfs(Dictionary<int, HashSet<int>> graph)
    {
        _ = DfsSolver.Solve(graph, 0, graph.Count - 1);
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(Inputs))]
    public void Dp(Dictionary<int, HashSet<int>> graph)
    {
        _ = DpSolver.Solve(graph, 0, graph.Count - 1);
    }
    
    private static void Main()
    {
        BenchmarkRunner.Run<Program>();
    }

    private static Dictionary<int, HashSet<int>> CreateGraph(int amountOfVertices)
    {
        var graph = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < amountOfVertices; i++)
        {
            var v = i;
            var neighbours = Enumerable.Range(0, amountOfVertices).Where(x => x != v);
            graph.Add(v, new HashSet<int>(neighbours));
        }

        return graph;
    }
}