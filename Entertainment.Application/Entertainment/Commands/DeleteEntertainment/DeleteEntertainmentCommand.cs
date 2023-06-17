﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Entertainment.Commands.DeleteEntertainment;

public class DeleteEntertainmentCommand : IRequest
{
    public Guid Id { get; set; }
}
