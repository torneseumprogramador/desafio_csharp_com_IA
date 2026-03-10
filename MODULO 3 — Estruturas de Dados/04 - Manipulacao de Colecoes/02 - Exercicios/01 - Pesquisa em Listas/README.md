### Exercício 04 - Pesquisa em Listas com Filtros e Ordenação

**Cenário**  
Você está criando um módulo que ajuda a analisar uma lista de números inteiros digitados pelo usuário, aplicando **filtros** e **ordenação** usando os métodos vistos em aula.

### Objetivo

Criar um programa em C# que:

- Leia uma lista de números inteiros (pode ser fixa no código ou lida do usuário).
- Use **`Where`** para:
  - Filtrar apenas números dentro de um intervalo (por exemplo, entre 10 e 50).
- Use **`OrderBy`** e **`OrderByDescending`** para:
  - Ordenar a lista filtrada em ordem crescente.
  - Ordenar a mesma lista em ordem decrescente.
- Exiba os resultados no console usando `string.Join`.

### Sugestão de passos

1. Criar uma lista fixa, por exemplo:  
   `List<int> numeros = new List<int> { 5, 10, 20, 35, 50, 2, 18, 40 };`
2. Usar `Where` para pegar apenas números entre 10 e 40.
3. Usar `OrderBy` para ordenar esses números em ordem crescente.
4. Usar `OrderByDescending` para ordenar em ordem decrescente.
5. Exibir:
   - Lista original
   - Lista filtrada
   - Lista filtrada e ordenada crescente
   - Lista filtrada e ordenada decrescente

### Requisitos Técnicos

- Usar `List<int>` e métodos de extensão LINQ:
  - `Where`
  - `OrderBy`
  - `OrderByDescending`
- Usar `string.Join` para montar a saída no console.
- Separar visualmente cada resultado com linhas (`Console.WriteLine("------");`).

### Desafios extras (opcional)

- Permitir que o usuário informe os limites do filtro (mínimo e máximo).
- Permitir que o usuário escolha se quer ver o resultado crescente ou decrescente.
- Mostrar também apenas os números **pares** dentro do intervalo escolhido.

