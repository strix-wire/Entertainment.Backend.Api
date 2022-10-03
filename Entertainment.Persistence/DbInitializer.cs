using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Persistence
{
    internal class DbInitializer
    {
        public static void Initialize(EntertainmentDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
