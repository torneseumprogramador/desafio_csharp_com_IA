# Exercicio 02 - CRUD Organizado por Entidade

## Objetivo
Separar a logica de CRUD por entidade em arquivos independentes para melhorar manutencao e escalabilidade do projeto.

## Cenario
O sistema cresceu e o `Program.cs` ficou muito grande. Sua tarefa e reorganizar o codigo para seguir um padrao mais limpo.

## Requisitos
- Criar uma pasta `Crud`.
- Criar uma classe para cada entidade:
  - `AutorCrud`
  - `LivroCrud`
  - `UsuarioCrud`
  - `EmprestimoCrud`
- Em cada classe, implementar os metodos:
  - `Criar`
  - `Ler`
  - `Atualizar`
  - `Excluir`
- Ajustar o `Program.cs` para apenas orquestrar chamadas dos metodos CRUD.

## Regras de implementacao
- Manter uso de `BibliotecaContext`.
- Usar `AsNoTracking` em operacoes de leitura.
- Utilizar `Include` quando a consulta depender de relacionamentos.
- Garantir ordem correta no delete para nao violar chave estrangeira.

## Entregaveis esperados
- Codigo compilando sem warnings.
- Execucao exibindo no console cada etapa de CRUD por entidade.
- `Program.cs` com responsabilidade reduzida (somente fluxo principal).

## Bonus
- Criar metodos de validacao simples (exemplo: impedir criacao de usuario com email duplicado).
