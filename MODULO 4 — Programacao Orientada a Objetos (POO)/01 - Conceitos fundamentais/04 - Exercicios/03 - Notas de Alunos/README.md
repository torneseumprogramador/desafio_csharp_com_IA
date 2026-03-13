### Exercício 03 - Notas de Alunos

**Objetivo**  
Criar um sistema de cadastro de alunos e notas seguindo a mesma estrutura do `03 - Exemplo`, com **namespaces**, **subpastas** e **classes com propriedades, construtores e lista estática**.

### Estrutura esperada do projeto

```
04 - Exercicios/03 - Notas de Alunos/
├── Program.cs                          → apenas chama Menu.executarOpcoes()
├── Menu.cs                             → menu principal (raiz)
└── Algoritimos/
    └── Alunos/
        ├── Aluno.cs                    → classe Aluno (namespace Algoritimos.Alunos)
        └── Menu.cs                     → menu do módulo de alunos (namespace Algoritimos.Alunos)
```

### O que cada arquivo deve fazer

**`Aluno.cs`** (`namespace Algoritimos.Alunos`)
- Classe `Aluno` com:
  - Propriedades: `Nome`, `Notas` (um `double[]` de 3 posições)
  - Construtor vazio (inicializando `Notas = new double[3]`) e construtor com parâmetros (`nome`, `double[] notas`)
  - Uma lista estática `private static List<Aluno> _alunos`
  - Métodos estáticos:
    - `Adicionar(Aluno aluno)` — adiciona à lista
    - `Listar()` — retorna a lista
    - `Mostrar()` — exibe todos os alunos em formato de tabela com: Nome, Nota 1, Nota 2, Nota 3, Média
  - Método de instância (opcional):
    - `CalcularMedia()` — retorna a média das 3 notas do aluno

**`Menu.cs`** (`namespace Algoritimos.Alunos`)
- Classe `Menu` com método `executar()` que:
  - Pede o nome do aluno
  - Pede as 3 notas (validando cada uma com `double.TryParse`)
  - Cria um `new Aluno()` e preenche as propriedades
  - Chama `Aluno.Adicionar(aluno)`
  - Pergunta se quer cadastrar outro (s/n)
  - Ao final, chama `Aluno.Mostrar()`

**`Menu.cs`** (raiz do projeto)
- Menu principal com opções:
  - `1 - Cadastrar alunos e notas`
  - `2 - Sair`
- A opção 1 chama `Algoritimos.Alunos.Menu.executar()`

**`Program.cs`**
- Apenas: `Menu.executarOpcoes();`

### Requisitos técnicos

- Usar `namespace Algoritimos.Alunos;` nos arquivos dentro da pasta `Algoritimos/Alunos/`.
- Usar **propriedades** com get/set automático.
- Usar **construtores** (vazio e com parâmetros).
- Usar lista estática (`List<Aluno>`) dentro da própria classe `Aluno`.
- Usar um **array fixo de 3 posições** (`double[]`) para as notas.
- Validar entradas numéricas com `double.TryParse`.
- Formatar a tabela de saída com `PadRight`, incluindo a média calculada.

### Desafios extras (opcional)

- Mostrar no final da tabela a **média geral da turma**.
- Exibir ao lado de cada aluno se está **Aprovado** (média >= 7) ou **Reprovado** (média < 7).
- Permitir buscar um aluno pelo nome e ver suas notas individuais.
