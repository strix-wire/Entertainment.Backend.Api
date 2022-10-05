using Entertainment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Commands.UpdateEntertainment;

public class UpdateEntertainmentCommand : IRequest
{
    public Guid Id { get; set; }
    /// <summary>
    /// Not used yet
    /// </summary>
    public Guid UserId { get; set; }
    public long Price { get; set; }
    public TypeEntertainment TypeEntertainment { get; set; }
    public string? Details { get; set; }
    public Area Area { get; set; }
    /// <summary>
    /// Maybe not worked with double
    /// </summary>
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
