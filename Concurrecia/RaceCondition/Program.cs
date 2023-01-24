// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Bad();
Good();

void Bad()
{
    var finalValue = 0;

    Parallel.For(0, 1000000, _ => finalValue++);

    Console.WriteLine($"Bad value: {finalValue}");
}

void Good()
{
    var finalValue = 0;

    Parallel.For(0, 1000000, _ => Interlocked.Increment(ref finalValue));

    Console.WriteLine($"Good value: {finalValue}");
}
 
 