namespace MajorExpress.Delivery.Application.Queries.GetCargoList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetCargoListQuery"/>
    /// </summary>
    public class GetCargoListQueryHandler : IRequestHandler<GetCargoListQuery, PaginationListQueryResponse<CargoDto>>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper<Cargo, CargoDto> _mapper;

        public GetCargoListQueryHandler(ICargoRepository cargoRepository, IMapper<Cargo, CargoDto> mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public Task<PaginationListQueryResponse<CargoDto>> Handle(GetCargoListQuery request, CancellationToken cancellationToken)
        {
            var totalCount = _cargoRepository.GetAll().Count();
            var cargos = _cargoRepository.GetAll()
                .Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(_mapper.Map)
                .ToArray();

            return Task.FromResult(new PaginationListQueryResponse<CargoDto>(cargos, request.PageIndex, request.PageSize, totalCount));
        }
    }
}
