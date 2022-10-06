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

    protected T DeserializeObject<T>(PostDto postDto) where T : class
    {
        T mailDto;
        
        try
        {
            mailDto = JsonConvert.DeserializeObject<T>(postDto.Value);

            return mailDto;
        }
        catch (JsonReaderException)
        {
            return null;
        }
    }
}
