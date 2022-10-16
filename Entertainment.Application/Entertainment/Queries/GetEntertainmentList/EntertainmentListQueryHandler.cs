using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entertainment.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentList;

public class EntertainmentListQueryHandler
    : IRequestHandler<EntertainmentListQuery, EntertainmentListVm>
{
    private readonly IEntertainmentDbContext _dbContext;
    private readonly IMapper _mapper;

    public EntertainmentListQueryHandler(IEntertainmentDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<EntertainmentListVm> Handle(EntertainmentListQuery request,
        CancellationToken cancellationToken)
    {
        var entertainmentsQuery = await _dbContext.Entertainments
            .ProjectTo<EntertainmentLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new EntertainmentListVm { GetEntertainments = entertainmentsQuery };
    }
}
