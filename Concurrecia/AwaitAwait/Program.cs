


var task = GetStringAsync();

var value1 = await task;

Console.WriteLine(value1);

var value2 = await task;

Console.WriteLine(value2);

async Task<string> GetStringAsync()
{
    await Task.Delay(10000);
    return "New string";
}