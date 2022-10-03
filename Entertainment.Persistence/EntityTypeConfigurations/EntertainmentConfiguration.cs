using Entertainment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Persistence.EntityTypeConfigurations
{
    public class EntertainmentConfiguration : IEntityTypeConfiguration<EntertainmentEntity>
    {
        public void Configure(EntityTypeBuilder<EntertainmentEntity> builder)
        {

        }
    }
}
