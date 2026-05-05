using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.Mappers;
using primeiraApi.Models;
using primeiraApi.Repositories;

namespace primeiraApi.Controllers;

[FormatFilter]
public class ClientesController : ControllerBase
{
    private readonly IClienteRepository _repository;

    public ClientesController(IClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("clientes")]
    [HttpGet("clientes.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clientes = await _repository.GetAllAsync(cancellationToken);
        return Ok(clientes.Select(c => c.ToResponseDto()).ToList());
    }

    [HttpGet("clientes/{id:int}")]
    [HttpGet("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return Ok(cliente.ToResponseDto());
    }

    [HttpPost("clientes")]
    [HttpPost("clientes.{format:regex(json|xml)}")]
    public async Task<IActionResult> Create([FromBody] ClienteRequestDto request, CancellationToken cancellationToken)
    {
        var novoCliente = request.ToEntity();
        var cliente = await _repository.AddAsync(novoCliente, cancellationToken);
        return Created($"/clientes/{cliente.Id}", cliente.ToResponseDto());
    }

    [HttpPut("clientes/{id:int}")]
    [HttpPut("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteRequestDto request, CancellationToken cancellationToken)
    {
        var clienteExistente = await _repository.GetByIdAsync(id, cancellationToken);
        if (clienteExistente is null)
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        clienteExistente.Nome = request.Nome;
        clienteExistente.Email = request.Email;
        clienteExistente.Telefone = request.Telefone;

        await _repository.UpdateAsync(clienteExistente, cancellationToken);
        return Ok(clienteExistente.ToResponseDto());
    }

    [HttpPatch("clientes/{id:int}")]
    [HttpPatch("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Patch(int id, [FromBody] ClientePatchRequestDto request, CancellationToken cancellationToken)
    {
        var clienteExistente = await _repository.GetByIdAsync(id, cancellationToken);
        if (clienteExistente is null)
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        clienteExistente.Nome = request.Nome;

        await _repository.UpdateAsync(clienteExistente, cancellationToken);
        return Ok(clienteExistente.ToResponseDto());
    }

    [HttpDelete("clientes/{id:int}")]
    [HttpDelete("clientes/{id:int}.{format:regex(json|xml)}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return NoContent();
    }
}
