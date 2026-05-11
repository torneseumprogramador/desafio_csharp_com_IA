# Injeção de Dependência

A **injeção de dependência** é um padrão de desenvolvimento utilizado para tornar o sistema mais modular e flexível, reduzindo o acoplamento entre classes. Em vez de uma classe criar diretamente suas dependências, elas são fornecidas ("injetadas") de fora, normalmente pelo construtor, por um método, ou por um container de injeção de dependências.

## O que é?

Quando um objeto precisa de outro para trabalhar, dizemos que ele possui uma dependência. Se o próprio objeto cria essa dependência internamente, o código fica rigidamente acoplado e mais difícil de testar ou modificar. Com a Injeção de Dependência, essas dependências são fornecidas externamente, facilitando a troca, o teste e a manutenção dos componentes.

## Benefícios

- **Baixo acoplamento**: Componentes conhecem apenas interfaces, não implementações concretas.
- **Facilidade para testes**: É possível substituir dependências por mocks ou fakes durante testes.
- **Reutilização e manutenção**: Trocar implementações de dependências é simples.

## Exemplos em C#

### Exemplo 1: Sem Injeção de Dependência

```csharp
public class EmailService
{
    public void Send(string message)
    {
        // código para enviar email
    }
}

public class UserCadastro
{
    private EmailService emailService = new EmailService();

    public void CadastrarUsuario(string usuario)
    {
        // lógica de cadastro
        emailService.Send("Bem-vindo, " + usuario);
    }
}
```

Neste caso, `UserCadastro` está fortemente acoplado à implementação de `EmailService`.

---

### Exemplo 2: Com Injeção de Dependência via Construtor

```csharp
public interface IEmailService
{
    void Send(string message);
}

public class EmailService : IEmailService
{
    public void Send(string message)
    {
        // código para enviar email
    }
}

public class UserCadastro
{
    private readonly IEmailService _emailService;

    public UserCadastro(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void CadastrarUsuario(string usuario)
    {
        // lógica de cadastro
        _emailService.Send("Bem-vindo, " + usuario);
    }
}
```

Agora, `UserCadastro` depende apenas de uma interface, e qualquer implementação de `IEmailService` pode ser injetada - facilitando troca, testes e manutenção.

---

### Exemplo 3: Registrando Dependências em ASP.NET Core

Em frameworks como o ASP.NET Core, a injeção de dependência é configurada automaticamente por meio de containers:

```csharp
// Startup.cs ou Program.cs
services.AddTransient<IEmailService, EmailService>();
services.AddTransient<UserCadastro>();
```

O framework irá injetar automaticamente a implementação correta quando `UserCadastro` for solicitado.

---

Com a injeção de dependência, seu código se torna mais limpo, testável e flexível, seguindo boas práticas de arquitetura de software.