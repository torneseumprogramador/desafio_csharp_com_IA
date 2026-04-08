# 03 - Cadastro e Busca de Usuarios

## Enunciado

Crie uma aplicação de console em C# com uma lista de usuários e utilize expressões lambda para buscar e validar dados.

O programa deve trabalhar com uma classe `Usuario` contendo pelo menos `Id` e `Nome`.

## Requisitos

- Criar uma classe `Usuario`.
- Criar uma lista com pelo menos 4 usuários.
- Usar `FirstOrDefault` com lambda para buscar um usuário pelo `Id`.
- Exibir o nome do usuário encontrado.
- Caso não encontre, exibir uma mensagem informando que o usuário não existe.
- Criar um `Predicate<int>` para validar se um `Id` é par.
- Testar o `Predicate` com pelo menos dois valores diferentes.
- Criar uma `Action<string>` com mais de uma linha para exibir mensagens no console.

## Objetivo da prática

- Praticar busca com `FirstOrDefault`.
- Reforçar o uso de `Predicate` e `Action`.
- Trabalhar lambdas simples e lambdas com bloco de código.

## Desafio extra

- Buscar usuários pelo nome usando lambda.
- Exibir uma lista com todos os usuários cujo `Id` seja maior que 2.
