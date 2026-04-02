# 01 - Buscando Dados em Paralelo

## Enunciado

Crie uma aplicação de console em C# que simule a busca de dados de dois processos diferentes usando `async/await`.

Cada processo deve levar alguns segundos para terminar, mas ambos devem ser iniciados em paralelo para que o programa aproveite melhor o tempo de espera.

## Requisitos

- Criar um método `BuscarDadosAsync(string nomeProcesso)` que retorne `Task<string>`.
- Dentro desse método, usar `await Task.Delay(...)` para simular uma operação demorada.
- No `Main`, iniciar duas tarefas assíncronas sem aguardar imediatamente.
- Enquanto as tarefas estão executando, mostrar mensagens no console indicando que o programa continua trabalhando.
- Usar `await Task.WhenAll(...)` para aguardar as duas tarefas terminarem.
- Exibir o resultado retornado por cada processo.

## Objetivo da prática

- Entender a diferença entre iniciar uma tarefa e aguardar seu resultado.
- Praticar `Task`, `await` e `Task.WhenAll`.
- Perceber como o programa pode continuar executando outras ações enquanto espera.

## Desafio extra

- Adicionar um terceiro processo assíncrono.
- Medir o tempo total de execução e comparar com uma versão sequencial.
