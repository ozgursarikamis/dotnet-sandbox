// See https://aka.ms/new-console-template for more information

using Google.Protobuf;
using ProtobufMessages.ConsoleApp;

var person = new Person
{
    Id = 1,
    Name = "John Doe",
    Email = "john.doe@gmail.com",
    Address = new Address
    {
        AddressLine1 = "123 Main Street",
        AddressLine2 = "Suite 16",
    }
};

// Serialize to byte array
byte[] data;
using (var stream = new MemoryStream())
{
    person.WriteTo(stream);
    data = stream.ToArray();
}


var newPerson = Person.Parser.ParseFrom(data);
newPerson.Name = "Ozgur";
newPerson.Email = "ozgur@sarikamis.com";
newPerson.Hobbies.Add("Football");
newPerson.Hobbies.Add("Basketball");

Console.WriteLine(newPerson.Name);
Console.WriteLine(newPerson.Email);

foreach (var hobby in newPerson.Hobbies)
{
    Console.WriteLine(hobby);
}