### Exercício 02 - Herança com Veículos

**Objetivo**  
Praticar **herança** criando uma classe base para veículos e classes filhas especializadas, reutilizando propriedades comuns.

### O que fazer

1. Crie uma classe base `Veiculo` com propriedades:
   - `Marca` (string)
   - `Modelo` (string)
   - `Ano` (int)
2. Crie classes filhas que herdam de `Veiculo`:
   - `Carro` : `Veiculo`
     - Propriedade extra: `QuantidadePortas` (int)
   - `Moto` : `Veiculo`
     - Propriedade extra: `Cilindrada` (int)
3. No `Program.cs`:
   - Crie pelo menos um objeto de cada tipo (`Carro` e `Moto`).
   - Preencha as propriedades herdadas e específicas.
   - Exiba no console as informações de cada veículo.

### Requisitos técnicos

- Usar herança simples (`class Carro : Veiculo`, `class Moto : Veiculo`).
- Não duplicar propriedades nas classes filhas; reaproveitar as da classe base.
- Organizar o código de forma clara (pode ser em arquivos separados).

### Desafios extras (opcional)

- Adicionar uma terceira classe filha, por exemplo, `Caminhao : Veiculo` com propriedade `CapacidadeCarga` (double ou int).
- Criar um método na classe `Veiculo` que retorne uma descrição (`string`) com as principais informações, e utilizar esse método nas filhas.
- Criar uma lista de `Veiculo` (`List<Veiculo>`) e adicionar `Carro`, `Moto` e `Caminhao`, percorrendo a lista e mostrando os dados de todos.

