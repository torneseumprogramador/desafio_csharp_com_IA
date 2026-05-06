using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Controllers;

[FormatFilter]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet("produtos")]
    [HttpGet("produtos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var produtos = await _service.GetAllAsync(cancellationToken);
        return Ok(produtos);
    }

    [HttpGet("produtos/{id:int}")]
    [HttpGet("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var produto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(produto);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPost("produtos")]
    [HttpPost("produtos.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] ProdutoRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var produto = await _service.CreateAsync(request, cancellationToken);
            return Created($"/produtos/{produto.Id}", produto);
        }
        catch (DomainValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPut("produtos/{id:int}")]
    [HttpPut("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var produto = await _service.UpdateAsync(id, request, cancellationToken);
            return Ok(produto);
        }
        catch (DomainValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpDelete("produtos/{id:int}")]
    [HttpDelete("produtos/{id:int}.{format:regex(json|xml)}")]
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
