# Exercicios - Entity Framework Core com MySQL

## Exercicio 1 - Modelagem e relacionamento 1:1

### Objetivo
Criar duas tabelas separadas (`Clientes` e `Enderecos`) com relacionamento 1:1 usando EF Core.

### Requisitos
- Criar um projeto console .NET.
- Criar a pasta `Models` com as entidades:
  - `Cliente`: `Id`, `Nome`, `Telefone`, `Endereco`
  - `Endereco`: `Id`, `ClienteId`, `Logradouro`, `Numero`, `Complemento`, `Bairro`, `Cidade`, `Estado`, `Cep`, `Cliente`
- Criar a pasta `Context` com `AppDbContext`.
- Configurar no `OnModelCreating`:
  - PK de `Cliente` e `Endereco`
  - relacionamento 1:1 (`Cliente` -> `Endereco`)
  - FK em `Endereco.ClienteId`
  - indice unico em `ClienteId`
  - tamanhos maximos e campos obrigatorios

### Criterio de conclusao
- Projeto compila com `dotnet build`.
- Modelo gera duas tabelas separadas (na migration).

---

## Exercicio 2 - Migration inicial + seed

### Objetivo
Gerar migration e inserir dados iniciais de 5 clientes com endereco.

### Requisitos
- Adicionar `HasData` no `AppDbContext` para:
  - 5 registros em `Clientes`
  - 5 registros em `Enderecos` (com `ClienteId` correspondente)
- Criar/usar `AppDbContextFactory` para suportar comandos `dotnet ef`.
- Gerar migration chamada `Inicial`.
- Aplicar no banco MySQL com `dotnet ef database update`.

### Criterio de conclusao
- Migration criada com inserts de seed.
- Banco contem 5 clientes e 5 enderecos relacionados.

---

## Exercicio 3 - Consulta com Include e tabela no console

### Objetivo
Exibir clientes com seus enderecos em formato tabular no console.

### Requisitos
- No `Program.cs`, carregar os clientes com:
  - `Include(c => c.Endereco)`
  - ordenacao por `Id`
- Montar uma tabela no console com colunas:
  - `ID`
  - `Nome`
  - `Telefone`
  - `Endereco completo`
- Tratar caso cliente sem endereco (texto padrao: `Endereco nao cadastrado`).

### Criterio de conclusao
- Executar `dotnet run` e visualizar a tabela formatada.
- Os 5 clientes do seed devem aparecer com endereco.

---

## Bonus (opcional)
- Criar um `Exercicio 4` com filtro por cidade (`Where` no endereco).
- Mostrar total de clientes por estado usando `GroupBy`.
