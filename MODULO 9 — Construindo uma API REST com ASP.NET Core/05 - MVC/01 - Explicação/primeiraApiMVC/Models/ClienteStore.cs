namespace primeiraApi.Models;

public class ClienteStore : IClienteStore
{
    private readonly List<Cliente> _clientes;
    private readonly object _lock = new();
    private int _proximoId;

    public ClienteStore()
    {
        _clientes =
        [
            new Cliente { Id = 1, Nome = "Ana Souza", Email = "ana@email.com", Telefone = "11999990001" },
            new Cliente { Id = 2, Nome = "Bruno Lima", Email = "bruno@email.com", Telefone = "11999990002" }
        ];
        _proximoId = _clientes.Max(c => c.Id) + 1;
    }

    public IReadOnlyList<Cliente> GetAll()
    {
        lock (_lock)
        {
            return _clientes.ToList();
        }
    }

    public Cliente? GetById(int id)
    {
        lock (_lock)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
    }

    public Cliente Add(ClienteRequest request)
    {
        lock (_lock)
        {
            var cliente = new Cliente
            {
                Id = _proximoId++,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone
            };
            _clientes.Add(cliente);
            return cliente;
        }
    }

    public bool Update(int id, ClienteRequest request)
    {
        lock (_lock)
        {
            var indice = _clientes.FindIndex(c => c.Id == id);
            if (indice == -1)
            {
                return false;
            }

            _clientes[indice] = new Cliente
            {
                Id = id,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone
            };
            return true;
        }
    }

    public bool Patch(int id, ClientePatchRequest request)
    {
        lock (_lock)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente is null)
            {
                return false;
            }

            var indice = _clientes.FindIndex(c => c.Id == id);
            _clientes[indice] = new Cliente
            {
                Id = id,
                Nome = request.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone
            };
            return true;
        }
    }

    public bool Remove(int id)
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
}
