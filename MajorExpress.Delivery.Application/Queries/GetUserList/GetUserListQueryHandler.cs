namespace MajorExpress.Delivery.Application.Queries.GetUserList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetUserListQuery"/>
    /// </summary>
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, PaginationListQueryResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDto> _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper<User, UserDto> mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<PaginationListQueryResponse<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var totalCount = _userRepository.GetAll().Count();
            var users = _userRepository.GetAll()
                .Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(_mapper.Map)
                .ToArray();

            return Task.FromResult(new PaginationListQueryResponse<UserDto>(users, request.PageIndex, request.PageSize, totalCount));
        }
    }
}
