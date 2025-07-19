namespace MajorExpress.Delivery.Application.Exceptions
{
    public class CargoNotFoundException : MajorException
    {
        public CargoNotFoundException(Guid cargoId) : base($"Груз с идентификатором {cargoId} не найден")
        {

        }
    }
}
