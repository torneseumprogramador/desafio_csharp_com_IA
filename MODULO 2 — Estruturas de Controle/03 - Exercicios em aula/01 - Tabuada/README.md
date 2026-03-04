### Exercício 01 - Tabuada Simples com Laço

**Cenário real**  
Você está criando um pequeno utilitário para ajudar uma criança a treinar tabuada de um número específico.

### Objetivo

Criar um programa em C# que:

- **Leia** do usuário um número inteiro.
- **Valide** a entrada usando `int.TryParse`.
- **Mostre** a tabuada desse número de 1 a 10 usando uma estrutura de repetição.

### Comportamento sugerido

1. Exibir no console:
  - `"Digite um número inteiro para ver a tabuada:"`
2. Ler a entrada e tentar converter para `int` com `int.TryParse`.
  - Se a conversão **falhar**, exibir `"Valor inválido"` e encerrar o programa.
3. Usar um laço (`for`, `while` ou `do...while`) para exibir:
  - `n x 1 = ...`
  - `n x 2 = ...`
  - ...
  - `n x 10 = ...`

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine` para entrada e saída.
- Validar a entrada com `int.TryParse` antes de usar o valor.
- Usar **uma estrutura de repetição** (`for`, `while` ou `do...while`) para gerar a tabuada.
- Usar operadores aritméticos (`*`) e variáveis (`int` e/ou `string` para montar a linha).

### Desafios extras (opcional)

- Permitir que o usuário escolha até qual número a tabuada deve ir (não só até 10).
- Exibir uma mensagem especial para números negativos.
- Usar interpolação de string (`$"..."`) para montar as linhas da tabuada.

