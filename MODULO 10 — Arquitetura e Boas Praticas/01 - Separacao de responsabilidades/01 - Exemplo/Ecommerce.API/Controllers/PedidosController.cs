using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Controllers;

[ApiController]
[FormatFilter]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _service;
    private readonly IMapper _mapper;

    public PedidosController(IPedidoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("pedidos")]
    [HttpGet("pedidos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pedidos = await _service.GetAllAsync(cancellationToken);
        return Ok(_mapper.Map<List<PedidoResponseDto>>(pedidos));
    }

    [HttpGet("pedidos/{id:int}")]
    [HttpGet("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var pedido = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<PedidoResponseDto>(pedido));
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
            var entity = new Pedido
            {
                ClienteId = request.ClienteId,
                Observacao = request.Observacao,
                CriadoEm = DateTime.UtcNow,
                Itens = _mapper.Map<List<PedidoProduto>>(request.Itens)
            };
            var criado = await _service.CreateAsync(entity, cancellationToken);
            return Created($"/pedidos/{criado.Id}", _mapper.Map<PedidoResponseDto>(criado));
        }
        catch (ServiceValidationException ex)
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
            var entity = new Pedido
            {
                ClienteId = request.ClienteId,
                Observacao = request.Observacao,
                Itens = _mapper.Map<List<PedidoProduto>>(request.Itens)
            };
            var atualizado = await _service.UpdateAsync(id, entity, cancellationToken);
            return Ok(_mapper.Map<PedidoResponseDto>(atualizado));
        }
        catch (ServiceValidationException ex)
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
