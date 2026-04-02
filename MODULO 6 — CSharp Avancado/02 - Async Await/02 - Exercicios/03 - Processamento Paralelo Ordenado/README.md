# 03 - Processamento Paralelo Ordenado

## Enunciado

Crie uma aplicação de console em C# que processe números de `1` a `10` em paralelo, simulando uma operação demorada para cada número, e depois grave o resultado final em um arquivo `numeros.txt` em ordem crescente.

O exercício deve reproduzir a ideia de várias tarefas trabalhando ao mesmo tempo e, no final, organizar os dados antes de salvar.

## Requisitos

- Criar uma coleção com os números de `1` a `10`.
- Distribuir o processamento desses números entre várias tarefas.
- Em cada tarefa, simular processamento com `await Task.Delay(...)`.
- Exibir no console quando cada número for processado.
- Usar `Task.WhenAll(...)` para aguardar todas as tarefas.
- Após o processamento, ordenar os números antes de gravar no arquivo.
- Escrever o resultado final em `numeros.txt`.

## Objetivo da prática

- Praticar processamento paralelo com `Task`.
- Entender o uso de `Task.WhenAll`.
- Trabalhar com a ideia de processar em paralelo e consolidar o resultado no final.

## Desafio extra

- Limitar a quantidade máxima de tarefas executando ao mesmo tempo.
- Medir o tempo de execução com `Stopwatch`.
- Pesquisar e usar `ConcurrentQueue`, `ConcurrentBag` ou `SemaphoreSlim`.
