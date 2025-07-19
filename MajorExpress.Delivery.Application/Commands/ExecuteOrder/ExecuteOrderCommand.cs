namespace MajorExpress.Delivery.Application.Commands.ExecuteOrder
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Передать на выполнение" заявку
    /// </summary>
    public class ExecuteOrderCommand : IRequest<OrderDto>
    {
        public ExecuteOrderCommand(Guid id, Guid courierId)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор заявки", nameof(id)));
            }

            if (courierId == default)
            {
                throw new MajorException(new ArgumentException("Необходимо указать исполнителя", nameof(courierId)));
            }

            this.Id = id;
            this.CourierId = courierId;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Идентификатор курьера
        /// </summary>
        public Guid CourierId { get; set; }
    }
}
