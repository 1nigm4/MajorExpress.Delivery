namespace MajorExpress.Delivery.Application.Commands.CreateClient
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Exceptions;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик команды <see cref="CreateClientCommand"/>
    /// </summary>
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Client, ClientDto> _mapper;

        public CreateClientCommandHandler(
            IUserRepository userRepository,
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork,
            IMapper<Client, ClientDto> mapper)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            var client = new Client
            {
                User = user,
            };

            await _clientRepository.CreateAsync(client, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(client);
        }
    }
}
