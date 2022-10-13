using AutoMapper;
using Entertainment.Application.Entertainment.Commands.CreateEntertainment;
using Entertainment.Application.Entertainment.Commands.DeleteEntertainment;
using Entertainment.Application.Entertainment.Commands.UpdateEntertainment;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentDetails;
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

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Create([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Create entertainment. Input model: " + postDto.Value);
        CreateEntertainmentDto createEntertainmentDto = DeserializeObject<CreateEntertainmentDto>(postDto);

        var command = _mapper.Map<CreateEntertainmentCommand>(createEntertainmentDto);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Get entertainment. Input model: " + postDto.Value);
        GetEntertainmentDto getEntertainmentDto = DeserializeObject<GetEntertainmentDto>(postDto);

        var query = new EntertainmentDetailsQuery
        {
            Id = getEntertainmentDto.Id
        };
        var vm = await Mediator.Send(query);

        return Ok(vm);
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

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Delete entertainment. Input model: " + postDto.Value);
        DeleteEntertainmentDto deleteEntertainmentDto = DeserializeObject<DeleteEntertainmentDto>(postDto);

        var command = new DeleteEntertainmentCommand
        {
            Id = deleteEntertainmentDto.Id
        };
        await Mediator.Send(command);

        return Ok();
    }

    [HttpGet("Test")]
    public string GetTest()
    {
        return "Service running";
    }
}
