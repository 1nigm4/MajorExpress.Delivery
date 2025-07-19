namespace MajorExpress.Delivery.Application.Dto
{
    using MajorExpress.Delivery.Domain.Models;

    /// <summary>
    ///     ДТО <see cref="Client"/>
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     <inheritdoc cref="UserDto"/>
        /// </summary>
        public UserDto User { get; set; }
    }
}
