using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Controllers;

[FormatFilter]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _service;

    public PedidosController(IPedidoService service)
    {
        _service = service;
    }

    [HttpGet("pedidos")]
    [HttpGet("pedidos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pedidos = await _service.GetAllAsync(cancellationToken);
        return Ok(pedidos);
    }

    [HttpGet("pedidos/{id:int}")]
    [HttpGet("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var pedido = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(pedido);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPost("pedidos")]
    [HttpPost("pedidos.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] PedidoRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var criado = await _service.CreateAsync(request, cancellationToken);
            return Created($"/pedidos/{criado.Id}", criado);
        }
        catch (DomainValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPut("pedidos/{id:int}")]
    [HttpPut("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] PedidoRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var atualizado = await _service.UpdateAsync(id, request, cancellationToken);
            return Ok(atualizado);
        }
        catch (DomainValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpDelete("pedidos/{id:int}")]
    [HttpDelete("pedidos/{id:int}.{format:regex(json|xml)}")]
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
