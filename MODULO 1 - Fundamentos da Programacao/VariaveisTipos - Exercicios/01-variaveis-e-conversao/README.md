## Exercício 01 – Variáveis e Conversão de Tipos

**Objetivo:** praticar declaração de variáveis estáticas e dinâmicas, além da conversão de tipos em C#.

### Instruções

- **1. Crie um novo projeto console** em C# chamado `exercicio01_variaveis`.
- **2. Declare variáveis estáticas** para:
  - Nome de uma pessoa (`string`).
  - Idade dessa pessoa (`int`).
- **3. Declare variáveis dinâmicas (`var`)** para:
  - Um segundo nome.
  - Uma segunda idade.
- **4. Monte três resultados em `string`**:
  - Um usando `Convert.ToString(idade)` + `" - "` + `nome`.
  - Outro usando `idade2.ToString()` + `" - "` + `nome2`.
  - Outro somando um número vindo de `string` com a idade, usando `int.Parse("algumNumero") + idade`.
- **5. Mostre os três resultados no console** usando `Console.WriteLine`.

### Regras

- Use **tipagem estática** (`string`, `int`) e **dinâmica** (`var`) como no exemplo visto em aula.
- Sempre que misturar números com texto, faça a **conversão de tipo** (`ToString`, `Convert.ToString`, `int.Parse`).

### Desafio extra (opcional)

- Peça ao usuário para digitar um número (como texto) com `Console.ReadLine()` e **some esse valor à idade**, usando `int.Parse` para converter o texto em número antes da soma.

