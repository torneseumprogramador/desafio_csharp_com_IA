# 02 - Estrategias de Preco

## Enunciado

Crie uma aplicação de console em C# que utilize `delegate` para aplicar diferentes estratégias de cálculo sobre um preço.

O programa deve receber um valor e executar cálculos diferentes, como desconto ou taxa, de acordo com o método enviado para execução.

## Requisitos

- Criar um delegate que receba um `decimal` e retorne um `decimal`.
- Criar um método `AplicarDesconto`.
- Criar um método `AplicarTaxa`.
- Criar um método `ExecutarCalculo(decimal valor, ...)` que receba o delegate como parâmetro.
- Executar o cálculo com pelo menos duas estratégias diferentes.
- Exibir no console o valor original e o valor final calculado.

## Objetivo da prática

- Entender o uso de delegates como estratégia.
- Praticar passagem de métodos como parâmetro.
- Comparar essa abordagem com o uso de vários `if/else`.

## Desafio extra

- Criar uma terceira estratégia, como cashback.
- Permitir que o usuário informe o valor e escolha a estratégia desejada.
