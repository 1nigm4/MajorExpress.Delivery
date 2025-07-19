namespace MajorExpress.Delivery.Api.Client.Exceptions
{
    using System;

    [Serializable]
    internal class ApiException : Exception
    {
        public int StatusCode { get; }
        public string Content { get; }

        public ApiException(string message, int statusCode, string content) : base(message)
        {
            this.StatusCode = statusCode;
            this.Content = content;
        }
    }
}