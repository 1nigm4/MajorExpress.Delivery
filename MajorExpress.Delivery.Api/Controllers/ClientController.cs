namespace MajorExpress.Delivery.Api.Controllers
{
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Commands.CreateClient;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Queries;
    using MajorExpress.Delivery.Application.Queries.GetClient;
    using MajorExpress.Delivery.Application.Queries.GetClientList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер клиентов
    /// </summary>
    public class ClientController : ApiController
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        ///     Создать клиента
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ClientDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateClientCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return this.CreatedAtAction(
                    actionName: nameof(this.Get),
                    routeValues: new { clientId = result.Id },
                    value: result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        /// <summary>
        ///     Получить клиента
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        [HttpGet("{clientId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid clientId, CancellationToken ct)
        {
            try
            {
                var query = new GetClientQuery(clientId);
                var result = await _mediator.Send(query, ct);
                return this.Ok(result);
            }
            catch (ClientNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить список клиентов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PaginationListQueryResponse<ClientDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(
            CancellationToken ct,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 25)
        {
            try
            {
                var query = new GetClientListQuery(pageIndex, pageSize);
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
