using FtlNavigator;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var graph = new Dictionary<int, int[]>
        {
            [0] = new int[] { 1, 5 },
            [1] = new int[] { 0, 2 },
            [2] = new int[] { 1, 3, 4 },
            [3] = new int[] { 2, 7 },
            [4] = new int[] { 2 },
            [5] = new int[] { 0, 6 },
            [6] = new int[] { 5 },
            [7] = new int[] { 3 },
        };

        // Clara
        //var graph = new Dictionary<int, int[]>
        //{
        //    [0] = new int[] { 1, 2 },
        //    [1] = new int[] { 0, 2, 3 },
        //    [2] = new int[] { 0, 1, 3 },
        //    [3] = new int[] { 1, 2 }
        //};

        var dp = new DPSolver();
        var path = dp.Solve(graph, 2, 6);
    }
}
