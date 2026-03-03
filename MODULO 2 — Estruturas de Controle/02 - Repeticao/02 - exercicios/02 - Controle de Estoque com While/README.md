### Exercício 02 - Controle de Estoque com While

**Cenário real**  
Uma pequena loja quer registrar, durante o dia, as entradas e saídas de produtos para acompanhar o saldo de estoque em tempo real.

### Objetivo

Criar um programa em C# que:

- **Permita registrar repetidamente** movimentações de estoque (entrada ou saída).
- **Leia** a quantidade de itens movimentados (sempre um número inteiro positivo).
- **Valide** todas as entradas usando `int.TryParse`.
- **Atualize** o saldo atual de estoque usando operadores aritméticos.
- **Pare** o processo quando o usuário informar um código de saída (por exemplo, `0`).

### Comportamento sugerido

1. Começar com um **estoque inicial** (por exemplo, 0 itens).
2. Em um laço `while`, exibir um pequeno menu:
   - `1 - Registrar ENTRADA de produtos`
   - `2 - Registrar SAÍDA de produtos`
   - `0 - Sair`
3. Ler a opção do usuário e validar com `int.TryParse`.
   - Se for `0`, encerrar o laço.
   - Se for `1` ou `2`, continuar.
   - Qualquer outro valor: mostrar `"Opção inválida"` e voltar para o menu.
4. Se a opção for **entrada**:
   - Pedir a quantidade de produtos a adicionar.
   - Validar com `int.TryParse`.
   - Somar ao estoque atual.
5. Se a opção for **saída**:
   - Pedir a quantidade de produtos a remover.
   - Validar com `int.TryParse`.
   - Verificar com um `if` se há estoque suficiente:
     - Se tiver, subtrair do estoque.
     - Se não tiver, mostrar `"Quantidade insuficiente em estoque"` e **não** alterar o saldo.
6. Após cada movimentação válida, exibir o saldo atual:
   - `"Estoque atual: X itens"`.

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine` para entrada e saída.
- Usar `int.TryParse` para validar:
  - Opção do menu.
  - Quantidade de produtos.
- Usar uma estrutura de repetição `while` para manter o programa em execução até que o usuário escolha sair (`0`).
- Usar condicionais `if`, `else if` e `else` para:
  - Tratar opções do menu.
  - Validar se há estoque suficiente na saída.
- Usar operadores aritméticos:
  - `+` para entrada.
  - `-` para saída.
- Usar variáveis do tipo `int` e, se quiser, `string` para mensagens.

### Exemplo de execução (apenas ilustrativo)

- Estoque inicial: `0`
- Usuário escolhe `1` (entrada) e informa quantidade `10` → estoque passa a `10`.
- Usuário escolhe `2` (saída) e informa quantidade `4` → estoque passa a `6`.
- Usuário escolhe `2` (saída) e informa quantidade `20` → mensagem `"Quantidade insuficiente em estoque"`, estoque continua `6`.
- Usuário escolhe `0` → programa exibe mensagem final e encerra.

### Desafios extras (opcional)

- Permitir que o usuário informe um **estoque inicial** no começo do programa.
- Armazenar, em uma variável separada, o **total de entradas** e o **total de saídas** durante o dia e mostrar um resumo ao final:
  - `"Total de entradas: X itens"`
  - `"Total de saídas: Y itens"`
  - `"Saldo final: Z itens"`
- Usar um operador ternário para montar uma mensagem curta:
  - Ex.: `string situacao = estoqueAtual < 0 ? "Estoque negativo" : "Estoque ok";`

