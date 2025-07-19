namespace MajorExpress.Delivery.Application.Exceptions
{
    public class ClientNotFoundException : MajorException
    {
        public ClientNotFoundException(Guid clientId) : base($"Клиент с идентификатором {clientId} не найден")
        {

        }
    }
}
