# Estrutura em Camadas

A **estrutura em camadas** é um padrão arquitetural que organiza o sistema em diferentes níveis, sendo que cada camada é responsável por um conjunto específico de tarefas. O principal objetivo dessa organização é separar as responsabilidades, facilitar a manutenção, aumentar a reutilização de código e isolar mudanças para que não afetem todo o sistema.

Cada camada normalmente só se comunica diretamente com a camada imediatamente abaixo dela, promovendo modularidade e testabilidade.

## Exemplo em C#: Aplicação Web com 3 Camadas

### 1. Camada de Apresentação (Presentation Layer)

Responsável por interagir com o usuário ou receber requisições da interface externa (por exemplo, controllers em uma API).

```csharp
// UserController.cs (Presentation Layer)
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("users")]
    public IActionResult Create(UserDto userDto)
    {
        _userService.CreateUser(userDto);
        return Ok();
    }
}
```

### 2. Camada de Negócio (Business/Service Layer)

Contém a lógica de negócio da aplicação.

```csharp
// UserService.cs (Business Layer)
public interface IUserService
{
    void CreateUser(UserDto userDto);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };
        _userRepository.Save(user);
    }
}
```

### 3. Camada de Dados (Data Access Layer)

Responsável pela comunicação com a base de dados.

```csharp
// UserRepository.cs (Data Layer)
public interface IUserRepository
{
    void Save(User user);
}

public class UserRepository : IUserRepository
{
    public void Save(User user)
    {
        // Lógica para salvar o usuário no banco de dados
    }
}
```

## Resumindo o Fluxo

- O Controller recebe a requisição e chama o Service.
- O Service executa as regras de negócio e aciona o Repository.
- O Repository acessa o banco de dados.

Este padrão facilita a manutenção, os testes e a evolução da aplicação.

---