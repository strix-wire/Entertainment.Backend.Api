namespace Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice;

public class EntertainmentListVmByTypeAndAreaAndPrice
{
    public IEnumerable<EntertainmentLookupDtoByTypeAndAreaAndPrice> GetEntertainments { get; set; }
}
