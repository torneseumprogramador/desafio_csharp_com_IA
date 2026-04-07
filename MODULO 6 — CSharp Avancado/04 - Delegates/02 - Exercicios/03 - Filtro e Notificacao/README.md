# 03 - Filtro e Notificacao

## Enunciado

Crie uma aplicação de console em C# que trabalhe com delegates em dois cenários:

1. Filtrar uma lista de números.
2. Executar uma notificação por callback após uma ação do sistema.

O objetivo é praticar delegates tanto para seleção de comportamento quanto para resposta a eventos.

## Requisitos

- Criar um delegate que receba um número inteiro e retorne `bool`.
- Criar um método `Filtrar` que receba uma lista de números e o delegate de filtro.
- Criar pelo menos dois métodos de filtro, como `ApenasPares` e `ApenasImpares`.
- Exibir no console os números filtrados.
- Criar um segundo delegate para callback de notificação.
- Criar um método que simule um processamento e, ao final, invoque o callback.
- Exibir no console a mensagem recebida pelo callback.

## Objetivo da prática

- Entender delegates com retorno booleano.
- Praticar o envio de comportamento para um método.
- Trabalhar com callback após o término de uma operação.

## Desafio extra

- Adicionar filtros como `ApenasMaioresQueCinco`.
- Criar dois callbacks diferentes, como mensagem na tela e gravação em log.
