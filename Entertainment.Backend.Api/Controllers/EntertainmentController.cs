using AutoMapper;
using Entertainment.Application.Entertainment.Commands.CreateEntertainment;
using Entertainment.Application.Entertainment.Commands.DeleteEntertainment;
using Entertainment.Application.Entertainment.Commands.UpdateEntertainment;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentDetails;
using Entertainment.Application.Entertainment.Queries.GetEntertainmentListByTypeAndAreaAndPrice;
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
    public async Task<ActionResult> Create([FromBody] CreateEntertainmentDto dto)
    {
        _logger.LogInformation("Create entertainment. Input model: " + dto);

        var command = _mapper.Map<CreateEntertainmentCommand>(dto);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    [Route("DetailsEntertainment")]
    public async Task<ActionResult> Get([FromQuery] GetEntertainmentDto dto)
    {
        _logger.LogInformation("Get entertainment. Input model: " + dto);

        var query = new EntertainmentDetailsQuery
        {
            Id = dto.Id
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
         [FromQuery] GetEntertainmentListByTypeAndAreaAndPriceDto dto)
    {
        _logger.LogInformation("Get list entertainment. Input model: " + dto);
        
        var query = new EntertainmentListQueryByTypeAndAreaAndPrice()
        {
            Area = dto.Area,
            Price = dto.Price,
            TypeEntertainment = dto.TypeEntertainment
        };
        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult> Update([FromBody] UpdateEntertainmentDto dto)
    {
        _logger.LogInformation("Update entertainment. Input model: " + dto);

        var command = _mapper.Map<UpdateEntertainmentCommand>(dto);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteEntertainmentDto dto)
    {
        _logger.LogInformation("Delete entertainment. Input model: " + dto);

        var command = new DeleteEntertainmentCommand
        {
            Id = dto.Id
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
