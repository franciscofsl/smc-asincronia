using BenchmarkDotNet.Attributes;

namespace SumAsync;

public class BenchmarkSum
{
    [Benchmark]
    
    
    public void Sum()
    {
        var result = 1 + 5;
    }
    
    

    [Benchmark]
    public Task SumAsync()
    {
        var result = 1 + 5;
        return Task.CompletedTask;
    }
}