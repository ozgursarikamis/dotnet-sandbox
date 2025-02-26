using System.Text.Json;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary.AdvancedTopics;

public class TransformBlockExample
{
    public static async Task Run()
    {
        // TransformBlock to convert JSON to Person objects:
        var jsonTransformer = new TransformBlock<string, Person?>(json =>
        {
            try
            {
                return JsonSerializer.Deserialize<Person>(json);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        });
        
        // ActionBlock to process Person objects:
        var personProcessor = new ActionBlock<Person?>(person =>
        {
            if (person != null)
            {
                Console.WriteLine($"Processing person: {person.Name}, {person.Age}");
            }
        });
        
        // Link the TransformBlock to the ActionBlock:
        jsonTransformer.LinkTo(personProcessor);
        
        // Simulate JSON data input
        string[] jsonData =
        [
            "{\"Name\":\"Alice\",\"Age\":30}",
            "{\"Name\":\"Bob\",\"Age\":25}",
            "Invalid JSON",
            "{\"Name\":\"Charlie\",\"Age\":35}"
        ];

        foreach (var json in jsonData)
            jsonTransformer.Post(json);
        
        // Signal that no more JSON data is coming:
        jsonTransformer.Complete();
        await personProcessor.Completion;
        
        Console.WriteLine("Person processing complete.");
        Console.ReadKey();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}