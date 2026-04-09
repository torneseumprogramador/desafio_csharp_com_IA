# 02 - Evento com Dados Personalizados

## Enunciado

Crie uma aplicacao de console em C# onde um sistema de entrega dispara um evento quando o pacote e enviado.

Esse evento deve transportar dados personalizados, como codigo do pacote e data de envio.

## Requisitos

- Criar uma classe `PacoteEnviadoEventArgs` herdando de `EventArgs`.
- Adicionar propriedades como `CodigoPacote` e `DataEnvio`.
- Criar a classe `EntregaService` com evento `PacoteEnviado` usando `EventHandler<PacoteEnviadoEventArgs>`.
- Implementar o metodo `EnviarPacote()` para gerar os dados e disparar o evento.
- Criar 2 handlers: um para exibir os dados no console e outro para simular gravacao em log.
- No `Main`, inscrever os handlers e chamar o envio do pacote.

## Objetivo da pratica

- Aprender a criar eventos fortemente tipados com `EventHandler<T>`.
- Entender como transportar informacoes no disparo de eventos.
- Praticar organizacao de classes para cenarios orientados a evento.

## Desafio extra

- Incluir status do pacote (`Postado`, `EmTransito`, `Entregue`) no `EventArgs`.
- Criar um terceiro handler com lambda para exibir apenas o codigo do pacote.
