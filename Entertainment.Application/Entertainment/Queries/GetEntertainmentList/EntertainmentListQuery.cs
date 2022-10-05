using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentList
{
    public class EntertainmentListQuery : IRequest<EntertainmentListVm>
    {
        /// <summary>
        /// Not used yet
        /// </summary>
        public Guid UserId { get; set; }
    }
}
