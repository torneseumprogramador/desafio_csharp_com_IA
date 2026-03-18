### Exercício 02 - Conta Bancária e Encapsulamento (public/private/protected/internal)

**Conteúdo da aula**  
Modificadores de acesso: `public`, `private`, `protected`, `internal`.

### Objetivo

Criar uma classe `ContaBancaria` aplicando **encapsulamento**, controlando o acesso aos dados e expondo apenas métodos seguros para manipular o saldo.

### Regras do exercício

1. Crie uma classe `ContaBancaria` com:
   - `public string Titular { get; set; }`
   - `public string NumeroConta { get; set; }`
   - Um campo **`private`** para armazenar o saldo (ex.: `private double _saldo;`)
2. Crie métodos públicos:
   - `Depositar(double valor)`:
     - Só aceita valores > 0
     - Atualiza o saldo
   - `Sacar(double valor)`:
     - Só aceita valores > 0
     - Só permite sacar se houver saldo suficiente
   - `ConsultarSaldo()`:
     - Retorna o saldo (ou exibe no console)
3. Crie um método **`protected`** ou **`internal`** (à sua escolha) para validar valores (ex.: `ValidarValor(double valor)`), para praticar os modificadores.

### O que exibir no console

- Em `Program.cs`, crie uma conta, faça alguns depósitos e saques e mostre o saldo final.
- Mostre mensagens claras para:
  - Depósito inválido
  - Saque inválido
  - Saldo insuficiente

### Requisitos técnicos

- O saldo **não pode** ser `public` (não pode permitir `conta.Saldo = ...` diretamente).
- Usar `private` para o saldo e métodos públicos para alterar/consultar.
- Utilizar pelo menos um dos modificadores `protected` ou `internal` em algum método ou propriedade.

### Desafios extras (opcional)

- Criar uma classe `ContaPoupanca : ContaBancaria` e adicionar um método para aplicar rendimento (por exemplo, 1%).
  - Aqui você treina herança + `protected` (se escolher usar).
- Criar um menu simples no console para depositar/sacar/consultar.

