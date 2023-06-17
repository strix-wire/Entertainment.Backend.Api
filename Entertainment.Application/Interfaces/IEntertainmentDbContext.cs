using Microsoft.EntityFrameworkCore;
using Entertainment.Domain;

namespace Entertainment.Application.Interfaces
{
    public interface IEntertainmentDbContext
    {
        DbSet<EntertainmentEntity> Entertainments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
