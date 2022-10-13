using Entertainment.Application.Entertainment.Queries.GetEntertainmentList;
using Entertainment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice
{
    public class EntertainmentListQueryByTypeAndAreaAndPrice : IRequest<EntertainmentListVmByTypeAndAreaAndPrice>
    {
        /// <summary>
        /// Not used yet
        /// </summary>
        public Guid UserId { get; set; }
        public Area Area { get; set; }
        public double Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
    }
}
