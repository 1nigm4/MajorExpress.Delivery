namespace MajorExpress.Delivery.Application.Queries.GetCourier
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
    ///     Обработчик запроса <see cref="GetCourierQuery"/>
    /// </summary>
    public class GetCourierQueryHandler : IRequestHandler<GetCourierQuery, CourierDto>
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IMapper<Courier, CourierDto> _mapper;

        public GetCourierQueryHandler(ICourierRepository courierRepository, IMapper<Courier, CourierDto> mapper)
        {
            _courierRepository = courierRepository;
            _mapper = mapper;
        }

        public async Task<CourierDto> Handle(GetCourierQuery request, CancellationToken cancellationToken)
        {
            var courier = await _courierRepository.GetAsync(request.Id, cancellationToken, courier => courier.User);
            if (courier == null)
            {
                throw new ClientNotFoundException(clientId: request.Id);
            }

            return _mapper.Map(courier);
        }
    }
}
