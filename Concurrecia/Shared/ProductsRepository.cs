namespace Shared;

public static class ProductsRepository
{
    public static List<Product> GetProducts(int items)
    {
        return Enumerable
            .Range(0, items)
            .Select(_ => new Product()
            {
                Name = $"Name {_}"
            })
            .ToList();
    }

    public static async Task<int> GetProductStockAsync(string productName)
    {
        await Task.Delay(10000);
        return new Random().Next();
    }

    public static async Task<IEnumerable<Product>> GetProductsWith1SecondAsync()
    {
        var products = new List<Product>();

        for (var i = 0; i < ProductHelp.MaxItemsInStream; i++)
        {
            await Task.Delay(1000);
            products.Add(new Product()
            {
                Name = $"Product {i}"
            });
        }

        return products;
    }

    public static async IAsyncEnumerable<Product> GetProductsAsyncEnumerableAsync()
    {
        for (var i = 0; i < ProductHelp.MaxItemsInStream; i++)
        {
            await Task.Delay(1000);
            yield return new Product()
            {
                Name = $"Product {i}"
            };
        }
    }
}

public class Product
{
    public string Name { get; set; }

    public async Task PrintNameAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine(Name);
    }
}
