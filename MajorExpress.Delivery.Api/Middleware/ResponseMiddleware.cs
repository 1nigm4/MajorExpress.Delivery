namespace MajorExpress.Delivery.Api.Middleware
{
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Exceptions;

    /// <summary>
    ///     Конвейр ответов в едином формате
    /// </summary>
    public class ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            try
            {
                await next(context);
                newBody.Seek(0, SeekOrigin.Begin);
                var response = await CreateApiResponse(context, newBody);
                await WriteResponse(context, originalBody, response);
            }
            catch (Exception ex)
            {
                await HandleException(context, originalBody, ex);
            }
        }

        private static async Task<ApiResponse<object>> CreateApiResponse(HttpContext context, MemoryStream body)
        {
            body.Seek(0, SeekOrigin.Begin);
            object? data = null;
            if (body.Length != 0)
            {
                data = await JsonSerializer.DeserializeAsync<object>(body);
            }

            return new ApiResponse<object>
            {
                IsSuccess = true,
                StatusCode = context.Response.StatusCode,
                Data = data,
            };
        }

        private static async Task WriteResponse(HttpContext context, Stream originalBody, ApiResponse<object> response)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(originalBody, response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        private static async Task HandleException(HttpContext context, Stream originalBody, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await JsonSerializer.SerializeAsync(originalBody, new ApiResponse<object>
            {
                IsSuccess = false,
                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex is MajorException ? ex.Message : "Непредвиденная ошибка, обратитесь к администратору сервиса.",
            });
        }
    }
}
