using MediatR;

namespace CQRS.Saga;

public class OrderSagaState
{
    public Guid OrderId { get; set; }
    public bool PaymentProcessed { get; set; }
    public bool OrderConfirmed { get; set; }
}

// Define Commands and Events:

// Step 1: User places order:
public record CreateOrderCommand(Guid OrderId): IRequest;

// Step 2: Payment service processes the payment:
public record ProcessPaymentCommand(Guid OrderId): IRequest;

// Step 3: Order is confirmed:
public record ConfirmOrderCommand(Guid OrderId): IRequest;

// Step 4: Payment failed:
public record PaymentFailedEvent(Guid OrderId): INotification;


// IMPLEMENT COMMAND HANDLERS:

// 1️⃣ Handle Order Creation
public class CreateOrderHandler(IMediator mediator) : IRequestHandler<CreateOrderCommand>
{
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Created OrderId: {request.OrderId}");
        
        // Move to next step: Process payment
        return await mediator.Send(new ProcessPaymentCommand(request.OrderId), cancellationToken);
    }
}

// 2️⃣ Handle Payment Processing
public class ProcessPaymentHandler(IMediator mediator) : IRequestHandler<ProcessPaymentCommand>
{
    private static readonly Random Random = new();

    public async Task<Unit> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var paymentSuccess = Random.Next(0, 2) == 1; // Simulate success/failure

        if (paymentSuccess)
        {
            Console.WriteLine($"Payment for Order {request.OrderId} successful.");
            return await mediator.Send(new ConfirmOrderCommand(request.OrderId), cancellationToken);
        }
        else
        {
            Console.WriteLine($"Payment for Order {request.OrderId} failed.");
            await mediator.Publish(new PaymentFailedEvent(request.OrderId), cancellationToken);
        }
        
        return Unit.Value;
    }
}

// 3️⃣ Handle Order Confirmation
public class ConfirmOrderHandler : IRequestHandler<ConfirmOrderCommand>
{
    public Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Order {request.OrderId} confirmed.");
        return Task.FromResult(Unit.Value);
    }
}

// 4️⃣ Handle Payment Failure (Rollback)
public class PaymentFailedHandler : INotificationHandler<PaymentFailedEvent>
{
    public Task Handle(PaymentFailedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Order {notification.OrderId} is canceled due to payment failure.");
        return Task.CompletedTask;
    }
}