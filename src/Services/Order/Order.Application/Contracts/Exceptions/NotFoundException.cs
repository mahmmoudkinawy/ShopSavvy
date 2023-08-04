namespace Order.Application.Contracts.Exceptions;
public sealed class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key)
       : base($"Entity \"{name}\" ({key}) was not found.")
    { }
}
