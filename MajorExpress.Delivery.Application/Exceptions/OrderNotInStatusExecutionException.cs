namespace MajorExpress.Delivery.Application.Exceptions
{
    using MajorExpress.Delivery.Domain.Models;

    public class OrderNotInStatusExecutionException : MajorException
    {
        public OrderNotInStatusExecutionException(Guid orderId) : base($"Заявка с идентификатором {orderId} не находится в статусе \"{OrderStatus.SubmittedForExecution.Title}\"")
        {
            
        }
    }
}
