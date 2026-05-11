# Clean Architecture

**Clean Architecture** é uma abordagem proposta por Robert C. Martin ("Uncle Bob") que busca organizar o código em camadas concêntricas. O principal objetivo é isolar regras de negócio das demais dependências, como frameworks, interfaces de usuário e bancos de dados, garantindo assim maior desacoplamento, facilidade de teste e manutenção.

## Princípios Fundamentais

- **Independência de Framework:** O sistema não depende de frameworks; eles são apenas ferramentas.
- **Testabilidade:** As regras de negócio podem ser testadas independente de interfaces externas.
- **UI e Banco de Dados como Detalhes:** As interfaces de usuário e os bancos de dados podem ser alterados sem grandes impactos na lógica do domínio.
- **Dependências apontam para dentro:** Nada na camada externa deve conhecer detalhes da camada interna.

## Estrutura de Camadas

- **Entities (Domínio/Entidades):** Regras e objetos de negócio.
- **Use Cases (Casos de Uso):** Aplicam as regras de negócio.
- **Interface Adapters (Adaptadores):** Entrada e saída, adaptando dados entre domínio e mundo externo.
- **Frameworks & Drivers:** Frameworks, bancos de dados, UI, gateways de rede, etc.

### Diagrama Simplificado

```
| Frameworks & Drivers (UI, Banco de Dados) |
|      Interface Adapters (Controllers)     |
|          Use Cases (Serviços)             |
|            Entities (Domínio)             |
```

## Exemplo Prático em C#

### 1. Entidade

```csharp
public class User
{
    public int Id { get; }
    public string Name { get; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
```

### 2. Repositório (Abstração)

```csharp
public interface IUserRepository
{
    void Save(User user);
}
```

### 3. Caso de Uso

```csharp
public class CreateUser
{
    private readonly IUserRepository _userRepository;

    public CreateUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute(string name)
    {
        var user = new User(new Random().Next(), name); // Apenas exemplo, use ID melhor em produção.
        _userRepository.Save(user);
    }
}
```

### 4. Adaptador de Interface

```csharp
public class UserController
{
    private readonly CreateUser _createUser;

    public UserController(CreateUser createUser)
    {
        _createUser = createUser;
    }

    public void HandleRequest(string name)
    {
        _createUser.Execute(name);
        // Responder ao usuário
    }
}
```

### 5. Implementação do Repositório (Infrastructure/Driver)

```csharp
public class UserRepositoryDb : IUserRepository
{
    public void Save(User user)
    {
        // Implementação para salvar o usuário em um banco de dados, por exemplo.
    }
}
```

## Resumo

Com Clean Architecture, centralizamos as regras do negócio, tornando todo o resto — como banco de dados e interface — facilmente substituíveis e testáveis. Assim, temos projetos mais flexíveis e de fácil manutenção.

> **Referência:** [Clean Architecture Overview — Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html)