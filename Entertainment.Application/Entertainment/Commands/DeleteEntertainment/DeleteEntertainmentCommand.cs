using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Commands.DeleteEntertainment;

internal class DeleteEntertainmentCommand : IRequest
{
    public Guid Id { get; set; }
    /// <summary>
    /// Not used yet
    /// </summary>
    public Guid UserId { get; set; }
}
