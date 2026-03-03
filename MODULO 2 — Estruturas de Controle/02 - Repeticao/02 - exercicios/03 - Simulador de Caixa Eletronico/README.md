### Exercício 03 - Simulador de Caixa Eletrônico com Menu e Repetição

**Cenário real**  
Um banco precisa de um protótipo simples de caixa eletrônico (ATM) para simular operações básicas como depósito, saque e consulta de saldo.

### Objetivo

Criar um programa em C# que:

- **Simule um menu de operações bancárias** usando repetição.
- **Permita** ao usuário fazer depósitos, saques e consultar o saldo várias vezes, até escolher sair.
- **Valide** as entradas numéricas usando `double.TryParse` ou `decimal.TryParse`.
- **Use** condicionais para verificar se há saldo suficiente nos saques.

### Comportamento sugerido

1. Definir um **saldo inicial** (por exemplo, `0`).
2. Em um laço `while` ou `do...while`, exibir um menu como:
   - `1 - Depositar`
   - `2 - Sacar`
   - `3 - Consultar saldo`
   - `0 - Sair`
3. Ler a opção digitada e validar com `int.TryParse`.
   - Se a conversão falhar, mostrar `"Opção inválida"` e voltar ao menu.
4. Se a opção for:
   - **1 - Depositar**:
     - Pedir o valor do depósito.
     - Validar com `double.TryParse`.
     - Se o valor for **maior que zero**, somar ao saldo.
     - Caso contrário, mostrar `"Valor de depósito inválido"`.
   - **2 - Sacar**:
     - Pedir o valor do saque.
     - Validar com `double.TryParse`.
     - Verificar com `if`:
       - Se o valor for **maior que o saldo**, mostrar `"Saldo insuficiente"` e não alterar o saldo.
       - Se o valor for **positivo e menor ou igual ao saldo**, subtrair do saldo.
   - **3 - Consultar saldo**:
     - Mostrar o saldo atual formatado, por exemplo: `"Saldo atual: R$ 100,00"`.
   - **0 - Sair**:
     - Encerrar o laço e exibir uma mensagem de despedida.
   - Qualquer outro valor:
     - Mostrar `"Opção inválida"`.

### Requisitos técnicos

- Usar `Console.WriteLine` e `Console.ReadLine` para entrada e saída.
- Usar `int.TryParse` para a opção do menu.
- Usar `double.TryParse` (ou `decimal.TryParse`) para os valores de depósito e saque.
- Usar pelo menos uma estrutura de repetição (`while` ou `do...while`) para manter o menu sendo exibido até o usuário escolher sair.
- Usar condicionais `if` / `else if` / `else` para tratar:
  - Opções do menu.
  - Validação de saldo suficiente.
  - Validação de valores positivos.
- Usar operadores aritméticos (`+` e `-`) para atualizar o saldo.

### Exemplo de execução (apenas ilustrativo)

- Saldo inicial: `R$ 0,00`
- Usuário escolhe `1` (depositar) e informa `100` → saldo passa a `R$ 100,00`.
- Usuário escolhe `2` (sacar) e informa `30` → saldo passa a `R$ 70,00`.
- Usuário escolhe `3` (consultar saldo) → mostra `"Saldo atual: R$ 70,00"`.
- Usuário escolhe `2` (sacar) e informa `100` → mensagem `"Saldo insuficiente"`, saldo continua `R$ 70,00`.
- Usuário escolhe `0` → programa encerra.

### Desafios extras (opcional)

- Pedir também o **nome do titular** da conta e mostrar esse nome em todas as mensagens de saldo.
- Adicionar uma opção `4 - Exibir extrato simples`, guardando em uma string (ou em várias variáveis) um histórico básico das operações realizadas.
- Usar um **operador ternário** para exibir uma mensagem rápida sobre o saldo:
  - Ex.: `string status = saldo <= 0 ? "Conta zerada ou negativa" : "Conta com saldo positivo";`

