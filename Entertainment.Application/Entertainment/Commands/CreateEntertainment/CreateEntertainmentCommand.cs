using Entertainment.Domain;
using MediatR;

namespace Entertainment.Application.Entertainment.Commands.CreateEntertainment;

public class CreateEntertainmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Not used yet
    /// </summary>
    public Guid UserId { get; set; }
    public string Name { get; set; }
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
}
