### Exercício 01 - Tabuada Interativa com Repetição

**Cenário real**  
Um professor quer um programa simples para ajudar os alunos a treinar tabuada de forma interativa, permitindo repetir o cálculo para vários números sem precisar reiniciar o programa.

### Objetivo

Criar um programa em C# que:

- **Leia** do usuário um número inteiro para gerar a tabuada.
- **Valide** a entrada usando `int.TryParse`.
- **Use uma estrutura de repetição** (`for` ou `while`) para mostrar a tabuada daquele número.
- **Pergunte** ao final se o usuário deseja calcular outra tabuada (`S` ou `N`) e:
  - enquanto o usuário responder `S`, o programa repete o processo;
  - se responder `N`, o programa encerra.

### Comportamento sugerido

1. Exibir uma mensagem como:  
   - `"Digite um número inteiro para ver a tabuada:"`
2. Ler a entrada e tentar converter para `int` com `int.TryParse`.
   - Se a conversão **falhar**, mostrar `"Valor inválido"` e pedir novamente o número.
3. Gerar a tabuada de `1` a `10`, por exemplo:
   - `5 x 1 = 5`
   - `5 x 2 = 10`
   - ...
4. Ao final, perguntar:
   - `"Deseja calcular outra tabuada? (S/N)"`
5. Repetir todo o processo enquanto a resposta for `S` (maiúsculo ou minúsculo).

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine` para interação com o usuário.
- Validar a entrada numérica com `int.TryParse`:
  - Se inválida, exibir mensagem e **não** tentar gerar a tabuada com aquele valor.
- Usar pelo menos **uma estrutura de repetição**:
  - `for` **ou** `while` para gerar as linhas da tabuada.
- Usar pelo menos **mais uma estrutura de repetição** (ou reaproveitar um `while`) para controlar se o usuário quer continuar (`S` / `N`).
- Utilizar operadores aritméticos (`*`, `+`) e variáveis (`int` e `string`).
- Usar `if`/`else` para tratar respostas diferentes de `S` ou `N`, se desejar.

### Exemplo de execução (apenas ilustrativo)

- Entrada:
  - `Digite um número inteiro para ver a tabuada: 3`
- Saída:
  - `3 x 1 = 3`
  - `3 x 2 = 6`
  - ...
  - `3 x 10 = 30`
- Depois:
  - `Deseja calcular outra tabuada? (S/N): S` → repete.
  - `Deseja calcular outra tabuada? (S/N): N` → encerra o programa com uma mensagem de despedida.

### Desafios extras (opcional)

- Permitir que o usuário escolha **até qual número** deve ir a tabuada (por exemplo, até 20 em vez de 10).
- Exibir uma mensagem especial se o número for maior que 10, usando um `if`:
  - Ex.: `"Número alto, isso vai gerar uma tabuada longa!"`.
- Garantir que a resposta `S`/`N` seja tratada de forma **case-insensitive** (aceitar `s`, `S`, `n`, `N`).

