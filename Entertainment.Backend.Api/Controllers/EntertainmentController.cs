using AutoMapper;
using Entertainment.Application.Entertainment.Commands.CreateEntertainment;
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
    public async Task<ActionResult> Update([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Update entertainment. Input model: " + postDto.Value);
        UpdateEntertainmentDto updateEntertainmentDto = DeserializeObject<UpdateEntertainmentDto>(postDto);

        var command = _mapper.Map<UpdateEntertainmentCommand>(updateEntertainmentDto);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Create entertainment. Input model: " + postDto.Value);
        CreateEntertainmentDto createEntertainmentDto = DeserializeObject<CreateEntertainmentDto>(postDto);

        var command = _mapper.Map<CreateEntertainmentCommand>(createEntertainmentDto);
        await Mediator.Send(command);

        return Ok();
    }

}
