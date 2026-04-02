# 02 - Escrita Assincrona em Arquivo

## Enunciado

Crie uma aplicação de console em C# que grave números de `1` a `10` em um arquivo chamado `numeros.txt` usando `async/await`.

O programa deve escrever um número por vez, exibindo no console qual número foi gravado, com um pequeno intervalo entre cada operação para simular processamento.

## Requisitos

- Criar o arquivo `numeros.txt`.
- Usar `StreamWriter` para escrever os números no arquivo.
- Usar `await writer.WriteLineAsync(...)` para gravar cada número.
- Usar `await writer.FlushAsync()` para garantir a escrita imediata.
- Usar `await Task.Delay(...)` entre uma gravação e outra.
- Mostrar no console uma mensagem para cada número gravado.
- Ao final, exibir uma mensagem informando que o processo assíncrono terminou.

## Objetivo da prática

- Praticar escrita assíncrona em arquivo.
- Entender o uso de `WriteLineAsync`, `FlushAsync` e `Task.Delay`.
- Comparar o estilo assíncrono com uma implementação tradicional síncrona.

## Desafio extra

- Criar também uma versão síncrona e comparar o código.
- Usar `Stopwatch` para medir o tempo total de execução.
