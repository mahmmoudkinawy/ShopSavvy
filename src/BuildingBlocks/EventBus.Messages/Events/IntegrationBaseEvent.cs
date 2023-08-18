namespace EventBus.Messages.Events;
public abstract class IntegrationBaseEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreationDate { get; init; } = DateTime.UtcNow;
}
