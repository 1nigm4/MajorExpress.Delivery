namespace MajorExpress.Delivery.Application.Exceptions
{
    using MajorExpress.Delivery.Domain.Models;

    public class OrderNotInStatusNewException : MajorException
    {
        public OrderNotInStatusNewException(Guid orderId) : base($"Заявка с идентификатором {orderId} не находится в статусе \"{OrderStatus.New.Title}\"")
        {
            
        }
    }
}
