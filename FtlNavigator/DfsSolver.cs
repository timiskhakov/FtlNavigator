using System.Collections.Generic;
using System.Linq;

namespace FtlNavigator;

public static class DfsSolver
{
    public static int[] Solve(Dictionary<int, HashSet<int>> graph, int start, int end)
    {
        var solutions = new List<int[]>();
        var visited = new bool[graph.Count];
        var path = new Stack<int>();

        Dfs(graph, solutions, visited, path, start, end);

        return solutions
            .Aggregate((result, next) => result.Length > next.Length ? result : next)
            .Reverse()
            .ToArray();
    }

    private static void Dfs(
        Dictionary<int, HashSet<int>> graph,
        List<int[]> solutions,
        bool[] visited,
        Stack<int> path,
        int current,
        int end)
    {
        visited[current] = true;
        path.Push(current);
        if (current == end)
        {
            solutions.Add(path.ToArray());
        }
        else
        {
            foreach (var neighbor in graph[current])
            {
                if (visited[neighbor]) continue;
                Dfs(graph, solutions, visited, path, neighbor, end);
            }
        }

        visited[current] = false;
        path.Pop();
    }
}
