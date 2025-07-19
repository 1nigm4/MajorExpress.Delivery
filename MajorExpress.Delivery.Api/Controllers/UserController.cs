namespace MajorExpress.Delivery.Api.Controllers
{
    using MajorExpress.Delivery.Api.Models;
    using MajorExpress.Delivery.Application.Commands.CreateUser;
    using MajorExpress.Delivery.Application.Commands.UpdateUser;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Queries;
    using MajorExpress.Delivery.Application.Queries.GetUser;
    using MajorExpress.Delivery.Application.Queries.GetUserList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер пользователей
    /// </summary>
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        ///     Создать пользователя
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                return CreatedAtAction(
                    actionName: nameof(Get),
                    routeValues: new { userId = result.Id },
                    value: result);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Редактировать пользователя
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command, CancellationToken ct)
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
            catch (UserNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        [HttpGet("{userId:guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid userId, CancellationToken ct)
        {
            try
            {
                var query = new GetUserQuery(userId);
                var result = await _mediator.Send(query, ct);
                return this.Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Получить список пользователей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PaginationListQueryResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List(
            CancellationToken ct,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 25)
        {
            try
            {
                var query = new GetUserListQuery(pageIndex, pageSize);
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
