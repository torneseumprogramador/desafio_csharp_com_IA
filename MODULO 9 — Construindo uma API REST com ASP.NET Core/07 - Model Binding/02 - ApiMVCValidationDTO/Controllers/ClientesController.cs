using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Controllers;

[ApiController]
[FormatFilter]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet("clientes")]
    [HttpGet("clientes.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clientes = await _service.GetAllAsync(cancellationToken);
        return Ok(clientes);
    }

    [HttpGet("clientes/{id:int}")]
    [HttpGet("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(cliente);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPost("clientes")]
    [HttpPost("clientes.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] ClienteRequestDto request, CancellationToken cancellationToken)
    {
        var cliente = await _service.CreateAsync(request, cancellationToken);
        return Created($"/clientes/{cliente.Id}", cliente);
    }

    [HttpPut("clientes/{id:int}")]
    [HttpPut("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _service.UpdateAsync(id, request, cancellationToken);
            return Ok(cliente);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPatch("clientes/{id:int}")]
    [HttpPatch("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Patch(int id, [FromBody] ClientePatchRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _service.PatchAsync(id, request, cancellationToken);
            return Ok(cliente);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpDelete("clientes/{id:int}")]
    [HttpDelete("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }
}
