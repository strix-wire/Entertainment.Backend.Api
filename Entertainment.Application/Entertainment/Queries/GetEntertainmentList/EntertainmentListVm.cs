using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentList
{
    public class EntertainmentListVm
    {
        public IList<EntertainmentLookupDto> GetEntertainments { get; set; }
    }
}
