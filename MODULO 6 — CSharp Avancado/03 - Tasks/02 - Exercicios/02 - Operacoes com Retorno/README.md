# 02 - Operacoes com Retorno

## Enunciado

Crie uma aplicação de console em C# com um método assíncrono que retorne uma `Task<string>`.

O programa deve chamar esse método, exibir informações sobre o objeto `Task` antes da conclusão e depois aguardar o resultado final para mostrá-lo na tela.

## Requisitos

- Criar um método `MinhaOperacaoAsync()` que retorne `Task<string>`.
- Dentro do método, usar `await Task.Delay(...)` para simular uma operação demorada.
- Ao chamar o método, armazenar a task em uma variável.
- Exibir no console o objeto da task.
- Exibir o `Status` da task logo após a chamada.
- Usar `await` para obter o resultado final.
- Exibir o resultado retornado.
- Exibir novamente o `Status` da task após o `await`.

## Objetivo da prática

- Entender que métodos assíncronos retornam `Task` ou `Task<T>`.
- Praticar captura do resultado de uma task.
- Observar a mudança de estado da task durante a execução.

## Desafio extra

- Criar uma versão usando `Wait()` e `Result`.
- Comparar a diferença entre a abordagem com `await` e a abordagem bloqueante.
