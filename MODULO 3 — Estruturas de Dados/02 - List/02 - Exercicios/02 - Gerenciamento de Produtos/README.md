### Exercício 02 - Gerenciamento de Produtos com List

**Cenário**  
Você foi contratado para criar um pequeno módulo de controle de estoque em C#. Os produtos devem ser armazenados em uma **List**, permitindo cadastrar, listar e remover produtos.

Cada produto deve ter:
- Nome
- Preço
- Quantidade em estoque

### Funcionalidades do sistema

O programa deve apresentar um **menu interativo**, permitindo:

1. **Cadastrar novo produto**
   - Ler nome, preço e quantidade.
   - Validar as entradas numéricas com `double.TryParse` (para preço) e `int.TryParse` (para quantidade).
   - Armazenar o produto na lista.

2. **Listar produtos**
   - Mostrar todos os produtos cadastrados.
   - Exibir: nome, preço, quantidade e o **valor total em estoque** daquele produto (`preço * quantidade`).

3. **Remover produto**
   - Permitir que o usuário escolha um produto pelo **nome** ou pelo **índice** na lista para remover.
   - Caso o produto não seja encontrado, exibir mensagem apropriada.

4. **Sair**

### Exemplo de menu

```
Menu:
1 - Cadastrar novo produto
2 - Listar produtos
3 - Remover produto
4 - Sair
Escolha uma opção:
```

### Requisitos Técnicos

- Criar uma **classe `Produto`** com propriedades:
  - `Nome` (string)
  - `Preco` (double)
  - `Quantidade` (int)
- Usar uma **List<Produto>** para armazenar os produtos.
- Validar todas as entradas numéricas com `TryParse`.
- Usar laços (`while`/`do...while` e `foreach`/`for`) para controlar o menu e percorrer a lista.
- Usar interpolação de string (`$"..."`) para exibir as informações no console.

### Desafios extras (opcional)

- Calcular e exibir o **valor total do estoque geral** (somando o total de todos os produtos).
- Permitir **editar** os dados de um produto já cadastrado (preço e quantidade).
- Permitir busca de produto por parte do nome (por exemplo, todos que contenham "Mouse").

