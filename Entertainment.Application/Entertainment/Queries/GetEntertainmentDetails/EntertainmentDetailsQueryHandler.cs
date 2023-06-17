using AutoMapper;
using Entertainment.Application.Interfaces;
using Entertainment.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentDetails;

internal class EntertainmentDetailsQueryHandler
    : IRequestHandler<EntertainmentDetailsQuery, EntertainmentDetailsVm>
{
    private readonly IEntertainmentDbContext _dbContext;
    private readonly IMapper _mapper;

    public EntertainmentDetailsQueryHandler(IEntertainmentDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<EntertainmentDetailsVm> Handle(EntertainmentDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Entertainments
            .FirstOrDefaultAsync(entertainment =>
            entertainment.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            //CHange EntryPointNotFoundException
            throw new EntryPointNotFoundException(nameof(EntertainmentEntity));
        }

        return _mapper.Map<EntertainmentDetailsVm>(entity);
    }
}
