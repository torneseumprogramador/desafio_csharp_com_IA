### Exercício 02 - Pais, Filhos e Joins com LINQ

**Cenário**  
Você tem duas coleções separadas em memória representando **pais** e **filhos**, e precisa montar relatórios relacionando essas duas listas usando **LINQ**, inclusive com `join`, soma de idades e agrupamentos, como visto na aula.

### Estruturas sugeridas

- Lista de pais:
  ```csharp
  var pais = new List<dynamic>
  {
      new { Id = 1, Nome = "Carlos", Idade = 45 },
      new { Id = 2, Nome = "Maria",  Idade = 40 },
      new { Id = 3, Nome = "Pedro",  Idade = 50 }
  };
  ```

- Lista de filhos:
  ```csharp
  var filhos = new List<dynamic>
  {
      new { Id = 1, Nome = "Ana",     Idade = 20, PaiId = 1 },
      new { Id = 2, Nome = "João",    Idade = 18, PaiId = 1 },
      new { Id = 3, Nome = "Paulo",   Idade = 15, PaiId = 2 },
      new { Id = 4, Nome = "Fernanda",Idade = 13, PaiId = 2 },
      new { Id = 5, Nome = "Lucas",   Idade = 25, PaiId = 3 }
  };
  ```

### Objetivo

Criar um programa em C# que faça, com LINQ:

1. **Join entre pais e filhos (sintaxe de consulta)**  
   - Usar `from ... in ... join ... on ... equals ... select new { ... }`  
   - Retornar um objeto anônimo com:
     - Nome do pai
     - Idade do pai
     - Nome do filho
     - Idade do filho
   - Exibir em formato de tabela no console.

2. **Join entre pais e filhos (sintaxe de métodos)**  
   - Usar `.Join(...)` com:
     - coleção de pais
     - coleção de filhos
     - chave de pai (`pai.Id`)
     - chave de filho (`filho.PaiId`)
     - projeção final com novo objeto anônimo semelhante ao do item 1.

3. **Soma de idades dos filhos por pai**  
   - Usar LINQ para agrupar ou projetar um resultado que mostre:
     - Nome do pai
     - Soma das idades de seus filhos
   - Exibir um relatório do tipo:  
     `"Pai: Carlos - Soma idades dos filhos: 38"`

### Requisitos Técnicos

- Usar LINQ com:
  - `join` (query syntax)
  - `.Join(...)` (sintaxe de métodos)
  - `Select`, `GroupBy` ou combinações com `Sum`, se desejar.
- Usar **objetos anônimos** (como nos exemplos da aula) para os resultados.
- Exibir os dados em formato organizado no console (pode utilizar `Console.WriteLine` com formatação de colunas).

### Desafios extras (opcional)

- Calcular e mostrar a **média de idade** dos filhos por pai.
- Mostrar apenas os pais cuja soma das idades dos filhos seja maior que um determinado valor (por exemplo, > 30).
- Ordenar o resultado final pela soma das idades dos filhos (do maior para o menor).

