using Shared;
using System.Runtime.InteropServices.ComTypes;

TaskParallelFor();

async Task TaskWhenAllMethod()
{
    var products = ProductsRepository.GetProducts(10000);

    var tasks = products
        .Select(async _ => {
            var stock = await ProductsRepository.GetProductStockAsync(_.Name);

            return Task.CompletedTask;
        })
        .ToList();

    await Task.WhenAll(tasks);
}



void TaskParallelFor()
{
    var products = ProductsRepository.GetProducts(int.MaxValue);

    Parallel.ForEach(products, _ => Console.WriteLine(_.Name));
}
