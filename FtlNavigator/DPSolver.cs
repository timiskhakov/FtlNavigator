using System;
using System.Collections.Generic;
using System.Linq;

namespace FtlNavigator;

public class DPSolver
{
    public int[] Solve(IReadOnlyDictionary<int, int[]> graph)
    {
        var n = 1 << graph.Count;
        var dps = new List<int[,]>();

        for (var d = 0; d < graph.Count; d++)
        {
            var dp = new int[n, graph.Count];
            for (var i = 1; i < n; i++)
            {
                if (CheckSingleBit(i) && d == GetSingleBitPosition(i))
                {
                    dp[i, GetSingleBitPosition(i)] = 1;
                    continue;
                }

                for (var j = 0; j < graph.Count; j++)
                {
                    if (!CheckIfBitSet(i, j)) continue; // Skip if j-th bit is 0

                    var mask = ClearBit(i, j);
                    for (var k = 0; k < graph.Count; k++)
                    {
                        // find the previous state that leads to the current state and update dp[i, j] accordingly
                        if (CheckIfBitSet(mask, k) && graph[k].Contains(j) && dp[mask, k] == 1)
                        {
                            dp[i, j] = 1;
                            break;
                        }
                    }
                }
            }

            dps.Add(dp);
        }

        
        foreach (var dp in dps)
        {
            for (var j = 0; j < graph.Count; j++)
            {
                for (var i = 0; i < n; i++)
                {
                    Console.Write($" {dp[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // Add more code here....

        return Array.Empty<int>();
    }

    private static bool CheckSingleBit(int value)
    {
        return (value & (value - 1)) == 0;
    }

    private static int GetSingleBitPosition(int value)
    {
        int count = 0;
        while (value > 0)
        {
            value >>= 1;
            count++;
        }

        return count - 1;
    }

    private static bool CheckIfBitSet(int value, int position)
    {
        return (value & (1 << position)) > 0;
    }

    private static int ClearBit(int value, int position)
    {
        return ((value) &= ~(1 << (position)));
    }
}
