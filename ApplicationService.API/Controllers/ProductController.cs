using ApplicationService.API.UseCases.Products.Register;
using ApplicationService.Communication.Requests;
using ApplicationService.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly RegisterProductUseCase _registerUseCase;

    public ProductController(RegisterProductUseCase registerUseCase)
    {
        _registerUseCase = registerUseCase;
    }

    [HttpPost]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
    {
        var response = _registerUseCase.Execute(clientId, request);

        return Created(string.Empty, response);
    }
}