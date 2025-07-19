namespace MajorExpress.Delivery.Application.Queries.GetCourierList
{
    using System.Threading;
    using System.Threading.Tasks;
    using MajorExpress.Delivery.Application.Dto;
    using MajorExpress.Delivery.Application.Interfaces;
    using MajorExpress.Delivery.Domain.Models;
    using MajorExpress.Delivery.Domain.Repositories;
    using MediatR;

    /// <summary>
    ///     Обработчик запроса <see cref="GetCourierListQuery"/>
    /// </summary>
    public class GetCourierListQueryHandler : IRequestHandler<GetCourierListQuery, PaginationListQueryResponse<CourierDto>>
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IMapper<Courier, CourierDto> _mapper;

        public GetCourierListQueryHandler(
            ICourierRepository courierRepository,
            IMapper<Courier, CourierDto> mapper)
        {
            _courierRepository = courierRepository;
            _mapper = mapper;
        }

        public Task<PaginationListQueryResponse<CourierDto>> Handle(GetCourierListQuery request, CancellationToken cancellationToken)
        {
            var totalCount = _courierRepository.GetAll().Count();
            var couriers = _courierRepository.GetAll(courier => courier.User)
                .Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(_mapper.Map)
                .ToArray();

            return Task.FromResult(new PaginationListQueryResponse<CourierDto>(couriers, request.PageIndex, request.PageSize, totalCount));
        }
    }
}
