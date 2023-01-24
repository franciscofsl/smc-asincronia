using Shared;
using System.Collections.Concurrent;

await Solution1();

// Console.Clear();
// await Way2();

async Task Fail()
{
    var products = ProductsRepository.GetProducts(int.MaxValue);

    foreach (var product in products)
    {
        await product.PrintNameAsync();
    }
}

async Task FailSolution()
{
    var products = ProductsRepository.GetProducts(int.MaxValue);

    var tasks = products.Select(async _ => await _.PrintNameAsync()).ToList();
 
    await Task.WhenAll(tasks);
}

async Task Solution1()
{
    var products = new ConcurrentQueue<Product>(ProductsRepository.GetProducts(int.MaxValue));
    var tasks = new List<Task>();

    const int maxThreads = 3;

    for (var index = 0; index < maxThreads; index++)
    {
        tasks.Add(Task.Run(async () => {
            while (products.TryDequeue(out Product product))
            {
                await product.PrintNameAsync();
            }
        }));
    }

    await Task.WhenAll(tasks);
}


async Task Solution2()
{
    var allTasks = new List<Task>();
    var semaphore = new SemaphoreSlim(3);
    
    foreach (var product in ProductsRepository.GetProducts(int.MaxValue))
    {
        await semaphore.WaitAsync();
        allTasks.Add(
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(1000);
                Console.WriteLine(product.Name);
            }
            finally
            {
                semaphore.Release();
            }
        }));
    }
    await Task.WhenAll(allTasks);
}