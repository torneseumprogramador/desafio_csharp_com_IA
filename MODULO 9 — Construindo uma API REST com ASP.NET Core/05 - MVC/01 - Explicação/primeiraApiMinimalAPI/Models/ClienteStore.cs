namespace primeiraApi.Models;

/// <summary>Armazenamento em memória dos clientes (substituível por persistência real).</summary>
public class ClienteStore
{
    private readonly List<Cliente> _clientes;
    private readonly object _lock = new();
    private int _proximoId;

    public ClienteStore()
    {
        _clientes =
        [
            new Cliente(1, "Ana Souza", "ana@email.com", "11999990001"),
            new Cliente(2, "Bruno Lima", "bruno@email.com", "11999990002")
        ];
        _proximoId = _clientes.Max(c => c.Id) + 1;
    }

    public IReadOnlyList<Cliente> ObterTodos()
    {
        lock (_lock)
        {
            return _clientes.ToList();
        }
    }

    public Cliente? ObterPorId(int id)
    {
        lock (_lock)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
    }

    public Cliente Adicionar(ClienteRequest request)
    {
        lock (_lock)
        {
            var cliente = new Cliente(_proximoId++, request.Nome, request.Email, request.Telefone);
            _clientes.Add(cliente);
            return cliente;
        }
    }

    public bool Atualizar(int id, ClienteRequest request)
    {
        lock (_lock)
        {
            var indice = _clientes.FindIndex(c => c.Id == id);
            if (indice == -1)
            {
                return false;
            }

            _clientes[indice] = new Cliente(id, request.Nome, request.Email, request.Telefone);
            return true;
        }
    }

    public bool AtualizarParcial(int id, ClientePatchRequest request)
    {
        lock (_lock)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente is null)
            {
                return false;
            }

            var indice = _clientes.FindIndex(c => c.Id == id);
            _clientes[indice] = new Cliente(id, request.Nome, cliente.Email, cliente.Telefone);
            return true;
        }
    }

    public bool Remover(int id)
    {
        lock (_lock)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente is null)
            {
                return false;
            }

            _clientes.Remove(cliente);
            return true;
        }
    }

    public Cliente? ObterPorIdAposAtualizacao(int id)
    {
        lock (_lock)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
    }
}
