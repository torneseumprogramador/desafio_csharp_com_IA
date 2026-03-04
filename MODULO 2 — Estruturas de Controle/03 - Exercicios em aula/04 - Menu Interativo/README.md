### Exercício 04 - Menu Interativo com Estado

**Cenário real**  
Você está criando um pequeno sistema de console com um menu interativo, onde o usuário pode escolher opções várias vezes e o programa mantém um **estado** durante a execução (por exemplo, um contador de ações).

### Objetivo

Criar um programa em C# que:

- **Exiba** um menu com algumas opções numéricas.
- **Leia** a opção escolhida pelo usuário e **valide** a entrada.
- **Atualize** algum tipo de estado interno (por exemplo, um contador, pontuação ou valor acumulado).
- **Permita** que o usuário volte ao menu até escolher a opção de sair.

### Comportamento sugerido

1. Definir uma variável de estado, por exemplo:
   - `int pontuacao = 0;` ou `int contador = 0;`
2. Em um laço (`while` ou `do...while`), exibir um menu como:
   - `1 - Adicionar 10 pontos`
   - `2 - Remover 5 pontos`
   - `3 - Mostrar pontuação atual`
   - `0 - Sair`
3. Ler a opção com `Console.ReadLine()` e validar com `int.TryParse`.
   - Se a conversão falhar, mostrar `"Opção inválida"` e voltar ao menu.
4. Usar `switch` **ou** `if / else if / else` para tratar cada opção:
   - **1**: somar 10 ao estado (`pontuacao += 10;`).
   - **2**: subtrair 5 do estado.
   - **3**: exibir `"Pontuação atual: X"`.
   - **0**: encerrar o laço e exibir mensagem de despedida.
   - Outro valor: `"Opção inválida"`.
5. O menu deve continuar aparecendo **até** o usuário escolher `0`.

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine`.
- Usar `int.TryParse` para validar a opção do usuário.
- Usar uma estrutura de repetição (`while` ou `do...while`) para manter o menu em execução.
- Usar `switch` **ou** uma cadeia de `if / else if / else` para tratar as opções.
- Usar operadores aritméticos (`+`, `-`) para atualizar o estado.
- Usar variáveis `int` para o estado e, se quiser, `string` para mensagens.

### Desafios extras (opcional)

- Impedir que a pontuação fique negativa (usar `if` para checar antes de subtrair).
- Adicionar mais opções ao menu, como:
  - `4 - Zerar pontuação`
  - `5 - Dobrar pontuação`
- Exibir, ao sair, um resumo:
  - `"Pontuação final: X"` e uma mensagem usando operador ternário, por exemplo:
    - `string resultado = pontuacao > 50 ? "Boa pontuação!" : "Você pode melhorar!";`

