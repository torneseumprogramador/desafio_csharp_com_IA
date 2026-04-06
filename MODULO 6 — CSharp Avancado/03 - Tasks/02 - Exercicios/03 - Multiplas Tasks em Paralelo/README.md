# 03 - Multiplas Tasks em Paralelo

## Enunciado

Crie uma aplicação de console em C# que execute três operações assíncronas em paralelo e aguarde todas terminarem usando `Task.WhenAll`.

Cada operação deve simular um processamento demorado e retornar uma mensagem diferente ao final.

## Requisitos

- Criar um método assíncrono que retorne `Task<string>`.
- Iniciar três chamadas desse método e armazenar cada task em uma variável.
- Não usar `await` imediatamente em cada chamada.
- Usar `Task.WhenAll(...)` para aguardar as três operações ao mesmo tempo.
- Exibir todos os resultados ao final.
- Mostrar mensagens no console indicando o início e o fim do processamento.

## Objetivo da prática

- Praticar execução paralela com várias tasks.
- Entender o uso de `Task.WhenAll`.
- Perceber a vantagem de iniciar múltiplas operações antes de aguardar o resultado.

## Desafio extra

- Medir o tempo total de execução com `Stopwatch`.
- Comparar com uma versão em que as três operações são aguardadas uma por vez.
