# 03 - Validacao de Usuario

## Enunciado

Com base no exemplo da aula, crie uma aplicação de console organizada em pastas `Models`, `Servicos` e `Erros` para validar os dados de um usuário.

O sistema deve trabalhar com um modelo `Usuario` contendo os campos `Nome`, `Email` e `Telefone`.

## Requisitos

- Criar uma pasta `Models` com a classe `Usuario`.
- Criar uma pasta `Servicos` com a classe `UsuarioServico`.
- Criar uma pasta `Erros` com exceções customizadas.
- Criar ao menos as seguintes exceções:
- `VazioException` para campos não preenchidos.
- `SomenteNumerosException` para telefone com caracteres inválidos.
- `EmailValidationException` para e-mail fora do formato esperado.
- No serviço, validar:
- Nome obrigatório.
- E-mail obrigatório e contendo `@`.
- Telefone obrigatório e contendo somente números.
- No `Program.cs`, criar exemplos que disparem cada exceção e um exemplo válido.
- Usar `try`, `catch` e `finally` em cada cenário de teste.

## Desafio extra

- Criar um método separado para cada validação.
- Exibir uma mensagem de sucesso quando o usuário for validado corretamente.

