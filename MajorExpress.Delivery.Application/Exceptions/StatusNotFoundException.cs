namespace MajorExpress.Delivery.Application.Exceptions
{
    public class StatusNotFoundException : MajorException
    {
        public StatusNotFoundException(byte statusValue) : base($"Статус со значением {statusValue} не найден")
        {
            
        }
    }
}
