using System.Collections.Generic;

namespace FtlNavigator.Tests.Data;

public static class Graphs
{
    public static Dictionary<int, HashSet<int>> Get4VerticesGraph()
    {
        return new Dictionary<int, HashSet<int>>
        {
            [0] = new() { 1, 2 },
            [1] = new() { 0, 2, 3 },
            [2] = new() { 0, 1 },
            [3] = new() { 1 }
        };
    }

    public static Dictionary<int, HashSet<int>> Get6VerticesGraph()
    {
        return new Dictionary<int, HashSet<int>>
        {
            [0] = new() { 1, 2, 3 },
            [1] = new() { 0, 3 },
            [2] = new() { 0, 3 },
            [3] = new() { 1, 4, 5 },
            [4] = new() { 3, 5 },
            [5] = new() { 3, 4 }
        };
    }

    public static Dictionary<int, HashSet<int>> Get9VerticesGraph()
    {
        return new Dictionary<int, HashSet<int>>
        {
            [0] = new() { 1, 5 },
            [1] = new() { 0, 2 },
            [2] = new() { 1, 3, 4, 5, 8 },
            [3] = new() { 2, 6, 7 },
            [4] = new() { 2, 8 },
            [5] = new() { 0, 2, 6 },
            [6] = new() { 3, 5 },
            [7] = new() { 3, 8 },
            [8] = new() { 2, 4, 7 }
        };
    }
}