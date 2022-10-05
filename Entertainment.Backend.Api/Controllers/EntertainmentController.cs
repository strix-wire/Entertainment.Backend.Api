using AutoMapper;
using Entertainment.Application.Entertainment.Commands.UpdateEntertainment;
using Entertainment.Backend.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment.Backend.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class EntertainmentController : BaseController
{
    private readonly ILogger<EntertainmentController> _logger;
    private readonly IMapper _mapper;
    public EntertainmentController(ILogger<EntertainmentController> logger,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("Test")]
    public string GetTest()
    {
        return "Service running";
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Input model: " + postDto.Value);
        UpdateEntertainmentDto updateEntertainmentDto = DeserializeObject(postDto);

        var command = _mapper.Map<UpdateEntertainmentCommand>(updateEntertainmentDto);
        await Mediator.Send(command);

        return Ok();
    }
}
