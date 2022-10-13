using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entertainment.Application.Interfaces;
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

        public EntertainmentListQueryHandlerByTypeAndAreaAndPrice(IEntertainmentDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EntertainmentListVmByTypeAndAreaAndPrice> Handle(EntertainmentListQueryByTypeAndAreaAndPrice request,
            CancellationToken cancellationToken)
        {
            var entertainmentQuery = await _dbContext.Entertainments
                .Where(x=>x.Area == request.Area && x.Price == request.Price && 
                    x.TypeEntertainment == request.TypeEntertainment)
                .ProjectTo<EntertainmentLookupDtoByTypeAndAreaAndPrice>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EntertainmentListVmByTypeAndAreaAndPrice { GetEntertainments = entertainmentQuery };
        }
    }
}
