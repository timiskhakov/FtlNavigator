using System.Collections.Generic;

namespace FtlNavigator;

public static class DpSolver
{
    public static int[] Solve(Dictionary<int, HashSet<int>> graph, int start, int end)
    {
        var dp = CreateDp(graph, start);
        var subset = FindMaxSubset(dp, end);
        var path = ReconstructPath(graph, dp, subset, end);

        return path.ToArray();
    }

    private static bool[,] CreateDp(Dictionary<int, HashSet<int>> graph, int start)
    {
        var n = 1 << graph.Count;
        var dp = new bool[n, graph.Count];
        dp[1 << start , start] = true;
        
        for (var i = 1 << start; i < n; i++)
        for (var j = 0; j < graph.Count; j++)
        {
            if (!CheckIfBitSet(i, j)) continue;
            var mask = ClearBit(i, j);
            for (var k = 0; k < graph.Count; k++)
            {
                if (!dp[mask, k] || !graph[k].Contains(j)) continue;
                dp[i, j] = true;
                break;
            }
        }

        return dp;
    }
    
    private static int FindMaxSubset(bool[,] dp, int end)
    {
        var maxSubset = 0;
        for (var i = 0; i < dp.GetLength(0); i++)
        {
            if (!CheckIfBitSet(i, end) ||
                !dp[i, end] ||
                CountBits(i) <= CountBits(maxSubset)) continue;
            maxSubset = i;
        }
        
        return maxSubset;
    }

    private static Stack<int> ReconstructPath(Dictionary<int, HashSet<int>> graph, bool[,] dp, int subset, int end)
    {
        var path = new Stack<int>(new[] { end });
        while (subset > 0)
        {
            subset = ClearBit(subset, end);
            for (var j = 0; j < graph.Count; j++)
            {
                if (!dp[subset, j] || !graph[j].Contains(end)) continue;
                path.Push(j);
                end = j;
                break;
            }
        }

        return path;
    }

    private static bool CheckIfBitSet(int value, int position)
    {
        return (value & (1 << position)) > 0;
    }

    private static int ClearBit(int value, int position)
    {
        return value & ~(1 << position);
    }
    
    private static int CountBits(int value)
    {
        var count = 0;
        while (value > 0)
        {
            count++;
            value &= value - 1;
        }

        return count;
    }
}
