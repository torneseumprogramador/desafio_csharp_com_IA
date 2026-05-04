using Microsoft.AspNetCore.Mvc;
using primeiraApi.Models;

namespace primeiraApi.Controllers;

[FormatFilter]
public class ClientesController : ControllerBase
{
    private readonly IClienteStore _store;

    public ClientesController(IClienteStore store)
    {
        _store = store;
    }

    [HttpGet("clientes")]
    [HttpGet("clientes.{format:regex(json|xml)}")]
    public IActionResult GetAll()
    {
        return Ok(_store.GetAll());
    }

    [HttpGet("clientes/{id:int}")]
    [HttpGet("clientes/{id:int}.{format:regex(json|xml)}")]
    public IActionResult GetById(int id)
    {
        var cliente = _store.GetById(id);
        if (cliente is null)
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return Ok(cliente);
    }

    [HttpPost("clientes")]
    [HttpPost("clientes.{format:regex(json|xml)}")]
    public IActionResult Create([FromBody] ClienteRequest request)
    {
        var cliente = _store.Add(request);
        return Created($"/clientes/{cliente.Id}", cliente);
    }

    [HttpPut("clientes/{id:int}")]
    [HttpPut("clientes/{id:int}.{format:regex(json|xml)}")]
    public IActionResult Update(int id, [FromBody] ClienteRequest request)
    {
        if (!_store.Update(id, request))
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return Ok(_store.GetById(id));
    }

    [HttpPatch("clientes/{id:int}")]
    [HttpPatch("clientes/{id:int}.{format:regex(json|xml)}")]
    public IActionResult Patch(int id, [FromBody] ClientePatchRequest request)
    {
        if (!_store.Patch(id, request))
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return Ok(_store.GetById(id));
    }

    [HttpDelete("clientes/{id:int}")]
    [HttpDelete("clientes/{id:int}.{format:regex(json|xml)}")]
    public IActionResult Delete(int id)
    {
        if (!_store.Remove(id))
        {
            return NotFound(new MensagemResposta { Message = "Cliente não encontrado" });
        }

        return NoContent();
    }
}
