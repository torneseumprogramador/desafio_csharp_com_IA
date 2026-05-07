# Exercicio: Separacao de Responsabilidades no Ecommerce

## Contexto

Voce recebeu uma API de Ecommerce que funciona, mas esta com responsabilidades misturadas em um unico projeto.  
Seu objetivo e aplicar os principios da aula para evoluir a arquitetura e deixar o sistema preparado para reuso.

Use como referencia o que foi feito em `01 - Exemplo`.

---

## Objetivo Geral

Refatorar a solucao para aplicar:

- Separation of Concerns (SoC)
- Repository Pattern
- Service Layer
- Reuso da camada de servicos em outro tipo de aplicacao (Console)

---

## Cenario do Exercicio

Voce deve transformar o sistema em uma estrutura com projetos separados:

- `Ecommerce.API` (apresentacao HTTP)
- `Ecommerce.Services` (regras de negocio)
- `Ecommerce.Repositories` (acesso a dados)
- `Ecommerce.Console` (cliente de linha de comando reutilizando services)

---

## Requisitos Obrigatorios

### 1) Separacao por camadas e projetos

- Criar projetos `.csproj` separados para API, Services e Repositories.
- Garantir referencias corretas entre projetos:
  - API -> Services e Repositories
  - Services -> Repositories
  - Console -> Services e Repositories
- Remover acoplamentos indevidos entre camadas.

### 2) Repository Pattern

- Manter interfaces de repositorio (`IClienteRepository`, `IProdutoRepository`, `IPedidoRepository`).
- Implementar duas estrategias:
  - Memory
  - MySql
- A escolha deve ser feita por configuracao (`Repository:Provider`).

### 3) Service Layer

- Toda regra de negocio deve estar na camada `Ecommerce.Services`.
- Services devem lancar excecoes customizadas para:
  - recurso nao encontrado
  - validacao de negocio
- Controllers e Console apenas consomem os services.

### 4) Validacoes

- Na API: validacao automatica com DataAnnotations + `[ApiController]`.
- No Service Layer: validacoes de negocio (defesa de dominio), independente do transporte.
- Nao depender apenas da validacao HTTP.

### 5) DTOs e ModelViews no lugar correto

- DTOs e ModelViews pertencem a camada de apresentacao (API), nao aos Services.
- Service Layer deve trabalhar com modelos de dominio (`Cliente`, `Produto`, `Pedido`).

### 6) Configuracao por appsettings

- API e Console devem ler configuracoes de `appsettings.json`.
- Ambos devem usar:
  - `ConnectionStrings:DefaultConnection`
  - `Repository:Provider`

### 7) Aplicacao Console com CRUD interativo

- Criar menu principal com:
  - CRUD de Clientes
  - CRUD de Produtos
  - CRUD de Pedidos
- Organizar a Console em arquivos por responsabilidade (ex.: `Application`, `CompositionRoot`, `Features`).

### 8) Banco de dados e migration

- Garantir que as migrations estejam aplicadas no banco correto (ex.: `primeira_api_mvc_dev`).
- Se houver mudanca de modelo, criar e aplicar migration.

---

## Estrutura Esperada (exemplo)

```text
01 - Exemplo/
  Ecommerce.API/
  Ecommerce.Services/
  Ecommerce.Repositories/
  Ecommerce.Console/
```

Voce pode adaptar nomes/pastas, desde que a separacao de responsabilidades fique clara.

---

## Criterios de Aceite

Considere concluido quando:

- [ ] API compila e executa
- [ ] Console compila e executa
- [ ] CRUDs principais funcionando na API
- [ ] CRUDs principais funcionando no Console
- [ ] Services reutilizados pela API e pelo Console
- [ ] Excecoes customizadas implementadas e tratadas
- [ ] Validacoes em DTO + Service Layer funcionando
- [ ] Configuracao via appsettings funcionando

---

## Entregaveis

- Codigo refatorado
- Estrutura de projetos separada
- Migrations atualizadas
- Evidencias de execucao:
  - `dotnet build` dos projetos
  - prints/logs de uso da API e Console

---

## Bonus (desafio extra)

- Criar middleware global de excecoes na API (para reduzir `try/catch` repetido).
- Adicionar testes unitarios para Service Layer.
- Criar `.sln` organizado com todos os projetos.
- Implementar um `Worker` reutilizando `Ecommerce.Services`.

---

## Dica final

Sempre pergunte: **"essa responsabilidade pertence a esta camada?"**  
Se a resposta for "nao", mova para a camada correta.
