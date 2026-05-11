# Exercicios - Injecao de Dependencia e Clean Architecture

Este material foi preparado para praticar os conceitos vistos na aula:

- Injecao de Dependencia (DI)
- Separacao de responsabilidades por camadas
- Clean Architecture (Domain, Application, Infrastructure, Presentation)
- EF Core com MySQL
- Migrations e Seed de dados
- Fluent API com `IEntityTypeConfiguration`
- Validacoes na camada de Application
- Swagger e organizacao de rotas

## Objetivo

Construir uma API de ecommerce com as entidades:

- Cliente
- Produto
- Pedido
- PedidoProduto

Seguindo o principio de dependencia apontando sempre para dentro (camadas externas dependem das internas).

---

## Estrutura esperada da solucao

Crie uma solucao com pelo menos os projetos abaixo:

1. `SeuProjeto.Domain` (classlib)
2. `SeuProjeto.Application` (classlib)
3. `SeuProjeto.Infrastructure` (classlib)
4. `SeuProjeto.WebApi` (ASP.NET Core Web API)

### Regras de referencia entre projetos

- `Application` referencia `Domain`
- `Infrastructure` referencia `Application` e `Domain`
- `WebApi` referencia `Application` e `Infrastructure`
- `Domain` nao referencia nenhum outro projeto da solucao

---

## Exercicios

## Exercicio 1 - Entidades de Dominio

No projeto `Domain`, crie as entidades com relacionamentos:

- `Cliente`
- `Produto`
- `Pedido`
- `PedidoProduto` (entidade de associacao)

### Criterios de aceite

- `Pedido` deve possuir `ClienteId` e colecao de itens
- `PedidoProduto` deve possuir chave composta (`PedidoId`, `ProdutoId`)
- Entidades nao devem depender de EF, controllers ou DTOs

---

## Exercicio 2 - Casos de Uso e Contratos

No projeto `Application`, crie:

- DTOs de request/response
- Interfaces de repositorio (abstracoes de persistencia)
- Servicos de aplicacao (`ClienteAppService`, `ProdutoAppService`, `PedidoAppService`)
- Excecoes de negocio (`ValidationException`, `NotFoundException`)

### Criterios de aceite

- Validacoes de entrada devem ficar na camada `Application`
- Servicos nao devem depender de `DbContext`
- Regras obrigatorias:
  - Nome nao pode ser vazio
  - Email valido
  - Preco maior que zero
  - Pedido com ao menos um item
  - Quantidade de item maior que zero

---

## Exercicio 3 - Persistencia com EF Core + MySQL

No projeto `Infrastructure`, implemente:

- `AppDbContext`
- Repositorios concretos para cliente, produto e pedido
- Configuracao de DI para registrar `DbContext` e repositorios

### Criterios de aceite

- Conexao via `ConnectionStrings:DefaultConnection`
- Uso de `Pomelo.EntityFrameworkCore.MySql`
- Nao usar banco em memoria neste exercicio

---

## Exercicio 4 - Fluent API Separada

Separe o mapeamento em classes:

- `ClienteConfiguration`
- `ProdutoConfiguration`
- `PedidoConfiguration`
- `PedidoProdutoConfiguration`

Cada classe deve implementar `IEntityTypeConfiguration<T>`.

### Criterios de aceite

- `AppDbContext` deve usar `ApplyConfigurationsFromAssembly`
- Definir relacionamentos e chaves na Fluent API
- Definir constraints de coluna (`IsRequired`, `HasMaxLength`, etc.)

---

## Exercicio 5 - Migrations e Seed

Crie migrations para:

1. Estrutura inicial do banco
2. Seed de dados iniciais

### Criterios de aceite

- Pelo menos:
  - 2 clientes
  - 3 produtos
  - 2 pedidos
  - Itens vinculados em `PedidoProduto`
- Comando `dotnet ef database update` deve executar sem erro

---

## Exercicio 6 - WebApi e Swagger

No projeto `WebApi`, configure:

- Controllers para `Clientes`, `Produtos`, `Pedidos`
- Middleware para tratamento global de excecao
- Swagger UI
- Controller `Home` com rota para orientar acesso a documentacao

### Criterios de aceite

- Endpoint `/home` retornando mensagem com caminho da documentacao
- Swagger acessivel em `/swagger`
- Controllers sem `try/catch` repetitivo (usar middleware)

---

## Exercicio 7 - Desafio de Arquitetura (Extra)

Refatore para melhorar manutencao:

- Criar validadores dedicados (`ClienteValidator`, etc.)
- Criar testes unitarios da camada `Application`
- Garantir que `Domain` nao conhece EF/Core

### Bonus

- Implementar pagina de status de seed (contagem de registros por tabela)
- Adicionar endpoint de health check

---

## Checklist de entrega do aluno

- [ ] Solucao compila com `dotnet build`
- [ ] Migrations criadas e aplicadas
- [ ] Swagger funcionando
- [ ] Rotas CRUD funcionando para as 3 entidades principais
- [ ] Validacoes de negocio implementadas
- [ ] Fluent API separada em classes
- [ ] Seed inicial aplicado no banco

---

## Comandos uteis

```bash
dotnet build
dotnet ef migrations add InitialMySql --project SeuProjeto.Infrastructure --startup-project SeuProjeto.WebApi
dotnet ef database update --project SeuProjeto.Infrastructure --startup-project SeuProjeto.WebApi
dotnet run --project SeuProjeto.WebApi
```

---

## Observacoes finais

- Mantenha o foco em organizacao e responsabilidade de cada camada.
- Evite "atalhos" que quebrem o objetivo arquitetural do exercicio.
- O codigo deve estar simples, legivel e coerente com Clean Architecture.
