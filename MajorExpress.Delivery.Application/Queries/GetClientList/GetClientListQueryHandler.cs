namespace MajorExpress.Delivery.Application.Queries.GetClientList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса  <see cref="GetClientListQuery"/>
    /// </summary>
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, PaginationListQueryResponse<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper<Client, ClientDto> _mapper;

        public GetClientListQueryHandler(
            IClientRepository clientRepository,
            IMapper<Client, ClientDto> mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public Task<PaginationListQueryResponse<ClientDto>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var totalCount = _clientRepository.GetAll().Count();
            var clients = _clientRepository.GetAll(client => client.User)
                .Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(_mapper.Map)
                .ToArray();

            return Task.FromResult(new PaginationListQueryResponse<ClientDto>(clients, request.PageIndex, request.PageSize, totalCount));
        }
    }
}
