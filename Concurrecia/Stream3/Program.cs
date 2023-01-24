using Shared;

await foreach (var product in ProductsRepository.GetProductsAsyncEnumerableAsync())
{ 
    Console.WriteLine(product.Name);
}


