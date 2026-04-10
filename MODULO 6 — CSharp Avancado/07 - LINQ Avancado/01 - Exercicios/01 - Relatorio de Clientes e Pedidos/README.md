# 01 - Relatorio de Clientes e Pedidos

## Enunciado

Crie uma aplicação de console em C# com uma lista de clientes. Cada cliente deve possuir `Nome`, `Cidade` e uma lista de `Pedidos`.

Cada `Pedido` deve conter pelo menos `Id`, `Valor`, `Data` e `Ativo`.

Utilize LINQ para gerar relatórios a partir desses dados.

## Requisitos

- Criar uma lista com pelo menos 4 clientes.
- Cada cliente deve possuir pelo menos 2 pedidos.
- Filtrar os clientes que possuem pelo menos 2 pedidos ativos.
- Ordenar o resultado pela maior soma de pedidos ativos.
- Projetar o resultado com `Select`, exibindo:
- nome do cliente
- quantidade de pedidos ativos
- soma total dos pedidos ativos
- Criar uma segunda consulta usando `SelectMany` para listar todos os pedidos ativos de todos os clientes em uma única coleção.
- Exibir no console o resultado das duas consultas.

## Objetivo da prática

- Praticar `Where`, `OrderByDescending`, `Select` e `SelectMany`.
- Trabalhar com listas aninhadas em LINQ.
- Aprender a montar relatórios com projeções.

## Desafio extra

- Ordenar os pedidos ativos pela data mais recente.
- Exibir também a cidade de cada cliente na projeção final.
