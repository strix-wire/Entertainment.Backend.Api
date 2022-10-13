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
        public double Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
    }
}
