using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entertainment.Application.Interfaces;
using Entertainment.Application.Logic.Geography;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice
{
    public class EntertainmentListQueryHandlerByTypeAndAreaAndPrice
        : IRequestHandler<EntertainmentListQueryByTypeAndAreaAndPrice, 
            EntertainmentListVmByTypeAndAreaAndPrice>
    {
        private readonly IEntertainmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly Coordinate _coordinate = new();

        public EntertainmentListQueryHandlerByTypeAndAreaAndPrice(IEntertainmentDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EntertainmentListVmByTypeAndAreaAndPrice> Handle(EntertainmentListQueryByTypeAndAreaAndPrice request,
            CancellationToken cancellationToken)
        {
            //First results for the given area, then not for the area
            var entertainmentQueryInArea = await _dbContext.Entertainments
                .Where(x=>request.Price >= x.Price &&
                request.TypeEntertainment == x.TypeEntertainment &&
                request.Area == x.Area)
                .OrderBy(x=>_coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude))
                .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var entertainmentQueryNotInArea = await _dbContext.Entertainments
                .Where(x => request.Price >= x.Price &&
                request.TypeEntertainment == x.TypeEntertainment &&
                request.Area != x.Area)
                .OrderBy(x => _coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude))
                .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EntertainmentListVmByTypeAndAreaAndPrice { GetEntertainments =
               entertainmentQueryInArea.Concat(entertainmentQueryNotInArea) };
        }
    }
}
