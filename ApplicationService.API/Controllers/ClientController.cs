using ApplicationService.API.UseCases.Clients.GetAll;
using ApplicationService.API.UseCases.Clients.Register;
using ApplicationService.Communication.Requests;
using ApplicationService.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly RegisterClientUseCase _registerUseCase;
    private readonly GetAllClientsUseCase _getAllClientsUseCase;

    public ClientController(RegisterClientUseCase registerUseCase,
        GetAllClientsUseCase getAllClientsUseCase)
    {
        _registerUseCase = registerUseCase;
        _getAllClientsUseCase = getAllClientsUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status500InternalServerError)]  
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        var response = _registerUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = _getAllClientsUseCase.Execute();

        if (response.Clients.Count == 0)
        {
            return NoContent();
        }

        return Ok(response);
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