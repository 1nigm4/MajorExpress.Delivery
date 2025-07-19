namespace MajorExpress.Delivery.Application.Commands.CompleteOrder
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Выполнить" заявку
    /// </summary>
    public class CompleteOrderCommand : IRequest<OrderDto>
    {
        public CompleteOrderCommand(Guid id)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентифиактор заявки", nameof(id)));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }
    }
}
