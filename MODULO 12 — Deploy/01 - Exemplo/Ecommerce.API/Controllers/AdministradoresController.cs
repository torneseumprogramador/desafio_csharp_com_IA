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
public class AdministradoresController : ControllerBase
{
    private readonly IAdministradorService _service;
    private readonly IMapper _mapper;

    public AdministradoresController(IAdministradorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("administradores")]
    [HttpGet("administradores.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var administradores = await _service.GetAllAsync(cancellationToken);
        return Ok(_mapper.Map<List<AdministradorResponseDto>>(administradores));
    }

    [HttpGet("administradores/{id:int}")]
    [HttpGet("administradores/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var administrador = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<AdministradorResponseDto>(administrador));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPost("administradores")]
    [HttpPost("administradores.{format:regex(json|xml)}")]
    [Authorize(Roles = nameof(AdministradorRule.Administrador))]
    public async Task<IActionResult> Create(
        [FromBody] AdministradorRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Administrador>(request);
            var administrador = await _service.CreateAsync(entity, cancellationToken);
            return Created($"/administradores/{administrador.Id}", _mapper.Map<AdministradorResponseDto>(administrador));
        }
        catch (ServiceValidationException ex)
        {
            return BadRequest(new MensagemResposta { Message = ex.Message });
        }
    }

    [HttpPut("administradores/{id:int}")]
    [HttpPut("administradores/{id:int}.{format:regex(json|xml)}")]
    [Authorize(Roles = nameof(AdministradorRule.Administrador))]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] AdministradorUpdateRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Administrador>(request);
            var administrador = await _service.UpdateAsync(id, entity, cancellationToken);
            return Ok(_mapper.Map<AdministradorResponseDto>(administrador));
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

    [HttpDelete("administradores/{id:int}")]
    [HttpDelete("administradores/{id:int}.{format:regex(json|xml)}")]
    [Authorize(Roles = nameof(AdministradorRule.Administrador))]
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
