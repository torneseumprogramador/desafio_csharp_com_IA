### Exercício 02 - Loja de Produtos

**Objetivo**  
Criar um projeto de controle de produtos seguindo a mesma estrutura do `03 - Exemplo`, com **namespaces**, **subpastas** e **classes com propriedades, construtores e lista estática**.

### Estrutura esperada do projeto

```
04 - Exercicios/02 - Loja de Produtos/
├── Program.cs                          → apenas chama Menu.executarOpcoes()
├── Menu.cs                             → menu principal (raiz)
└── Algoritimos/
    └── Produtos/
        ├── Produto.cs                  → classe Produto (namespace Algoritimos.Produtos)
        └── Menu.cs                     → menu do módulo de produtos (namespace Algoritimos.Produtos)
```

### O que cada arquivo deve fazer

**`Produto.cs`** (`namespace Algoritimos.Produtos`)
- Classe `Produto` com:
  - Propriedades: `Nome`, `Preco` (double), `Quantidade` (int)
  - Construtor vazio e construtor com parâmetros (`nome`, `preco`, `quantidade`)
  - Uma lista estática `private static List<Produto> _produtos`
  - Métodos estáticos:
    - `Adicionar(Produto produto)` — adiciona à lista
    - `Listar()` — retorna a lista
    - `Mostrar()` — exibe todos os produtos em formato de tabela com colunas: Nome, Preço, Quantidade, Total (preço × quantidade)
    - `CalcularTotalEstoque()` — retorna a soma de (preço × quantidade) de todos os produtos

**`Menu.cs`** (`namespace Algoritimos.Produtos`)
- Classe `Menu` com método `executar()` que:
  - Pede nome, preço e quantidade ao usuário
  - Valida preço com `double.TryParse` e quantidade com `int.TryParse`
  - Cria um `new Produto()` e preenche as propriedades
  - Chama `Produto.Adicionar(produto)`
  - Pergunta se quer cadastrar outro (s/n)
  - Ao final, chama `Produto.Mostrar()` e exibe o valor total do estoque

**`Menu.cs`** (raiz do projeto)
- Menu principal com opções:
  - `1 - Cadastrar produtos`
  - `2 - Sair`
- A opção 1 chama `Algoritimos.Produtos.Menu.executar()`

**`Program.cs`**
- Apenas: `Menu.executarOpcoes();`

### Requisitos técnicos

- Usar `namespace Algoritimos.Produtos;` nos arquivos dentro da pasta `Algoritimos/Produtos/`.
- Usar **propriedades** com get/set automático.
- Usar **construtores** (vazio e com parâmetros).
- Usar lista estática (`List<Produto>`) dentro da própria classe `Produto`.
- Validar entradas numéricas com `TryParse`.
- Formatar a tabela de saída com `PadRight`.

### Desafios extras (opcional)

- Permitir buscar um produto por nome e exibir suas informações.
- Permitir atualizar a quantidade de um produto existente.
- Mostrar separadamente os produtos com quantidade zero ("sem estoque").
