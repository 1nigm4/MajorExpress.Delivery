namespace MajorExpress.Delivery.Application.Exceptions
{
    public class MajorException : Exception
    {
        public MajorException(string message) : base(message)
        {
            
        }

        public MajorException(Exception exception) : base(exception.Message, exception)
        {
            
        }
    }
}
