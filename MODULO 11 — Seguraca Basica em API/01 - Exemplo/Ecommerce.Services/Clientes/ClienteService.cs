using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Cliente> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        return cliente;
    }

    public Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        ValidateCliente(cliente);
        return _repository.AddAsync(cliente, cancellationToken);
    }

    public async Task<Cliente> UpdateAsync(int id, Cliente clienteAtualizado, CancellationToken cancellationToken = default)
    {
        ValidateCliente(clienteAtualizado);

        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;
        cliente.Cpf = clienteAtualizado.Cpf;

        await _repository.UpdateAsync(cliente, cancellationToken);
        return cliente;
    }

    public async Task<Cliente> PatchAsync(int id, string nome, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ServiceValidationException("Nome do cliente é obrigatório.");
        }

        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        cliente.Nome = nome;
        await _repository.UpdateAsync(cliente, cancellationToken);
        return cliente;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        if (await _repository.HasPedidosAsync(id, cancellationToken))
        {
            throw new ServiceValidationException("Não é possível excluir o cliente porque ele possui pedidos vinculados.");
        }

        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }
    }

    private static void ValidateCliente(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new ServiceValidationException("Nome do cliente é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains('@'))
        {
            throw new ServiceValidationException("Email do cliente é inválido.");
        }

        if (string.IsNullOrWhiteSpace(cliente.Telefone))
        {
            throw new ServiceValidationException("Telefone do cliente é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(cliente.Cpf.Value))
        {
            throw new ServiceValidationException("CPF do cliente é obrigatório.");
        }
    }
}
