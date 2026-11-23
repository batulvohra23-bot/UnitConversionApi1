using Microsoft.AspNetCore.Mvc;
using UnitConversionApi1.Api.Models;
using UnitConversionApi1.Api.Services;

namespace UnitConversionApi1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly IConversionService _service;

    public ConversionController(
        IConversionService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Convert(
        ConversionRequest request)
    {
        return Ok(_service.Convert(request));
    }
}
