### Exercício 03 - Lista de Tarefas com List

**Cenário**  
Você está criando um pequeno aplicativo de lista de tarefas (to-do list) em C#. As tarefas devem ser armazenadas em uma **List**, permitindo adicionar, marcar como concluídas e listar.

Cada tarefa deve ter:
- Descrição (texto da tarefa)
- Status (por exemplo: Pendente / Concluída)

### Funcionalidades do sistema

O programa deve apresentar um **menu interativo**, permitindo:

1. **Adicionar nova tarefa**
   - Ler a descrição da tarefa digitada pelo usuário.
   - Armazenar a tarefa na lista com status inicial \"Pendente\".

2. **Listar tarefas**
   - Mostrar todas as tarefas com seu índice, descrição e status.
   - Exemplo: `1 - [Pendente] Estudar C#`

3. **Marcar tarefa como concluída**
   - Permitir escolher uma tarefa pelo índice.
   - Alterar o status de \"Pendente\" para \"Concluída\".

4. **Remover tarefa** (opcional)
   - Permitir remover uma tarefa da lista pelo índice.

5. **Sair**

### Exemplo de menu

```
Menu:
1 - Adicionar tarefa
2 - Listar tarefas
3 - Marcar tarefa como concluída
4 - Remover tarefa
5 - Sair
Escolha uma opção:
```

### Requisitos Técnicos

- Criar uma **classe `Tarefa`** com propriedades:
  - `Descricao` (string)
  - `Concluida` (bool) ou uma propriedade `Status` (string).
- Usar uma **List<Tarefa>** para armazenar as tarefas.
- Usar laços (`while`/`do...while`) para o menu e `foreach`/`for` para percorrer a lista.
- Usar condicionais (`if/else`) para decidir mensagens (por exemplo, exibir \"[Concluída]\" ou \"[Pendente]\").
- Usar interpolação de string para exibir as tarefas formatadas.

### Desafios extras (opcional)

- Permitir filtrar a lista para mostrar apenas tarefas pendentes ou apenas concluídas.
- Permitir editar a descrição de uma tarefa.
- Exibir a quantidade total de tarefas pendentes e concluídas no relatório.

