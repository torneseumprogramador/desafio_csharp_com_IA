# Exercicio - Sistema de Biblioteca (Data Annotations + Code First)

## Objetivo
Construir um sistema de **gerenciamento de biblioteca** usando a mesma base tecnica da aula:

- .NET Console
- Entity Framework Core (Code First)
- Data Annotations para mapeamento
- MySQL
- Interface separada em varios arquivos (menus/helpers)

---

## Tema proposto
Trocar o tema "estacionamento" por **biblioteca**, mantendo a mesma arquitetura.

---

## Requisitos tecnicos (iguais a aula)

1. Criar pasta `Models` com entidades e annotations detalhadas:
   - `[Table]`
   - `[Key]`
   - `[Required]`
   - `[StringLength]`
   - `[Column("nome_coluna", TypeName = "...")]`
   - `[ForeignKey]`

2. Criar `Context/AppDbContext.cs` com os `DbSet`.

3. Criar `Context/AppDbContextFactory.cs` para suportar `dotnet ef`.

4. Criar `app.json` com connection string para MySQL.

5. Criar migration inicial e aplicar no banco:
   - `dotnet ef migrations add InicialBiblioteca`
   - `dotnet ef database update`

6. Criar interface de console modular em pasta `UI`:
   - `AppMenu`
   - menus separados por entidade
   - helpers de entrada e renderizacao

---

## Modelagem minima obrigatoria

### Entidade `Leitor`
- `Id`
- `Nome`
- `Documento`
- `Telefone`
- `Email`

### Entidade `Livro`
- `Id`
- `Titulo`
- `Isbn`
- `AnoPublicacao`
- `Disponivel` (bool)

### Entidade `Emprestimo`
- `Id`
- `LeitorId` (FK)
- `LivroId` (FK)
- `DataEmprestimo`
- `DataDevolucao` (nullable)
- `Multa` (decimal nullable)

Relacionamentos esperados:
- `Leitor` 1:N `Emprestimo`
- `Livro` 1:N `Emprestimo`

---

## Funcionalidades da interface (minimo)

### Menu Leitores
- Cadastrar leitor
- Listar leitores

### Menu Livros
- Cadastrar livro
- Listar livros

### Menu Emprestimos
- Registrar emprestimo
  - Permitir emprestimo apenas se `Livro.Disponivel == true`
  - Ao emprestar, marcar livro como indisponivel
- Registrar devolucao
  - Preencher `DataDevolucao`
  - Informar `Multa` (se houver)
  - Marcar livro como disponivel
- Listar emprestimos

---

## Regras de validacao

- ISBN deve ser obrigatorio e ter tamanho maximo definido.
- Documento do leitor deve ser obrigatorio.
- Nao permitir emprestar livro ja emprestado (sem devolucao).
- Nao permitir devolucao de emprestimo ja encerrado.

---

## Criterios de conclusao

- Projeto compila com `dotnet build`.
- Migration criada e aplicada no MySQL.
- Fluxo completo funciona via `dotnet run`.
- Codigo organizado em varios arquivos, sem concentrar tudo no `Program.cs`.

---

## Bonus (opcional)

- Adicionar enum `GeneroLivro`.
- Criar busca por titulo.
- Exibir relatorio: livros disponiveis vs emprestados.
