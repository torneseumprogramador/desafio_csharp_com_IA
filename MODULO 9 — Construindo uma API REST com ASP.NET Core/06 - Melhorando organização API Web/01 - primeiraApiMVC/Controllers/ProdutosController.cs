using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.Mappers;
using primeiraApi.Models;
using primeiraApi.Repositories;

namespace primeiraApi.Controllers;

[FormatFilter]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _repository;

    public ProdutosController(IProdutoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("produtos")]
    [HttpGet("produtos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var produtos = await _repository.GetAllAsync(cancellationToken);
        return Ok(produtos.Select(p => p.ToResponseDto()).ToList());
    }

    [HttpGet("produtos/{id:int}")]
    [HttpGet("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var produto = await _repository.GetByIdAsync(id, cancellationToken);
        if (produto is null)
        {
            return NotFound(new MensagemResposta { Message = "Produto não encontrado" });
        }

        return Ok(produto.ToResponseDto());
    }

    [HttpPost("produtos")]
    [HttpPost("produtos.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] ProdutoRequestDto request, CancellationToken cancellationToken)
    {
        var produto = await _repository.AddAsync(request.ToEntity(), cancellationToken);
        return Created($"/produtos/{produto.Id}", produto.ToResponseDto());
    }

    [HttpPut("produtos/{id:int}")]
    [HttpPut("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoRequestDto request, CancellationToken cancellationToken)
    {
        var existente = await _repository.GetByIdAsync(id, cancellationToken);
        if (existente is null)
        {
            return NotFound(new MensagemResposta { Message = "Produto não encontrado" });
        }

        existente.Nome = request.Nome;
        existente.Preco = request.Preco;
        existente.Estoque = request.Estoque;

        await _repository.UpdateAsync(existente, cancellationToken);
        return Ok(existente.ToResponseDto());
    }

    [HttpDelete("produtos/{id:int}")]
    [HttpDelete("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            return NotFound(new MensagemResposta { Message = "Produto não encontrado" });
        }

        return NoContent();
    }
}
