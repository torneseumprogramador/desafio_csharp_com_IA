# 02 - Ranking e Agrupamentos

## Enunciado

Crie uma aplicação de console em C# com uma lista de pessoas. Cada pessoa deve possuir `Nome`, `Cidade`, `Idade` e uma lista de `Hobbies`.

Utilize LINQ para agrupar e gerar rankings com base nessas informações.

## Requisitos

- Criar uma lista com pelo menos 5 pessoas.
- Cada pessoa deve possuir pelo menos 2 hobbies.
- Agrupar as pessoas por cidade usando `GroupBy`.
- Para cada cidade, exibir:
- nome da cidade
- média de idade
- nomes das pessoas do grupo
- Criar uma segunda consulta para gerar um ranking dos hobbies mais populares.
- Para o ranking, usar `SelectMany`, `GroupBy`, `OrderByDescending` e `ThenBy`.
- Exibir o nome do hobby e quantas vezes ele aparece.

## Objetivo da prática

- Praticar `GroupBy` com projeção.
- Trabalhar com agregações como `Average` e `Count`.
- Montar rankings a partir de listas internas.

## Desafio extra

- Agrupar também por quantidade de hobbies.
- Criar um dicionário com `ToDictionary` relacionando o nome da pessoa aos hobbies em ordem alfabética.
