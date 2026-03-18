### Exercício 03 - Partial Class e Sealed Class

**Conteúdo da aula**  
`partial class` (dividir a classe em partes) e `sealed class` (impedir herança).

### Objetivo

Criar uma classe dividida em **dois arquivos** com `partial` e também praticar o uso de `sealed` impedindo que uma classe seja herdada.

### Parte A — Partial class (em 2 arquivos)

1. Crie uma classe `partial` chamada `Veiculo`.
2. Divida a classe em **dois arquivos**:
   - `Veiculo.Dados.cs`:
     - Propriedades `Marca`, `Modelo`, `Ano`
   - `Veiculo.Acoes.cs`:
     - Métodos `Acelerar()` e `Frear()` exibindo mensagens no console
3. No `Program.cs`, instancie `Veiculo`, preencha as propriedades e chame `Acelerar()` e `Frear()`.

### Parte B — Sealed class

1. Crie uma classe `sealed` chamada `Celular` com propriedades:
   - `Marca`, `Modelo`, `Ano`
2. Tente criar uma classe `Iphone : Celular` (deixe comentado) e observe que o compilador não permite herdar de uma classe `sealed`.

### Requisitos técnicos

- `Veiculo` deve ser `partial` e estar **em 2 arquivos diferentes**.
- `Celular` deve ser `sealed`.
- Demonstrar no console o uso de `Veiculo` (propriedades + métodos).

### Desafios extras (opcional)

- Criar uma classe `partial` `Relatorio` em 2 arquivos:
  - Uma parte com métodos de formatação de texto
  - Outra parte com métodos que imprimem o relatório no console
- Criar uma classe base com método `virtual` e uma classe filha com `sealed override` (relembrando a parte de `sealed` em métodos).

