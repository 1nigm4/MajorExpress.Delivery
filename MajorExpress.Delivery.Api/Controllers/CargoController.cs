namespace MajorExpress.Delivery.Api.Controllers
{
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Commands.CreateCargo;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Queries;
    using MajorExpress.Delivery.Application.Queries.GetCargo;
    using MajorExpress.Delivery.Application.Queries.GetCargoList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер товаров
    /// </summary>
    public class CargoController : ApiController
    {
        private readonly IMediator _mediator;

        public CargoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        ///     Создать товар
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<CargoDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCargoCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.CreatedAtAction(
                    actionName: nameof(this.Get),
                    routeValues: new { cargoId = result.Id },
                    value: result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Получить товар
        /// </summary>
        [HttpGet("{cargoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<CargoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid cargoId, CancellationToken ct)
        {
            try
            {
                var query = new GetCargoQuery(cargoId);
                var result = await _mediator.Send(query, ct);

                return this.Ok(result);
            }
            catch (CargoNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить список товаров
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PaginationListQueryResponse<CargoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(
            CancellationToken ct,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 25)
        {
            try
            {
                var query = new GetCargoListQuery(pageIndex, pageSize);
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
