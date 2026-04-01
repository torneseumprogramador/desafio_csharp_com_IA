# 02 - Cadastro de Produto

## Enunciado

Crie uma aplicação de console em C# para cadastrar um produto com os campos `Nome`, `Preco` e `Codigo`.

Durante o cadastro, implemente validações com exceções customizadas, seguindo a mesma ideia da aula com a pasta `Erros`.

## Requisitos

- Criar uma pasta `Erros`.
- Criar uma exceção customizada para campo vazio.
- Criar uma exceção customizada para valor numérico inválido.
- Criar uma exceção customizada para preço inválido.
- Solicitar ao usuário o nome, o preço e o código do produto.
- Validar:
- O nome não pode ser vazio.
- O código deve conter somente números.
- O preço deve ser maior que zero.
- Exibir mensagens diferentes para cada tipo de erro usando `catch` específicos.
- Exibir uma mensagem final no bloco `finally`.

## Desafio extra

- Criar uma classe `Produto`.
- Criar um método `ValidarProduto()` para concentrar as validações.
