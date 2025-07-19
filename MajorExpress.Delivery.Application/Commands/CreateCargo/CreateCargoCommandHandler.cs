namespace MajorExpress.Delivery.Application.Commands.CreateCargo
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик команды <see cref="CreateCargoCommand"/>
    /// </summary>
    public class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, CargoDto>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Cargo, CargoDto> _mapper;

        public CreateCargoCommandHandler(
            ICargoRepository cargoRepository,
            IUnitOfWork unitOfWork,
            IMapper<Cargo, CargoDto> mapper)
        {
            _cargoRepository = cargoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CargoDto> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = new Cargo
            {
                Description = request.Description,
                Weight = request.Weight,
                Size = request.Size,
            };

            await _cargoRepository.CreateAsync(cargo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map(cargo);
        }
    }
}
