using Entertainment.Application.Interfaces;
using Entertainment.Domain;
using Entertainment.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Persistence
{
    public class EntertainmentDbContext : DbContext, IEntertainmentDbContext
    {
        public DbSet<EntertainmentEntity> Entertainments { get;set; }

        public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EntertainmentConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
