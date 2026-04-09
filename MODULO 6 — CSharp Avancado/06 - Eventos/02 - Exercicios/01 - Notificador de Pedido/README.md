# 01 - Notificador de Pedido

## Enunciado

Crie uma aplicacao de console em C# para simular a finalizacao de pedidos com eventos.

Quando um pedido for finalizado, diferentes handlers devem ser acionados para notificar o cliente em canais distintos.

## Requisitos

- Criar uma classe `PedidoService` com o evento `PedidoFinalizado` usando `EventHandler`.
- Implementar o metodo `FinalizarPedido()` que simula o processo e dispara o evento.
- Criar pelo menos 3 handlers: `EnviarEmail`, `EnviarSms` e `RegistrarLog`.
- Inscrever os handlers no `Main` usando `+=`.
- Executar a finalizacao do pedido e mostrar as mensagens no console.
- Usar o operador `?.Invoke` para disparar o evento com seguranca.

## Objetivo da pratica

- Entender a estrutura basica de eventos em C#.
- Praticar inscricao de multiplos handlers para o mesmo evento.
- Fixar o fluxo "publisher/subscriber" em um exemplo realista.

## Desafio extra

- Remover temporariamente um handler com `-=` e executar novamente.
- Adicionar um handler com expressao lambda para exibir um callback extra.
