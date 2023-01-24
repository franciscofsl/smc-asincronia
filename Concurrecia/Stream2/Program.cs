using Shared;

foreach (var product in await ProductsRepository.GetProductsWith1SecondAsync())
{ 
    Console.WriteLine(product.Name);
}



