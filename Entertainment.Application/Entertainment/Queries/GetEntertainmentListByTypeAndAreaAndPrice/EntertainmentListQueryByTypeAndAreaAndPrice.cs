using Entertainment.Domain;
using MediatR;

namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice;

public class EntertainmentListQueryByTypeAndAreaAndPrice : IRequest<EntertainmentListVmByTypeAndAreaAndPrice>
{
    public Area Area { get; set; }
    public double Price { get; set; }
    public TypeEntertainment TypeEntertainment { get; set; }
}
