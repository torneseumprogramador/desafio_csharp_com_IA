### Exercício 04 - Controle de Pedidos com List

**Cenário**  
Você está desenvolvendo um módulo simples de controle de pedidos para uma lanchonete. Cada pedido feito por um cliente deve ser armazenado em uma **List**, contendo informações básicas sobre o pedido.

Cada pedido deve ter:
- Número do pedido (código ou ID)
- Nome do cliente
- Descrição do item (ex.: \"X-Burger\", \"Pizza\", \"Refrigerante\")
- Valor total do pedido

### Funcionalidades do sistema

O programa deve apresentar um **menu interativo**, permitindo:

1. **Registrar novo pedido**
   - Ler número do pedido, nome do cliente, descrição do item e valor total.
   - Validar o valor com `double.TryParse`.
   - Armazenar o pedido na lista.

2. **Listar pedidos**
   - Mostrar todos os pedidos cadastrados.
   - Exibir: número do pedido, nome do cliente, item e valor total.

3. **Buscar pedido por número**
   - Permitir que o usuário digite o número de um pedido.
   - Exibir as informações do pedido correspondente, se existir.

4. **Cancelar pedido** (remover da lista)
   - Permitir cancelar/remover um pedido informando o número ou o índice na lista.
   - Se não encontrar, exibir mensagem apropriada.

5. **Sair**

### Exemplo de menu

```
Menu:
1 - Registrar novo pedido
2 - Listar pedidos
3 - Buscar pedido por número
4 - Cancelar pedido
5 - Sair
Escolha uma opção:
```

### Requisitos Técnicos

- Criar uma **classe `Pedido`** com propriedades:
  - `Numero` (int ou string)
  - `Cliente` (string)
  - `Item` (string)
  - `ValorTotal` (double)
- Usar uma **List<Pedido>** para armazenar os pedidos.
- Validar entradas numéricas com `TryParse`.
- Usar laços (`while`/`do...while`) para o menu e `foreach`/`for` para percorrer a lista.
- Usar condicionais para tratar casos de pedido não encontrado.
- Usar interpolação de string para formatar as saídas no console.

### Desafios extras (opcional)

- Calcular e exibir o **faturamento total** (soma do `ValorTotal` de todos os pedidos).
- Permitir filtrar pedidos por nome do cliente.
- Permitir atualizar o valor total de um pedido já existente.

