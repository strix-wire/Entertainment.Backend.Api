using Entertainment.Application.Interfaces;
using Entertainment.Domain;
using MediatR;

namespace Entertainment.Application.Entertainment.Commands.CreateEntertainment;

internal class CreateEntertainmentCommandHandler : IRequestHandler<CreateEntertainmentCommand, Guid>
{
    private readonly IEntertainmentDbContext _dbContext;

    public CreateEntertainmentCommandHandler(IEntertainmentDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateEntertainmentCommand request,
        CancellationToken cancellationToken)
    {
        var entertainment = new EntertainmentEntity
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Price = request.Price,
            TypeEntertainment = request.TypeEntertainment,
            Details = request.Details,
            Area = request.Area,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            CreationDate = DateTime.UtcNow,
            EditDate = null,
        };

        await _dbContext.Entertainments.AddAsync(entertainment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entertainment.Id;
    }

}
