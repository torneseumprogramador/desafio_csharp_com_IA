# 01 - Processamento em Background

## Enunciado

Crie uma aplicação de console em C# que execute um processamento pesado em segundo plano usando `Task.Run`.

O objetivo é mostrar que uma tarefa pode ser enviada para execução em background enquanto o programa principal continua organizado e depois aguarda sua conclusão.

## Requisitos

- Criar uma variável numérica para ser alterada dentro da tarefa.
- Usar `Task.Run(...)` para executar um laço grande que simule um processamento pesado.
- Após o término da task, exibir no console o valor final da variável.
- Exibir mensagens antes de iniciar, durante a execução e após finalizar a tarefa.
- Utilizar `await` para aguardar a conclusão da task.

## Objetivo da prática

- Entender o uso de `Task.Run`.
- Praticar execução de processamento em background.
- Comparar o fluxo principal com o fluxo executado dentro da task.

## Desafio extra

- Criar uma segunda task com outro processamento pesado.
- Comparar a execução com e sem `Task.Run`.
