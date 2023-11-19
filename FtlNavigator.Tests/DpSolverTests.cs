using FtlNavigator.Tests.Data;
using Xunit;

namespace FtlNavigator.Tests;

public class DpSolverTests
{
    [Fact]
    public void FindsPathIn4VerticesGraph()
    {
        var graph = Graphs.Get4VerticesGraph();

        var path1 = DpSolver.Solve(graph, 0, 3);
        Assert.Equal(new[] { 0, 2, 1, 3 }, path1);
        
        var path2 = DpSolver.Solve(graph, 3, 2);
        Assert.Equal(new[] { 3, 1, 0, 2 }, path2);
    }
    
    [Fact]
    public void FindsPathIn6VerticesGraph()
    {
        var graph = Graphs.Get6VerticesGraph();

        var path1 = DpSolver.Solve(graph, 0, 3);
        Assert.Equal(new[] { 0, 1, 3 }, path1);
        
        var path2 = DpSolver.Solve(graph, 2, 5);
        Assert.Equal(new[] { 2, 0, 1, 3, 4, 5 }, path2);
    }
    
    [Fact]
    public void FindsPathIn9VerticesGraph()
    {
        var graph = Graphs.Get9VerticesGraph();

        var path1 = DpSolver.Solve(graph, 0, 3);
        Assert.Equal(new[] { 0, 1, 2, 4, 8, 7, 3 }, path1);
        
        var path2 = DpSolver.Solve(graph, 2, 4);
        Assert.Equal(new[] { 2, 1, 0, 5, 6, 3, 7, 8, 4 }, path2);
    }
}