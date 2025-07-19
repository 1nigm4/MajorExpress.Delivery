namespace MajorExpress.Delivery.Application.Commands.CreateCourier
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Создать" курьера
    /// </summary>
    public class CreateCourierCommand : IRequest<CourierDto>
    {
        public CreateCourierCommand(Guid userId)
        {
            if (userId == default)
            {
                throw new MajorException(new ArgumentException("Необходимо передать идентификатор пользователя", nameof(userId)));
            }

            this.UserId = userId;
        }

        /// <summary>
        ///     Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
