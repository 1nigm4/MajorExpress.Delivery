namespace MajorExpress.Delivery.Application.Exceptions
{
    public class UserNotFoundException : MajorException
    {
        public UserNotFoundException(Guid userId) : base($"Пользователь с идентификатором {userId} не найден")
        {

        }
    }
}
