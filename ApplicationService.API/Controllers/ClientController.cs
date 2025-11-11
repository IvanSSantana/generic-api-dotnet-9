using ApplicationService.API.UseCases.Clients.GetAll;
using ApplicationService.API.UseCases.Clients.Register;
using ApplicationService.API.UseCases.Clients.Update;
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
    private readonly UpdateClientUseCase _updateClientUseCase;

    public ClientController(RegisterClientUseCase registerUseCase,
        GetAllClientsUseCase getAllClientsUseCase, UpdateClientUseCase updateClientUseCase)
    {
        _registerUseCase = registerUseCase;
        _getAllClientsUseCase = getAllClientsUseCase;
        _updateClientUseCase = updateClientUseCase;
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

    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status204NoContent)] 
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status404NotFound)] 
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status400BadRequest)] 
    [Route("{id}")]
    [HttpPut]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
    {
        _updateClientUseCase.Execute(id, request);

        return NoContent();
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