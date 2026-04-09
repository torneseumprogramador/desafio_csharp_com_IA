# 03 - Monitoramento de Tarefa Assincrona

## Enunciado

Crie uma aplicacao de console em C# que simule uma tarefa demorada e dispare um evento ao terminar.

Enquanto a tarefa principal estiver em execucao, o programa deve continuar executando outras operacoes em paralelo.

## Requisitos

- Criar uma classe `ProcessamentoFinalizadoEventArgs` com a propriedade `Mensagem`.
- Criar a classe `ServicoProcessamento` com evento `ProcessamentoFinalizado` usando `EventHandler<ProcessamentoFinalizadoEventArgs>`.
- Implementar o metodo assincrono `ExecutarProcessamentoAsync()` com `await Task.Delay(...)`.
- Disparar o evento ao final do processamento usando um metodo protegido `OnProcessamentoFinalizado(...)`.
- No `Main`, inscrever pelo menos 2 handlers (um metodo e uma lambda).
- Executar um loop no `Main` enquanto a tarefa roda para mostrar que o programa nao ficou bloqueado.

## Objetivo da pratica

- Entender o uso de eventos junto com `async/await`.
- Praticar notificacoes reativas ao termino de tarefas demoradas.
- Consolidar o conceito de concorrencia basica em aplicacoes de console.

## Desafio extra

- Medir o tempo total de processamento com `Stopwatch` e enviar no evento.
- Criar um handler que salve a mensagem em arquivo texto.
