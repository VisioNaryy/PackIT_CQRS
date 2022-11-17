using Microsoft.AspNetCore.Mvc;

namespace PackIT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController: ControllerBase
{
    protected ActionResult<TResult> OkOrNoFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);
}