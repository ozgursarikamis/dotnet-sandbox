// See https://aka.ms/new-console-template for more information

using System.Reflection;
using CQRS.Saga;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello World!");

var services = new ServiceCollection();
// services.AddMediatR(typeof(Program)); // Register MediatR
services.AddMediatR(Assembly.GetExecutingAssembly());

var provider = services.BuildServiceProvider();

// Resolve mediator
var mediator = provider.GetRequiredService<IMediator>();

for (int i = 0; i < 10; i++)
{
    var orderId = Guid.NewGuid();
    await mediator.Send(new CreateOrderCommand(orderId));
}