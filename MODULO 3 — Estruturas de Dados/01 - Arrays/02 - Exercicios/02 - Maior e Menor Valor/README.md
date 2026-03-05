### Exercício 02 - Maior e Menor Valor em Array

**Cenário real**  
Você está desenvolvendo um relatório simples que precisa encontrar rapidamente o maior e o menor valor de uma lista de dados.

### Objetivo

Criar um programa em C# que:

- **Leia** uma sequência de números inteiros do usuário.
- **Armazene** esses valores em um `int[]`.
- **Encontre** o **maior** e o **menor** valor do array.
- **Conte** quantas vezes o maior e o menor aparecem.
- **Mostre** essas informações no console.

### Comportamento sugerido

1. Perguntar: `"Quantos valores serão digitados?"`
2. Validar a quantidade com `int.TryParse`.  
   - Se inválida ou menor/igual a zero, exibir mensagem de erro e encerrar.
3. Criar o array `int[] valores = new int[quantidade];`
4. Usar um laço `for` para:
   - ler cada número;
   - validar com `int.TryParse`;
   - armazenar no array.
5. Inicializar variáveis `maior`, `menor`, `qtdMaior`, `qtdMenor`.
6. Percorrer o array para:
   - descobrir o maior e o menor valor;
   - contar quantas vezes cada um aparece.
7. Exibir algo como:
   - `"Maior valor: X (aparece Y vez(es))"`
   - `"Menor valor: A (aparece B vez(es))"`

### Requisitos técnicos

- Usar `int[]` para armazenar os valores.
- Usar laços (`for` ou `foreach`) para percorrer o array.
- Usar `int.TryParse` para validar a entrada de dados.
- Usar condicionais (`if`, `else`) para atualizar maior, menor e contadores.

### Desafios extras (opcional)

- Permitir que o usuário veja também a **posição (índice)** do primeiro e do último maior valor.
- Ordenar o array em ordem crescente (pode usar `Array.Sort`) e mostrar todos os valores ordenados.
- Permitir que o usuário repita a análise com um novo conjunto de números sem fechar o programa (menu simples com laço).
