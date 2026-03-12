### Exercício 01 - Agenda de Contatos Orientada a Objetos

**Objetivo**  
Criar uma pequena **agenda de contatos** usando **classes** e **arquivos separados**, deixando o código mais organizado que nos módulos anteriores.

### Regras gerais

- Crie uma **classe `Contato`** em um arquivo próprio (`Contato.cs`) com:
  - Propriedades: `Nome`, `Telefone`, `Email`.
- Crie uma **classe `Agenda`** em outro arquivo (`Agenda.cs`) que:
  - Tenha uma lista de contatos (por exemplo, `List<Contato>`).
  - Tenha métodos para:
    - Adicionar contato
    - Listar contatos
    - Buscar contato pelo nome
    - Remover contato pelo nome
- Crie uma **classe `Program` ou `Menu`** em um arquivo separado (`Program.cs` ou `Menu.cs`) que:
  - Mostre um **menu no console** com opções:
    - `1 - Adicionar contato`
    - `2 - Listar contatos`
    - `3 - Buscar contato`
    - `4 - Remover contato`
    - `5 - Sair`
  - Leia a opção e chame os métodos da `Agenda`.

### Requisitos técnicos

- Organizar o código em **pelo menos 3 arquivos** (`Contato.cs`, `Agenda.cs`, `Program.cs`/`Menu.cs`).
- Usar **propriedades** da classe (get/set automáticos simples) para os dados do contato.
- Usar uma coleção (`List<Contato>`) **dentro da classe** `Agenda`.
- O `Program` (ou `Menu`) **não deve manipular diretamente a lista**, apenas chamar métodos da `Agenda`.

### Desafios extras (opcional)

- Implementar uma busca parcial (por exemplo, todos os contatos que contêm um pedaço do nome digitado).
- Permitir editar os dados de um contato existente.
- Separar o menu em uma classe própria (`Menu.cs`), semelhante ao exemplo de aula (`Menu` chamando métodos de outra classe).

