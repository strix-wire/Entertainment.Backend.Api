using Entertainment.Application.Entertainment.Queries.GetEntertainmentList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice
{
    public class EntertainmentListVmByTypeAndAreaAndPrice
    {
        public IList<EntertainmentLookupDtoByTypeAndAreaAndPrice> GetEntertainments { get; set; }
    }
}
