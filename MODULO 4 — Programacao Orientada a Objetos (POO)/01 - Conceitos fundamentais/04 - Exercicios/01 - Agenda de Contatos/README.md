### Exercício 01 - Agenda de Contatos

**Objetivo**  
Criar um projeto com a mesma estrutura do `03 - Exemplo`, organizando o código em **namespaces**, **subpastas** e **classes separadas**.

### Estrutura esperada do projeto

```
04 - Exercicios/01 - Agenda de Contatos/
├── Program.cs                          → apenas chama Menu.executarOpcoes()
├── Menu.cs                             → menu principal (raiz)
└── Algoritimos/
    └── Contatos/
        ├── Contato.cs                  → classe Contato (namespace Algoritimos.Contatos)
        └── Menu.cs                     → menu do módulo de contatos (namespace Algoritimos.Contatos)
```

### O que cada arquivo deve fazer

**`Contato.cs`** (`namespace Algoritimos.Contatos`)
- Classe `Contato` com:
  - Propriedades: `Nome`, `Telefone`, `Email`
  - Construtor vazio e construtor com parâmetros (`nome`, `telefone`, `email`)
  - Uma lista estática `private static List<Contato> _contatos`
  - Métodos estáticos:
    - `Adicionar(Contato contato)` — adiciona à lista
    - `Listar()` — retorna a lista
    - `Mostrar()` — exibe todos os contatos em formato de tabela (como `Usuario.Mostrar()` no exemplo)
    - `BuscarPorNome(string nome)` — percorre a lista e retorna o contato encontrado (ou null)

**`Menu.cs`** (`namespace Algoritimos.Contatos`)
- Classe `Menu` com método `executar()` que:
  - Pede nome, telefone e email ao usuário
  - Cria um `new Contato()` e preenche as propriedades
  - Chama `Contato.Adicionar(contato)`
  - Pergunta se quer cadastrar outro (s/n)
  - Ao final, chama `Contato.Mostrar()`

**`Menu.cs`** (raiz do projeto)
- Menu principal com opções:
  - `1 - Cadastrar contatos`
  - `2 - Sair`
- A opção 1 chama `Algoritimos.Contatos.Menu.executar()`

**`Program.cs`**
- Apenas: `Menu.executarOpcoes();`

### Requisitos técnicos

- Usar `namespace Algoritimos.Contatos;` nos arquivos dentro da pasta `Algoritimos/Contatos/`.
- Usar **propriedades** com get/set automático.
- Usar **construtores** (vazio e com parâmetros).
- Usar lista estática (`List<Contato>`) dentro da própria classe `Contato`.
- Formatar a saída com tabela usando `PadRight` (como no exemplo de `Usuario.Mostrar()`).

### Desafios extras (opcional)

- Adicionar opção no menu principal para listar e buscar contatos (sem precisar cadastrar primeiro).
- Permitir remover um contato pelo nome.
- Adicionar validação para não permitir contatos com nome duplicado.
