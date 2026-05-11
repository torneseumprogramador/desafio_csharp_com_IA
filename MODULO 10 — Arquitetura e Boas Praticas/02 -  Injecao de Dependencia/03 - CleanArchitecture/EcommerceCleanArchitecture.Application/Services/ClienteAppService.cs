using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Application.Abstractions.Services;
using EcommerceCleanArchitecture.Application.DTOs.Clientes;
using EcommerceCleanArchitecture.Application.Exceptions;
using EcommerceCleanArchitecture.Domain.Entities;
using System.Text.RegularExpressions;

namespace EcommerceCleanArchitecture.Application.Services;

public class ClienteAppService : IClienteAppService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteAppService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IReadOnlyList<ClienteResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await _clienteRepository.GetAllAsync(cancellationToken);
        return clientes.Select(c => c.ToResponse()).ToList();
    }

    public async Task<ClienteResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Cliente não encontrado.");

        return cliente.ToResponse();
    }

    public async Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);

        var novoCliente = new Cliente
        {
            Nome = request.Nome.Trim(),
            Email = request.Email.Trim(),
            Telefone = request.Telefone.Trim(),
            Cpf = request.Cpf.Trim()
        };

        var salvo = await _clienteRepository.AddAsync(novoCliente, cancellationToken);
        return salvo.ToResponse();
    }

    public async Task<ClienteResponseDto> UpdateAsync(int id, ClienteRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);

        var existente = await _clienteRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Cliente não encontrado.");

        existente.Nome = request.Nome.Trim();
        existente.Email = request.Email.Trim();
        existente.Telefone = request.Telefone.Trim();
        existente.Cpf = request.Cpf.Trim();

        await _clienteRepository.UpdateAsync(existente, cancellationToken);
        return existente.ToResponse();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var removido = await _clienteRepository.DeleteAsync(id, cancellationToken);
        if (!removido)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
    }

    private static void ValidateRequest(ClienteRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new ValidationException("Nome do cliente é obrigatório.");
        }

        var nome = request.Nome.Trim();
        if (nome.Length < 3 || nome.Length > 120)
        {
            throw new ValidationException("Nome do cliente deve ter entre 3 e 120 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ValidationException("Email do cliente é obrigatório.");
        }

        var email = request.Email.Trim();
        if (email.Length > 160 || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ValidationException("Email do cliente é inválido.");
        }

        if (string.IsNullOrWhiteSpace(request.Telefone))
        {
            throw new ValidationException("Telefone do cliente é obrigatório.");
        }

        var telefoneNumerico = new string(request.Telefone.Where(char.IsDigit).ToArray());
        if (telefoneNumerico.Length is < 10 or > 11)
        {
            throw new ValidationException("Telefone do cliente deve ter 10 ou 11 dígitos.");
        }

        if (string.IsNullOrWhiteSpace(request.Cpf))
        {
            throw new ValidationException("CPF do cliente é obrigatório.");
        }

        var cpfNumerico = new string(request.Cpf.Where(char.IsDigit).ToArray());
        if (cpfNumerico.Length != 11)
        {
            throw new ValidationException("CPF do cliente deve ter 11 dígitos.");
        }
    }
}
