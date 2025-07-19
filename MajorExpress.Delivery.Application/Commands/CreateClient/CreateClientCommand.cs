namespace MajorExpress.Delivery.Application.Commands.CreateClient
{
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MediatR;

    /// <summary>
    ///     Команда "Создать" клиента
    /// </summary>
    public class CreateClientCommand : IRequest<ClientDto>
    {
        public CreateClientCommand(Guid userId)
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
