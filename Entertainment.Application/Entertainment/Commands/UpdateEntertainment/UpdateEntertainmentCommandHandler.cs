using Entertainment.Application.Interfaces;
using Entertainment.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Application.Entertainment.Commands.UpdateEntertainment;

internal class UpdateEntertainmentCommandHandler : IRequest<UpdateEntertainmentCommand>
{
    private readonly IEntertainmentDbContext _dbContext;

    public UpdateEntertainmentCommandHandler(IEntertainmentDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateEntertainmentCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Entertainments.FirstOrDefaultAsync(entertainment =>
        entertainment.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            //CHange EntryPointNotFoundException
            throw new EntryPointNotFoundException(nameof(EntertainmentEntity));
        }

        UpdateEntity(entity, request);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    /// <summary>
    /// Check working update
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    private void UpdateEntity(EntertainmentEntity entity,
        UpdateEntertainmentCommand request)
    {
        entity.Name = request.Name;
        entity.City = request.City;
        entity.Ranking = request.Ranking;
        entity.UrlImage = request.UrlImage;
        entity.UrlSite = request.UrlSite;
        entity.Price = request.Price;
        entity.TypeEntertainment = request.TypeEntertainment;
        entity.Details = request.Details;
        entity.Area = request.Area;
        entity.Latitude = request.Latitude;
        entity.Longitude = request.Longitude;
        entity.EditDate = DateTime.Now;
        entity.Address = request.Address;
    }
}
