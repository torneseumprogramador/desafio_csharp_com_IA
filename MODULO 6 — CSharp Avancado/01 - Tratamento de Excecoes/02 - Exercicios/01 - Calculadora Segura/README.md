# 01 - Calculadora Segura

## Enunciado

Crie uma aplicação de console em C# que solicite dois números ao usuário e, em seguida, peça a operação matemática desejada (`+`, `-`, `*` ou `/`).

O objetivo do exercício é praticar o uso de `try`, `catch` e `finally` para tratar possíveis erros durante a execução.

## Requisitos

- Ler os dois valores digitados pelo usuário.
- Ler a operação matemática desejada.
- Executar o cálculo e exibir o resultado na tela.
- Tratar erro de divisão por zero com `DivideByZeroException`.
- Tratar erro de conversão de texto para número com `FormatException`.
- Criar um `catch` genérico para qualquer erro inesperado.
- Usar `finally` para exibir uma mensagem informando que a operação foi finalizada.

## Desafio extra

- Mostrar o tipo da exceção com `ex.GetType()`.
- Mostrar a mensagem da exceção com `ex.Message`.
