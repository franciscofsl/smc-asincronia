using System.Collections.Concurrent;

var contact = new ConcurrentQueue<Product>(ProductsRepository);
var tasks = new List<Task>();
for (int n = 0; n < 3; n++)
{
    tasks.Add(Task.Run(async () =>
    {
        while (q.TryDequeue(out Contact contact))
        {
            await Task.Delay(1000);
            Console.WriteLine(contact.Name);
        }
    }));
}

await Task.WhenAll(tasks);

