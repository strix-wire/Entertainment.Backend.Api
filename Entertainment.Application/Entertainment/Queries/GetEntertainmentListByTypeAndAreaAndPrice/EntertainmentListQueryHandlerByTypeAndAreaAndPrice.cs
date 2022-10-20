﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entertainment.Application.Interfaces;
using Entertainment.Application.Logic.Geography;
using Entertainment.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        var listEntertainments = await GetListEntertainmentsByIntervalMoneyAsync(request, cancellationToken);

        //First results for the given area, then not for the area
        var entertainmentQueryInArea = listEntertainments
            .Where(x => request.Area == x.Area)
            .OrderBy(x => _coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude))
            .ToList();

        var entertainmentQueryNotInArea = listEntertainments
            .Where(x => request.Area != x.Area)
            .OrderBy(x => _coordinate.GetDistanceFromPlaceToArea(request.Area, x.Latitude, x.Longitude))
            .ToList();

        entertainmentQueryInArea.AddRange(entertainmentQueryNotInArea);

        return new EntertainmentListVmByTypeAndAreaAndPrice { EntertainmentsListByTypeAndAreaAndPriceVm =
           entertainmentQueryInArea };
    }

    private async Task<IList<EntertainmentLookupDtoByTypeAndAreaAndPrice>> GetListEntertainmentsByIntervalMoneyAsync
        (EntertainmentListQueryByTypeAndAreaAndPrice request, CancellationToken cancellationToken)
    {
        if (request.IntervalMoney == IntervalMoney.More)
        {
            return await _dbContext.Entertainments
                .Where(x => x.Price >= request.Price &&
                request.TypeEntertainment == x.TypeEntertainment)
                .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
        //less
        else
        {
            return await _dbContext.Entertainments
                .Where(x => x.Price <= request.Price &&
                request.TypeEntertainment == x.TypeEntertainment)
                .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
