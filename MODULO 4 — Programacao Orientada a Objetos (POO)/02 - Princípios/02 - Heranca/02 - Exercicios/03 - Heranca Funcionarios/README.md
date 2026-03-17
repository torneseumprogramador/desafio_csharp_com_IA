### Exercício 03 - Herança com Funcionários

**Objetivo**  
Praticar **herança** em um cenário de funcionários de uma empresa, reaproveitando propriedades comuns em uma classe base e especializando em classes filhas.

### O que fazer

1. Crie uma classe base `Funcionario` com propriedades:
   - `Nome` (string)
   - `SalarioBase` (double)
2. Crie classes filhas que herdam de `Funcionario`:
   - `FuncionarioCLT` : `Funcionario`
     - Propriedade extra: `ValorBeneficios` (double)
   - `FuncionarioPJ` : `Funcionario`
     - Propriedade extra: `ValorContrato` (double)
3. Opcionalmente, crie também:
   - `Estagiario` : `Funcionario`
     - Propriedade extra: `BolsaAuxilio` (double)
4. No `Program.cs`:
   - Instancie pelo menos um objeto de cada tipo de funcionário.
   - Preencha as propriedades herdadas e específicas.
   - Exiba no console os dados de cada funcionário.

### Requisitos técnicos

- Usar herança simples (`class FuncionarioCLT : Funcionario`, etc.).
- Não duplicar propriedades comuns (`Nome`, `SalarioBase`) nas classes filhas.
- Organizar o código de forma clara (recomendado: uma classe por arquivo).

### Desafios extras (opcional)

- Criar um método na classe base `Funcionario` que retorne uma descrição (`string`) com nome e salário base, e reutilizá-lo nas subclasses.
- Adicionar um método em cada classe filha para calcular o **custo total** do funcionário para a empresa (por exemplo, salário base + benefícios, ou valor do contrato).
- Criar uma lista `List<Funcionario>` e adicionar `FuncionarioCLT`, `FuncionarioPJ` e `Estagiario`, percorrendo a lista para exibir os dados e o custo total de cada um.

