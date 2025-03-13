namespace AdvancedKafka.SharedKernel
{
    public abstract class CommandBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    }

    public abstract class QueryBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    }
}