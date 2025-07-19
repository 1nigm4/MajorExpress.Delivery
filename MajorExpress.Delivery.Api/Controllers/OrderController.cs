namespace MajorExpress.Delivery.Api.Controllers
{
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Commands.CancelOrder;
    using MajorExpress.Delivery.Application.Commands.CompleteOrder;
    using MajorExpress.Delivery.Application.Commands.CreateOrder;
    using MajorExpress.Delivery.Application.Commands.ExecuteOrder;
    using MajorExpress.Delivery.Application.Commands.RemoveOrder;
    using MajorExpress.Delivery.Application.Commands.UpdateOrder;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Queries;
    using MajorExpress.Delivery.Application.Queries.GetOrder;
    using MajorExpress.Delivery.Application.Queries.GetOrderList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер заявок
    /// </summary>
    public class OrderController : ApiController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Зарегистрировать заявку
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] CreateOrderCommand command,
            CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.CreatedAtAction(
                    actionName: nameof(this.Get),
                    routeValues: new { orderId = result.Id },
                    value: result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Передать на выполнение заявку
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Execute(
            [FromBody] ExecuteOrderCommand command,
            CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Перевести заявку в статус выполнено
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Complete(
            [FromBody] CompleteOrderCommand command,
            CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Отменить заявку
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Cancel(
            [FromBody] CancelOrderCommand command,
            CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Редактировать заявку
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (OrderNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Удалить заявку
        /// </summary>
        /// <param name="orderId">Идентификатор заявки</param>
        [HttpDelete("{orderId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(Guid orderId, CancellationToken ct)
        {
            try
            {
                var command = new RemoveOrderCommand(orderId);
                await _mediator.Send(command, ct);
                return this.Ok(orderId);
            }
            catch (OrderNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить заявку
        /// </summary>
        /// <param name="orderId">Идентификатор заявки</param>
        [HttpGet("{orderId:guid}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid orderId, CancellationToken ct)
        {
            try
            {
                var query = new GetOrderQuery(orderId);
                var result = await _mediator.Send(query, ct);
                return this.Ok(result);
            }
            catch (OrderNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить список заявок
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PaginationListQueryResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(
            CancellationToken ct,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 25,
            [FromQuery] string? filter = null)
        {
            try
            {
                var query = new GetOrderListQuery(pageIndex, pageSize, filter);
                var result = await _mediator.Send(query, ct);
                return this.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
