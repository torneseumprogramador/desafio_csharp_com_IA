### Exercício 06 - Conversão e Agrupamento de Coleções

**Cenário**  
Você está trabalhando com uma lista de nomes e precisa gerar relatórios diferentes usando os métodos de manipulação de coleções da aula, como **`Select`**, **`ToDictionary`** e **`GroupBy`**.

### Objetivo

Criar um programa em C# que:

- Tenha uma `List<string>` com alguns nomes (por exemplo: `"Ana"`, `"André"`, `"Carlos"`, `"Carla"`).
- Use `Select` para:
  - Gerar uma nova lista com todos os nomes em **maiúsculas**.
- Use `ToDictionary` para:
  - Transformar a lista de nomes em um dicionário onde:
    - A chave é o próprio nome;
    - O valor é o **tamanho do nome** (quantidade de caracteres).
- Use `GroupBy` para:
  - Agrupar os nomes pela **primeira letra**.
- Exiba no console:
  - Lista original;
  - Lista transformada (maiúsculas);
  - Dicionário (nome -> quantidade de caracteres);
  - Grupos de nomes por letra inicial.

### Sugestão de passos

1. Criar a lista de nomes:  
   `List<string> nomes = new List<string> { "Ana", "André", "Carlos", "Carla" };`
2. Aplicar `Select(n => n.ToUpper())` para gerar a lista em maiúsculas.
3. Aplicar `ToDictionary(n => n, n => n.Length)` para gerar o dicionário.
4. Aplicar `GroupBy(n => n[0])` para agrupar pelos caracteres iniciais.
5. Usar `foreach` para percorrer:
   - A lista transformada;
   - O dicionário;
   - Os grupos (`foreach (var grupo in grupos)`…).

### Requisitos Técnicos

- Usar `List<string>`.
- Usar os métodos:
  - `Select`
  - `ToDictionary`
  - `GroupBy`
- Usar `string.Join` para exibir listas no console.
- Usar interpolação de string para formatar as saídas.

### Desafios extras (opcional)

- Permitir que o usuário digite novos nomes para adicionar à lista antes dos filtros.
- Criar um segundo agrupamento: por **tamanho do nome** (quantidade de letras).
- Exibir quantos nomes existem em cada grupo (por letra inicial).

