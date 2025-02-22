Console.WriteLine("Starting...");
await DoSomethingAsync();
Console.WriteLine("Console is finished.");

return;

static async Task DoSomethingAsync()
{
    Console.WriteLine("Task started");
    await Task.Delay(3000);
    Console.WriteLine("Task finished");

    var taskValue = await GetNumberAsync();
    Console.WriteLine(taskValue);
}

static async Task<int> GetNumberAsync()
{
    await Task.Delay(2000);
    return 42;
}