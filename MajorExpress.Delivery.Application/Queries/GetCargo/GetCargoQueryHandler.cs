namespace MajorExpress.Delivery.Application.Queries.GetCargo
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
    ///     Обработчик запроса <see cref="GetCargoQuery"/>
    /// </summary>
    public class GetCargoQueryHandler : IRequestHandler<GetCargoQuery, CargoDto>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper<Cargo, CargoDto> _mapper;

        public GetCargoQueryHandler(
            ICargoRepository cargoRepository,
            IMapper<Cargo, CargoDto> mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<CargoDto> Handle(GetCargoQuery request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.GetAsync(request.Id, cancellationToken);
            if (cargo == null)
            {
                throw new CargoNotFoundException(cargoId: request.Id);
            }

            return _mapper.Map(cargo);
        }
    }
}
