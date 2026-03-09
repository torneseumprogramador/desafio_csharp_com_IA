### Exercício 02 - Estoque de Produtos com Dictionary (sem classes)

**Cenário**  
Você está criando um módulo de controle de estoque em C#. Cada produto será identificado por um **código único** (por exemplo, `"P001"`, `"P002"`), e os dados serão armazenados em um **`Dictionary<string, (string nome, int quantidade)>`** (um dicionário de **tuplas**).

Cada produto deve ter:
- Código (chave do dicionário, `string`)
- Nome (`string`, dentro da tupla)
- Quantidade em estoque (`int`, dentro da tupla)

### Funcionalidades do sistema

O programa deve apresentar um **menu interativo**, permitindo:

1. **Cadastrar/atualizar produto**
   - Ler código, nome e quantidade.
   - Se o código **ainda não existir** no dicionário, adicionar um novo produto.
   - Se o código **já existir**, atualizar apenas a quantidade (somar ao valor atual ou substituir, a seu critério).

2. **Consultar produto por código**
   - Perguntar o código do produto.
   - Verificar se o código existe no dicionário usando `ContainsKey` ou `TryGetValue`.
   - Exibir nome e quantidade em estoque, se existir.

3. **Listar todos os produtos**
   - Percorrer o dicionário (`foreach`) e mostrar código, nome e quantidade de cada produto.

4. **Remover produto**
   - Perguntar o código e remover do dicionário, se existir.

5. **Sair**

### Exemplo de menu

```
Menu:
1 - Cadastrar/Atualizar produto
2 - Consultar produto por código
3 - Listar todos os produtos
4 - Remover produto
5 - Sair
Escolha uma opção:
```

### Requisitos Técnicos

- **Não usar classes/objetos personalizados** (`Produto` etc.).
- Usar um **`Dictionary<string, (string Nome, int Quantidade)>`** onde:
  - A **chave** é o código (`string`).
  - O **valor** é uma **tupla** contendo nome e quantidade.
- Acessar os campos da tupla, por exemplo: `estoque[codigo].Nome` e `estoque[codigo].Quantidade`.
- Usar métodos do `Dictionary` como:
  - `Add`, `ContainsKey`, `Remove`, `TryGetValue`, indexador `dict[chave]`.
- Validar entradas numéricas com `int.TryParse`.
- Usar laços (`while`/`do...while`) para o menu e `foreach` para percorrer o dicionário.

### Desafios extras (opcional)

- Exibir o **total geral de itens em estoque** (somando a quantidade de todos os produtos).
- Permitir alterar o **nome** de um produto já cadastrado.
- Permitir que o usuário procure produtos por parte do nome (por exemplo, todos que contenham `"Mouse"`).

