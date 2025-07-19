namespace MajorExpress.Delivery.Application.Commands.CancelOrder
{
    using System;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Отменить" заявку
    /// </summary>
    public class CancelOrderCommand : IRequest<OrderDto>
    {
        public CancelOrderCommand(Guid id, string cancelComment)
        {
            if (id == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентифиактор заявки", nameof(id)));
            }

            if (string.IsNullOrWhiteSpace(cancelComment))
            {
                throw new MajorException(new ArgumentNullException("Необходимо указать причину отмены", nameof(cancelComment)));
            }

            this.Id = id;
            this.CancelComment = cancelComment;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Причина отмены
        /// </summary>
        public string CancelComment { get; set; }
    }
}
