# 03 - Buscas Avancadas com LINQ

## Enunciado

Crie uma aplicação de console em C# com uma lista de pessoas contendo `Nome`, `Cidade`, `Idade` e uma lista de hobbies.

Utilize LINQ para fazer consultas mais avançadas, incluindo busca textual, interseção entre listas e agregação de resultados.

## Requisitos

- Criar uma lista com pelo menos 5 pessoas.
- Criar uma lista externa chamada `hobbiesPremium`.
- Fazer uma consulta que encontre as pessoas que possuem pelo menos um hobby em comum com uma pessoa de referência.
- Usar `Intersect` e `Any` nessa consulta.
- Fazer uma consulta com sintaxe LINQ (`from`, `where`, `select`) para buscar nomes que contenham uma determinada letra.
- Criar uma consulta que concatene os nomes das pessoas maiores de 25 anos usando `Aggregate`.
- Exibir no console o resultado de todas as consultas.

## Objetivo da prática

- Praticar `Intersect`, `Any` e `Aggregate`.
- Trabalhar com query syntax e method syntax.
- Exercitar filtros textuais com LINQ.

## Desafio extra

- Encontrar pessoas que possuam todos os hobbies da lista `hobbiesPremium` usando `All`.
- Criar uma consulta para detectar nomes com letras repetidas consecutivas.
