using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entertainment.Application.Interfaces;
using Entertainment.Application.Logic.Geography;
using Entertainment.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice;

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
        if (request.Price == 0)
            request.Price = int.MaxValue;

        var calcPriceMoreOrLess = GetMethodToCalculatePriceMoreOrLess(request.IntervalMoney);

        var entertainment = await _dbContext.Entertainments
            .Where(x => (calcPriceMoreOrLess.Invoke(request.Price, x.Price) &&
            request.Price <= x.Price) &&
            request.TypeEntertainment == x.TypeEntertainment)
            .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        //First results for the given area, then not for the area
        var entertainmentQueryInArea = entertainment
            .Where(x => request.Area == x.Area)
            .OrderBy(x => _coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude));

        var entertainmentQueryNotInArea = entertainment
            .Where(x => request.Area != x.Area)
            .OrderBy(x => _coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude));

        return new EntertainmentListVmByTypeAndAreaAndPrice { GetEntertainments =
           entertainmentQueryInArea.Concat(entertainmentQueryNotInArea) };
    }

    private Func<long, long, bool> GetMethodToCalculatePriceMoreOrLess(IntervalMoney intervalMoney)
    {
        if (intervalMoney == IntervalMoney.More)
            return More;
        else
            return Less;
    }

    private bool More(long priceRequest, long priceCurrentEntartainment)
    {
        return priceRequest >= priceCurrentEntartainment;
    }

    private bool Less(long priceRequest, long priceCurrentEntartainment)
    {
        return priceRequest <= priceCurrentEntartainment;
    }
}
