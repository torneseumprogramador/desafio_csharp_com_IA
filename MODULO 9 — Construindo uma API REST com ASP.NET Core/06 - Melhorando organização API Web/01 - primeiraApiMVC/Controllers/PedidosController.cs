using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.Mappers;
using primeiraApi.Models;
using primeiraApi.Repositories;

namespace primeiraApi.Controllers;

[FormatFilter]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidosController(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet("pedidos")]
    [HttpGet("pedidos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pedidos = await _pedidoRepository.GetAllAsync(cancellationToken);
        return Ok(pedidos.Select(p => p.ToResponseDto()).ToList());
    }

    [HttpGet("pedidos/{id:int}")]
    [HttpGet("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id, cancellationToken);
        if (pedido is null)
        {
            return NotFound(new MensagemResposta { Message = "Pedido não encontrado" });
        }

        return Ok(pedido.ToResponseDto());
    }

    [HttpPost("pedidos")]
    [HttpPost("pedidos.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] PedidoRequestDto request, CancellationToken cancellationToken)
    {
        if (request.ClienteId <= 0)
        {
            return BadRequest(new MensagemResposta { Message = "ClienteId deve ser informado" });
        }

        if (request.Itens.Count == 0)
        {
            return BadRequest(new MensagemResposta { Message = "Pedido deve ter pelo menos um item" });
        }

        var pedido = new Pedido
        {
            ClienteId = request.ClienteId,
            CriadoEm = DateTime.UtcNow,
            Observacao = request.Observacao,
            Itens = request.Itens.Select(i => new PedidoProduto
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }).ToList()
        };

        Pedido criado;
        try
        {
            criado = await _pedidoRepository.AddAsync(pedido, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        return Created($"/pedidos/{criado.Id}", criado.ToResponseDto());
    }

    [HttpPut("pedidos/{id:int}")]
    [HttpPut("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] PedidoRequestDto request, CancellationToken cancellationToken)
    {
        var existente = await _pedidoRepository.GetByIdAsync(id, cancellationToken);
        if (existente is null)
        {
            return NotFound(new MensagemResposta { Message = "Pedido não encontrado" });
        }

        if (request.ClienteId <= 0)
        {
            return BadRequest(new MensagemResposta { Message = "ClienteId deve ser informado" });
        }

        existente.ClienteId = request.ClienteId;
        existente.Observacao = request.Observacao;
        existente.Itens = request.Itens.Select(i => new PedidoProduto
        {
            PedidoId = id,
            ProdutoId = i.ProdutoId,
            Quantidade = i.Quantidade
        }).ToList();

        try
        {
            await _pedidoRepository.UpdateAsync(existente, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        var atualizado = await _pedidoRepository.GetByIdAsync(id, cancellationToken);
        return Ok(atualizado?.ToResponseDto());
    }

    [HttpDelete("pedidos/{id:int}")]
    [HttpDelete("pedidos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        if (!await _pedidoRepository.RemoveAsync(id, cancellationToken))
        {
            return NotFound(new MensagemResposta { Message = "Pedido não encontrado" });
        }

        return NoContent();
    }
}
