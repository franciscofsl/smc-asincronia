using Shared;

var cancellationTokenSource = new CancellationTokenSource();

var products = ProductsRepository.GetProducts(10);

try
{
    foreach (var product in products)
    {
        if (cancellationTokenSource.Token.IsCancellationRequested)
        {
            throw new TaskCanceledException();
        }

        await product.PrintNameAsync();

        if (product.Name.Contains("5"))
        {
            cancellationTokenSource.Cancel();
        }
    }
}
catch (TaskCanceledException)
{
    Console.WriteLine("End of execution");
}
finally
{
    cancellationTokenSource.Dispose();
}