using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.Enums;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Controllers;

[ApiController]
[FormatFilter]
[Authorize]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;
    private readonly IMapper _mapper;

    public ClientesController(IClienteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clientes")]
    [HttpGet("clientes.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clientes = await _service.GetAllAsync(cancellationToken);
        return Ok(_mapper.Map<List<ClienteResponseDto>>(clientes));
    }

    [HttpGet("clientes/{id:int}")]
    [HttpGet("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<ClienteResponseDto>(cliente));
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
        try
        {
            var entity = _mapper.Map<Cliente>(request);
            var cliente = await _service.CreateAsync(entity, cancellationToken);
            return Created($"/clientes/{cliente.Id}", _mapper.Map<ClienteResponseDto>(cliente));
        }
        catch (ServiceValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPut("clientes/{id:int}")]
    [HttpPut("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Cliente>(request);
            var cliente = await _service.UpdateAsync(id, entity, cancellationToken);
            return Ok(_mapper.Map<ClienteResponseDto>(cliente));
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

    [HttpPatch("clientes/{id:int}")]
    [HttpPatch("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Patch(int id, [FromBody] ClientePatchRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _service.PatchAsync(id, request.Nome, cancellationToken);
            return Ok(_mapper.Map<ClienteResponseDto>(cliente));
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

    [HttpDelete("clientes/{id:int}")]
    [HttpDelete("clientes/{id:int}.{format:regex(json|xml)}")]
    [Authorize(Roles = nameof(AdministradorRule.Administrador))]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _service.DeleteAsync(id, cancellationToken);
            return NoContent();
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
}
