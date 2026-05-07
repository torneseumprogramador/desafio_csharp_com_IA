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
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly IMapper _mapper;

    public ProdutosController(IProdutoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("produtos")]
    [HttpGet("produtos.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var produtos = await _service.GetAllAsync(cancellationToken);
        return Ok(_mapper.Map<List<ProdutoResponseDto>>(produtos));
    }

    [HttpGet("produtos/{id:int}")]
    [HttpGet("produtos/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var produto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<ProdutoResponseDto>(produto));
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
            var entity = _mapper.Map<Produto>(request);
            var produto = await _service.CreateAsync(entity, cancellationToken);
            return Created($"/produtos/{produto.Id}", _mapper.Map<ProdutoResponseDto>(produto));
        }
        catch (ServiceValidationException ex)
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
            var entity = _mapper.Map<Produto>(request);
            var produto = await _service.UpdateAsync(id, entity, cancellationToken);
            return Ok(_mapper.Map<ProdutoResponseDto>(produto));
        }
        catch (ServiceValidationException ex)
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
