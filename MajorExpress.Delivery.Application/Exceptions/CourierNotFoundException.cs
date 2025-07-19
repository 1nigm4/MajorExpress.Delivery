namespace MajorExpress.Delivery.Application.Exceptions
{
    public class CourierNotFoundException : MajorException
    {
        public CourierNotFoundException(Guid courierId) : base($"Курьер с идентификатором {courierId} не найден")
        {
            
        }
    }
}
