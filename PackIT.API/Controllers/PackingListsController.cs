using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Queries;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.API.Controllers;

public class PackingListsController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public PackingListsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNoFound(result);
    } 
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNoFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePackingListWithItems command)
    {
        // TODO id can be created from library on API side instead of using GUID
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
    }
    
    [HttpPut("{packingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingItem command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new {id = command.PackingListId}, null);
    }
    
    [HttpPut("{packingListId}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new {id = command.PackingListId}, null);
    }
    
    [HttpDelete("{packingListId}/items/{name}")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingItem command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new {id = command.PackingListId}, null);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingList command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
    }
    
}