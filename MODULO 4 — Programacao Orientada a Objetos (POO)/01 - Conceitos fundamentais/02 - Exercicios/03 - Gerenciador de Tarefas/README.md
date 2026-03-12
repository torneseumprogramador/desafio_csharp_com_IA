### Exercício 03 - Gerenciador de Tarefas com POO

**Objetivo**  
Criar um **gerenciador de tarefas** (to‑do list) usando **classes**, separando responsabilidades em arquivos diferentes, para treinar organização de código orientado a objetos.

### Regras gerais

- Crie uma **classe `Tarefa`** em `Tarefa.cs` com propriedades:
  - `Descricao`
  - `Concluida` (bool)
  - (opcional) `DataCriacao` ou `Prioridade` (int ou enum simples).
- Crie uma **classe `GerenciadorDeTarefas`** em `GerenciadorDeTarefas.cs` que:
  - Possua uma coleção `List<Tarefa>`.
  - Tenha métodos para:
    - Adicionar nova tarefa
    - Listar todas as tarefas
    - Listar apenas tarefas concluídas / não concluídas
    - Marcar uma tarefa como concluída
    - Remover tarefa
- Crie uma **classe `Program` ou `Menu`** em `Program.cs` (ou `Menu.cs`) que:
  - Mostre um menu como:
    - `1 - Adicionar tarefa`
    - `2 - Listar todas as tarefas`
    - `3 - Listar apenas pendentes`
    - `4 - Marcar tarefa como concluída`
    - `5 - Remover tarefa`
    - `6 - Sair`
  - Leia a opção digitada e chame os métodos do `GerenciadorDeTarefas`.

### Requisitos técnicos

- Separar o código em **arquivos diferentes** (`Tarefa.cs`, `GerenciadorDeTarefas.cs`, `Program.cs`/`Menu.cs`).
- Usar propriedades para acessar os dados da tarefa.
- Manter a lista de tarefas **encapsulada** dentro da classe `GerenciadorDeTarefas`.
- Deixar o `Program`/`Menu` responsável apenas pelo fluxo do programa e interação com o usuário (entrada/saída).

### Desafios extras (opcional)

- Permitir editar a descrição de uma tarefa existente.
- Permitir filtrar tarefas por uma palavra-chave digitada (ex.: todas que contenham "estudar").
- Exibir um pequeno resumo: quantidade total de tarefas, quantas concluídas e quantas pendentes.

