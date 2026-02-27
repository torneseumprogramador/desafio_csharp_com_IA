## Exercício Extra 05 – Lógica de Acesso com Operadores Lógicos

**Objetivo:** praticar operadores lógicos (`&&`, `||`, `!`) e relacionais em expressões booleanas.

### Enunciado

Uma empresa tem um sistema simples de controle de acesso.

Regras:

- A pessoa **só pode entrar** em uma área restrita se:
  - For **funcionário** da empresa **e** tiver **cracha válido**;  
  - **Ou** for **visitante**, mas estiver **acompanhado** por um funcionário.

Crie um programa console em C# que:

1. Peça ao usuário:
   - Se ele é funcionário (`bool ehFuncionario` – true/false).
   - Se tem crachá válido (`bool temCrachaValido` – true/false).
   - Se é visitante (`bool ehVisitante` – true/false).
   - Se está acompanhado por um funcionário (`bool acompanhadoPorFuncionario` – true/false).
2. Use expressões com operadores lógicos para exibir:
   - Se ele **pode entrar** na área restrita.
   - Se ele **não pode entrar** (usando `!` em alguma expressão).
3. Mostre no console frases como:
   - `"Pode entrar na área restrita: " + (/* sua expressão lógica aqui */)`
   - `"Não pode entrar na área restrita: " + (!(/* sua expressão lógica aqui */))`

### Regras

- Use obrigatoriamente `&&`, `||` e `!` em pelo menos uma expressão.
- Não use `if` ainda; apenas calcule expressões booleanas e mostre no `Console.WriteLine`, como no exemplo de operadores lógicos estudado.

