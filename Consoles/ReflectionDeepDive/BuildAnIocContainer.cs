namespace ReflectionDeepDive;

public static class BuildAnIocContainer
{
    public static void Run()
    {
        var container = new IocContainer();
        
        // Register services:
        container.Register<IService, EmailService>();

        IService service = container.Resolve<IService>();
        service.Execute();
    }
}

internal interface IService
{
    void Execute();
}

internal class EmailService : IService
{
    public void Execute() => Console.WriteLine("📧 Sending an email...");
}

internal class LoggingService : IService
{
    public void Execute() => Console.WriteLine("📝 Writing logs...");
}

internal class IocContainer
{
    private Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();
    
    // Register a service

    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _registrations[typeof(TInterface)] = typeof(TImplementation);
    }
    
    // Resolve a service:
    public T Resolve<T>()
    {
        Type implementationType = _registrations[typeof(T)];
        return (T)Activator.CreateInstance(implementationType)!;
    }
}