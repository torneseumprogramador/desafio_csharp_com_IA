### Exercício 02 - Sistema de Biblioteca com Classes

**Objetivo**  
Criar um pequeno **sistema de biblioteca** usando **POO**, separando a lógica em classes e arquivos diferentes.

### Regras gerais

- Crie uma **classe `Livro`** em `Livro.cs` com propriedades:
  - `Titulo`
  - `Autor`
  - `AnoPublicacao`
  - (opcional) `Disponivel` (bool) para indicar se o livro está emprestado ou não.
- Crie uma **classe `Biblioteca`** em `Biblioteca.cs` que:
  - Tenha uma coleção de livros (`List<Livro>`).
  - Tenha métodos para:
    - Cadastrar novo livro
    - Listar todos os livros
    - Buscar livros por título (exato ou parte do título)
    - Marcar um livro como emprestado/devolvido (se usar `Disponivel`).
- Crie uma **classe de entrada (`Program` ou `Menu`)** em `Program.cs` (ou `Menu.cs`) que:
  - Mostre um **menu no console**, por exemplo:
    - `1 - Cadastrar livro`
    - `2 - Listar livros`
    - `3 - Buscar livro por título`
    - `4 - Emprestar livro`
    - `5 - Devolver livro`
    - `6 - Sair`
  - Leia a opção e chame os métodos da `Biblioteca`.

### Requisitos técnicos

- Organizar o código em **arquivos separados** (`Livro.cs`, `Biblioteca.cs`, `Program.cs`/`Menu.cs`).
- Encapsular a lista de livros **dentro da classe** `Biblioteca`.
- Evitar lógica de cadastro/listagem espalhada:  
  - O `Program`/`Menu` apenas cuida da **interface com o usuário** (leitura/escrita no console).
  - A classe `Biblioteca` cuida das **regras de negócio** (adicionar, buscar, emprestar etc.).

### Desafios extras (opcional)

- Não permitir emprestar um livro que já está emprestado.
- Permitir que o usuário veja **somente os livros disponíveis** para empréstimo.
- Adicionar uma classe `Usuario` (em um arquivo `Usuario.cs`) e associar os empréstimos a um usuário (apenas se quiser dar um passo além).

