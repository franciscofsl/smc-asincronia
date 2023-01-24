// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



async void Task1Async()
{
    await Task.Delay(1500);
    Console.WriteLine("Fin tarea 1");
}

async Task Task2Async()
{
    await Task.Delay(1500);
    Console.WriteLine("Fin tarea 2");
}

async Task<string> Task3()
{
    await Task.Delay(1500);
    return "Task 3";
}

async string Task4Async()
{
    await Task.Delay(1500); 
    return "Task 4";
}