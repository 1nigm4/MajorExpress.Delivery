namespace MajorExpress.Delivery.Application.Exceptions
{
    public class OrderNotFoundException : MajorException
    {
        public OrderNotFoundException(Guid orderId) : base($"Заявка с идентификатором {orderId} не найдена")
        {

        }
    }
}
