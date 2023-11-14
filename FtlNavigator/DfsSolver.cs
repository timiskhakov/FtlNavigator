using System.Collections.Generic;
using System.Linq;

namespace FtlNavigator;

public class DfsSolver
{
    public int[] Solve(IReadOnlyDictionary<int, int[]> graph, int start, int end)
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

    private void Dfs(
        IReadOnlyDictionary<int, int[]> graph,
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
