namespace MajorExpress.Delivery.Application.Commands.CreateCourier
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
    ///     Обработчик команды <see cref="CreateCourierCommand"/>
    /// </summary>
    public class CreateCourierCommandHandler : IRequestHandler<CreateCourierCommand, CourierDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Courier, CourierDto> _mapper;

        public CreateCourierCommandHandler(
            IUserRepository userRepository,
            ICourierRepository clientRepository,
            IUnitOfWork unitOfWork,
            IMapper<Courier, CourierDto> mapper)
        {
            _userRepository = userRepository;
            _courierRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourierDto> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            var courier = new Courier
            {
                User = user,
            };

            await _courierRepository.CreateAsync(courier, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(courier);
        }
    }
}
