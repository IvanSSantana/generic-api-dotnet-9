using ApplicationService.API.UseCases.Clients.Register;
using ApplicationService.Communication.Requests;
using ApplicationService.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        RegisterClientUseCase useCase = new();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
        
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}