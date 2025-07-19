namespace MajorExpress.Delivery.Application.Commands.RemoveOrder
{
    using MediatR;

    /// <summary>
    ///     Комана "Удалить" заявку
    /// </summary>
    public class RemoveOrderCommand : IRequest
    {
        public RemoveOrderCommand(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException("Необходимо передать идентификатор заявки", nameof(id));
            }

            this.Id = id;
        }

        /// <summary>
        ///     Идентификатор заявки
        /// </summary>
        public Guid Id { get; set; }
    }
}
