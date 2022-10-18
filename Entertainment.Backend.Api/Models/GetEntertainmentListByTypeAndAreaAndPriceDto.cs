using Entertainment.Domain;

namespace Entertainment.Backend.Api.Models
{
    /// <summary>
    /// Get entertainment by type entertainment,
    /// area, price
    /// </summary>
    public class GetEntertainmentListByTypeAndAreaAndPriceDto
    {
        public Area Area { get; set; }
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public IntervalMoney IntervalMoney { get; set; }
    }
}
