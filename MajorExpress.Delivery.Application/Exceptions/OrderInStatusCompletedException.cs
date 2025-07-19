namespace MajorExpress.Delivery.Application.Exceptions
{
    using System;
    using MajorExpress.Delivery.Domain.Models;

    internal class OrderInStatusCompletedException : MajorException
    {
        public OrderInStatusCompletedException(Guid orderId) : base($"Заявка с идентификатором {orderId} находится в статусе \"{OrderStatus.Completed.Title}\"")
        {

        }
    }
}
