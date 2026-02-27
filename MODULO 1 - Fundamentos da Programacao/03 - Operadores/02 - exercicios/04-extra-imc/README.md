## Exercício Extra 04 – Cálculo de IMC com Operadores Relacionais

**Objetivo:** praticar operadores aritméticos (`/`, `*`) e relacionais (`<`, `>`, `<=`, `>=`, `==`, `!=`).

### Enunciado

Crie um programa console em C# para calcular o **IMC (Índice de Massa Corporal)** de uma pessoa.

1. Peça ao usuário:
  - O **peso** em kg (por exemplo, `double peso`).
  - A **altura** em metros (por exemplo, `double altura`).
2. Calcule o IMC usando a fórmula:

   \text{imc} = \frac{peso}{altura * altura}
   
3. Mostre o valor do IMC no console.
4. Use **operadores relacionais** para exibir no console (como `true` ou `false`) se o IMC está:
  - Menor que 18.5 (abaixo do peso).
  - Entre 18.5 e 24.9 (peso normal).
  - Maior ou igual a 25 (acima do peso).

Você pode mostrar algo como:

- `"IMC abaixo do peso: " + (imc < 18.5)`
- `"IMC peso normal: " + (imc >= 18.5 && imc <= 24.9)`
- `"IMC acima do peso: " + (imc >= 25)`

### Regras

- Use **apenas** operadores aritméticos e relacionais (e lógicos se quiser fazer combinações como `&&`).
- Não use `if` ainda; apenas escreva expressões que resultem em `true` ou `false` como no exemplo de `idade` do arquivo de operadores.

