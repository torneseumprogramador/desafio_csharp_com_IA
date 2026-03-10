### Exercício 05 - Estatísticas de Números

**Cenário**  
Você precisa gerar um pequeno relatório estatístico a partir de uma lista de números inteiros, usando apenas os métodos de manipulação de coleções vistos na aula.

### Objetivo

Criar um programa em C# que:

- Trabalhe com uma `List<int>` (pode ser fixa no código).
- Calcule usando o que vc aprendeu na aula:
  - **Quantidade total** de elementos (`Count`);
  - **Quantidade** de números maiores que um certo valor (ex.: > 25);
  - **Soma** de todos os números (`Sum`);
  - **Média** dos números (`Average`);
  - **Maior** valor (`Max`);
  - **Menor** valor (`Min`).
- Verifique se **todos** os números são maiores que um valor usando `All`.
- Mostre tudo no console de forma organizada.

### Sugestão de passos

1. Criar uma lista fixa, por exemplo:
  `List<int> numeros = new List<int> { 10, 20, 30, 40, 50 };`
2. Usar:
  - `Count` para saber quantos elementos têm.
  - `Count` com expressão (`n => n > 25`) para ver quantos são maiores que 25.
  - `Sum`, `Average`, `Max`, `Min`.
  - `All(n => n > 5)` para verificar se todos são maiores que 5.
3. Exibir cada resultado com uma mensagem clara no console.

### Requisitos Técnicos

- Usar `List<int>` e os métodos:
  - `Count`
  - `Sum`
  - `Average`
  - `Max`
  - `Min`
  - `All`
- Usar interpolação de string (`$"..."`) para formatar as saídas.

### Desafios extras (opcional)

- Permitir que o usuário digite a lista de números (separados por espaço, por exemplo) e depois converter para `List<int>`.
- Permitir que o usuário informe o valor de corte para os filtros (por exemplo, maior que X).
- Exibir também apenas os números **maiores do que a média**.

