using Entertainment.Domain;

namespace Entertainment.Backend.Api.Models
{
    public class UpdateEntertainmentDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Not used yet
        /// </summary>
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string? UrlSite { get; set; }
        public string City { get; set; }
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
        /// <summary>
        /// Maybe not worked with double
        /// </summary>
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? UrlImage { get; set; }
        public byte? Ranking { get; set; }
        public string Address { get; set; }
    }
}
