## Exercício 02 – Entrada e Saída de Dados

**Objetivo:** praticar leitura de dados com `Console.ReadLine()` e exibição com `Console.WriteLine()`.

### Instruções

- **1. Crie um novo projeto console** em C# chamado `exercicio02_entrada_saida`.
- **2. Peça ao usuário as seguintes informações:**
  - Nome (`string`).
  - Idade (`string`, lida do console).
- **3. Converta a idade lida para `int`** usando `int.Parse` ou `Convert.ToInt32`.
- **4. Monte uma mensagem de saída** no formato:
  - `"Seu nome é: " + nome`
  - `"Sua idade daqui a 5 anos será: " + (idadeConvertida + 5)`
- **5. Mostre essas mensagens no console** com `Console.WriteLine`.

### Regras

- Use **apenas** os recursos já vistos:
  - `Console.WriteLine`
  - `Console.ReadLine`
  - `int.Parse` ou `Convert.ToInt32`
- Não use `if`, `while`, `for` ou outros recursos ainda não estudados.

### Desafio extra (opcional)

- Peça também o **sobrenome** do usuário e exiba o **nome completo** em uma única `string`.

