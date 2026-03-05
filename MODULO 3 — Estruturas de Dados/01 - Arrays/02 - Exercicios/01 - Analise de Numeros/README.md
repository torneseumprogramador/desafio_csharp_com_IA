### Exercício 01 - Análise de Números com Array

**Cenário real**  
Você está criando um pequeno módulo de estatísticas para analisar uma lista de números inteiros digitados pelo usuário.

### Objetivo

Criar um programa em C# que:

- **Leia** do usuário a quantidade de números que ele quer analisar (por exemplo, 5 ou 10).
- **Crie** um `int[]` com esse tamanho.
- **Preencha** o array lendo os números digitados pelo usuário.
- **Calcule**:
  - a **soma** de todos os números;
  - a **média**;
  - o **maior** e o **menor** valor do array.
- **Mostre** esses resultados no console.

### Comportamento sugerido

1. Perguntar: `"Quantos números você deseja digitar?"`
2. Validar a entrada com `int.TryParse`.  
   - Se for inválida ou menor/igual a zero, exibir mensagem de erro e encerrar.
3. Criar um array `int[] numeros = new int[quantidade];`
4. Usar um laço (`for`) para:
   - pedir cada número: `"Digite o número da posição X:"`;
   - validar com `int.TryParse`;
   - armazenar no array.
5. Após preencher o array, percorrê-lo novamente para:
   - somar todos os valores;
   - encontrar maior e menor;
   - calcular a média.
6. Mostrar no final algo como:
   - `"Soma: ..."`
   - `"Média: ..."`
   - `"Maior valor: ..."`
   - `"Menor valor: ..."`

### Requisitos técnicos

- Usar `int[]` para armazenar os números.
- Usar `for` ou `foreach` para percorrer o array.
- Usar `int.TryParse` para validar as entradas numéricas.
- Tratar casos inválidos com mensagens claras para o usuário.

### Desafios extras (opcional)

- Permitir que o usuário veja também **quantos números são pares** e **quantos são ímpares**.
- Permitir que o usuário digite números negativos e mostrar separadamente a soma dos positivos e dos negativos.
- Exibir todos os números digitados em uma única linha usando `string.Join`.

