
using Shared;

await foreach (var os in GetOsAsync())
{
    Console.WriteLine(os);
}

async IAsyncEnumerable<string> GetOsAsync()
{
    yield return "Windows";

    await Task.Delay(3000);
    yield return "Linux";

    await Task.Delay(3000);
    yield return "MacOS";
} 