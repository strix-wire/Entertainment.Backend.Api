using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentList;

/// <summary>
/// Request all entertainments
/// </summary>
public class EntertainmentListQuery : IRequest<EntertainmentListVm>
{

}
