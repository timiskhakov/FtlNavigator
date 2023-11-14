using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FtlNavigator;

public class DPSolver
{
    public int[] Solve(IReadOnlyDictionary<int, int[]> graph, int start, int end)
    {
        var n = 1 << graph.Count;
        var dp = new int[n, graph.Count];
        for (var i = 1; i < n; i++)
        {
            if (CheckSingleBit(i) && start == GetSingleBitPosition(i))
            {
                dp[i, start] = 1;
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
        
        for (var j = 0; j < graph.Count; j++)
        {
            for (var i = 0; i < n; i++)
            {
                Console.Write($" {dp[i, j]}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Reconstructing the path
        var path = new List<int>();
        var set = FindSet(graph, dp, n - 1, end);
        var prv = end;
        while (set > 0)
        {
            for (var j = graph.Count - 1; j >= 0; j--)
            {
                if (dp[set, j] == 0) continue;
                if (prv != j && !graph[j].Contains(prv)) continue;

                path.Add(j);
                prv = j;
                set = ClearBit(set, j);

                break;
            }
        }

        path.Reverse();

        return path.ToArray();
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

    private static int FindSet(IReadOnlyDictionary<int, int[]> graph, int[,] dp, int set, int end)
    {
        while (set > 0)
        {
            if (!CheckIfBitSet(set, end))
            {
                set--;
                continue;
            }

            var ones = 0;
            for (var j = 0; j < graph.Count; j++)
            {
                if (j == end && dp[set, j] == 1)
                {
                    ones++;
                }
            }

            if (ones == 1) return set;
            
            set--;
        }

        throw new ArgumentException();
    }
}
