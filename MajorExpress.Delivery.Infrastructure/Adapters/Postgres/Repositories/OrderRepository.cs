namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Repositories
{
    using System.Linq;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Order> Filter(IQueryable<Order> query, string filter)
        {
            var statusValues = OrderStatus.GetAllStatuses()
                .Where(status => status.Title.Contains(filter, StringComparison.OrdinalIgnoreCase));

            var queryFilter = $"%{filter}%";
            return query.Where(order => EF.Functions.ILike(order.Client.User.LastName, queryFilter)
                || EF.Functions.ILike(order.Client.User.FirstName, queryFilter)
                || (order.Client.User.Patronymic != null && EF.Functions.ILike(order.Client.User.Patronymic, queryFilter))
                || EF.Functions.ILike(order.Client.User.PhoneNumber, queryFilter)
                || EF.Functions.ILike(order.Cargo.Description, queryFilter)
                || (order.Courier != null && (EF.Functions.ILike(order.Courier.User.LastName, queryFilter)
                    || EF.Functions.ILike(order.Courier.User.FirstName, queryFilter)
                    || (order.Courier.User.Patronymic != null && EF.Functions.ILike(order.Courier.User.Patronymic, queryFilter))
                    || EF.Functions.ILike(order.Courier.User.PhoneNumber, queryFilter)))
                || EF.Functions.ILike(order.PickupTime.ToString(), queryFilter)
                || EF.Functions.ILike(order.PickupAddress, queryFilter)
                || EF.Functions.ILike(order.DeliveryAddress, queryFilter)
                || statusValues.Contains(order.Status)
                || (order.CancelComment != null && EF.Functions.ILike(order.CancelComment, queryFilter)));
        }
    }
}
