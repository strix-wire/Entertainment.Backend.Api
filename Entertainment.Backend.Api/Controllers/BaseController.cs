using Entertainment.Backend.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Entertainment.Backend.Api.Controllers;

public class BaseController : Controller
{
    private IMediator _mediator;
    //Будет использоваться для формирования команд, выполнения запросов
    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected UpdateEntertainmentDto DeserializeObject(PostDto postDto)
    {
        UpdateEntertainmentDto mailDto;
        
        try
        {
            mailDto = JsonConvert.DeserializeObject<UpdateEntertainmentDto>(postDto.Value);

            return mailDto;
        }
        catch (JsonReaderException)
        {
            return null;
        }
    }
}
