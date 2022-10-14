using AutoMapper;
using Entertainment.Application.Entertainment.Commands.CreateEntertainment;
using Entertainment.Application.Entertainment.Commands.DeleteEntertainment;
using Entertainment.Application.Entertainment.Commands.UpdateEntertainment;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentDetails;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice;
using Entertainment.Backend.Api.Models;
using Entertainment.Domain;
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

    /// <summary>
    /// Get list entertainment by type,
    /// area, price
    /// </summary>
    /// <param name="postDto"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetEntertainmentListByTypeAndAreaAndPrice")]
    public async Task<ActionResult> GetEntertainmentListByTypeAndAreaAndPrice(
         [FromQuery] Area area, [FromQuery] double price, [FromQuery] TypeEntertainment typeEnt)
    {
        _logger.LogInformation("Get list entertainment. Input model: " + area + price + typeEnt);
        
        var query = new EntertainmentListQueryByTypeAndAreaAndPrice()
        {
            Area = area,
            Price = price,
            TypeEntertainment = typeEnt
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
