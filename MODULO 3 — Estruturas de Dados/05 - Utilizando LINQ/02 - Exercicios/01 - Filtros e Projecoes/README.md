### Exercício 01 - Filtros e Projeções com LINQ

**Cenário**  
Você está trabalhando com uma lista de números inteiros e quer aplicar, em C#, consultas no estilo SQL usando **LINQ**, exatamente como visto em aula (métodos encadeados e *query syntax*).

### Objetivo

Criar um programa em C# que:

- Tenha uma `List<int>` com alguns números (por exemplo: `{ 5, 10, 15, 20, 25 }`).
- Use **sintaxe de métodos** (encadeada) para:
  - Filtrar apenas os números **maiores que 10** e **menores que 25** usando `Where`.
  - Ordenar os resultados em ordem crescente com `OrderBy`.
  - Projetar cada número multiplicado por 2 com `Select`.
- Repita a mesma lógica usando **query syntax** (estilo SQL):
  - `from n in numeros where ... orderby ... select ...`
- Exiba os resultados das duas consultas no console.

### Sugestão de passos

1. Criar a lista de números.
2. Montar a consulta com sintaxe de métodos:
   ```csharp
   var resultadoMetodos = numeros
       .Where(n => n > 10)
       .Where(n => n < 25)
       .OrderBy(n => n)
       .Select(n => n * 2);
   ```
3. Montar a mesma consulta com query syntax:
   ```csharp
   var resultadoQuery =
       from n in numeros
       where n > 10
       where n < 25
       orderby n
       select n * 2;
   ```
4. Percorrer cada resultado com `foreach` e exibir no console.

### Requisitos Técnicos

- Usar `List<int>`.
- Usar **tanto**:
  - Sintaxe de métodos (`Where`, `OrderBy`, `Select`)
  - Quanto query syntax (`from`, `where`, `orderby`, `select`)
- Exibir os resultados claramente, indicando de qual consulta veio (métodos ou query).

### Desafios extras (opcional)

- Permitir que o usuário digite os números (em vez de usar lista fixa).
- Permitir que o usuário escolha os limites do filtro (ex.: maior que X e menor que Y).
- Criar uma segunda projeção que retorne objetos anônimos com duas propriedades, por exemplo: `{ NumeroOriginal, NumeroDobrado }`.

