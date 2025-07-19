namespace MajorExpress.Delivery.Api.Controllers
{
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Commands.CreateCourier;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Queries;
    using MajorExpress.Delivery.Application.Queries.GetCourier;
    using MajorExpress.Delivery.Application.Queries.GetCourierList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер курьеров
    /// </summary>
    public class CourierController : ApiController
    {
        private readonly IMediator _mediator;

        public CourierController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        ///     Создать курьера
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<CourierDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCourierCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.CreatedAtAction(
                    actionName: nameof(this.Get),
                    routeValues: new { courierId = result.Id },
                    value: result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        /// <summary>
        ///     Получить курьера
        /// </summary>
        /// <param name="courier">Идентификатор курьера</param>
        [HttpGet("{courierId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<CourierDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid courier, CancellationToken ct)
        {
            try
            {
                var query = new GetCourierQuery(courier);
                var result = await _mediator.Send(query, ct);
                return this.Ok(result);
            }
            catch (CourierNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить список курьеров
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PaginationListQueryResponse<CourierDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(
            CancellationToken ct,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 25)
        {
            try
            {
                var query = new GetCourierListQuery(pageIndex, pageSize);
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
