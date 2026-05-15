O Repository Pattern, ou Padrão de Repositório, é um padrão de design muito utilizado em aplicações C# para abstrair a lógica de acesso a dados. Seu principal objetivo é separar a lógica que recupera e manipula dados do restante da aplicação, promovendo uma camada intermediária entre a camada de negócio (serviços) e a fonte de dados (banco de dados, API, arquivo, etc).

No C#, normalmente é implementado através de interfaces e classes concretas que encapsulam as operações de persistência (CRUD: Create, Read, Update, Delete) para entidades específicas do domínio.

**Principais vantagens:**
- **Encapsulamento do acesso a dados:** Permite trocar a fonte de dados com mínimo impacto na aplicação.
- **Facilita testes unitários:** Possibilita a substituição por mocks em cenários de teste.
- **Centraliza regras de acesso:** Garante que a lógica relacionada ao armazenamento/resgate dos dados fique em um único lugar.

**Exemplo simplificado de Repository Pattern em C#:**

```csharp
// Interface de repositório genérico
public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Delete(int id);
}

// Implementação em memória
public class ClienteRepository : IRepository<Cliente>
{
    private readonly List<Cliente> _clientes = new();

    public void Add(Cliente entity) => _clientes.Add(entity);

    public Cliente GetById(int id) => _clientes.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Cliente> GetAll() => _clientes;

    public void Update(Cliente entity)
    {
        var index = _clientes.FindIndex(c => c.Id == entity.Id);
        if (index >= 0)
            _clientes[index] = entity;
    }

    public void Delete(int id)
    {
        var cliente = GetById(id);
        if (cliente != null)
            _clientes.Remove(cliente);
    }
}
```

No exemplo acima, a interface `IRepository<T>` define as operações básicas. A classe `ClienteRepository` implementa as operações para um repositório em memória, mas poderia facilmente se conectar a um banco de dados, bastando trocar sua implementação concreta, sem impactar a lógica de negócio da aplicação.