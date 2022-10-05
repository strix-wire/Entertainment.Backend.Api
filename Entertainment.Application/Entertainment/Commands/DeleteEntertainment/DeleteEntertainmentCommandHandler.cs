using Entertainment.Application.Interfaces;
using Entertainment.Domain;
using MediatR;

namespace Entertainment.Application.Entertainment.Commands.DeleteEntertainment;

//DeleteEntertainmentCommand - query, Guid - response
internal class DeleteEntertainmentCommandHandler : IRequestHandler<DeleteEntertainmentCommand>
{
    private readonly IEntertainmentDbContext _dbContext;

    public DeleteEntertainmentCommandHandler(IEntertainmentDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteEntertainmentCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Entertainments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            //CHange EntryPointNotFoundException
            throw new EntryPointNotFoundException(nameof(EntertainmentEntity));
        }

        _dbContext.Entertainments.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
