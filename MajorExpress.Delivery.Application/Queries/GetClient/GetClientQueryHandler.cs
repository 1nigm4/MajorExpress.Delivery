namespace MajorExpress.Delivery.Application.Queries.GetClient
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetClientQuery"/>
    /// </summary>
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper<Client, ClientDto> _mapper;

        public GetClientQueryHandler(IClientRepository clientRepository, IMapper<Client, ClientDto> mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.Id, cancellationToken, client => client.User);
            if (client == null)
            {
                throw new ClientNotFoundException(clientId: request.Id);
            }

            return _mapper.Map(client);
        }
    }
}
