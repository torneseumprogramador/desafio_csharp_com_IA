### Exercício 01 - Herança com Pessoas

**Objetivo**  
Praticar **herança** criando uma hierarquia de classes semelhante ao exemplo de `Pessoa`, `PessoaFisica` e `PessoaJuridica`, reaproveitando propriedades e métodos da classe base.

### O que fazer

1. Crie uma classe base `Pessoa` com:
   - Propriedades: `Nome` (string), `Documento` (long).
   - Um método **protegido** (ou público, se preferir visualizar melhor) que verifica se o documento tem 11 dígitos.
2. Crie duas classes filhas:
   - `Aluno` : `Pessoa`
     - Propriedade extra: `Matricula` (string).
   - `Professor` : `Pessoa`
     - Propriedade extra: `Salario` (double).
3. No `Program.cs`:
   - Instancie um `Aluno` e um `Professor`.
   - Preencha as propriedades herdadas (`Nome`, `Documento`) e as específicas (`Matricula`, `Salario`).
   - Mostre no console os dados de cada um, reutilizando o que veio da classe base.

### Requisitos técnicos

- Usar `:` para indicar herança (`class Aluno : Pessoa`).
- Reaproveitar as propriedades da classe `Pessoa` nas classes filhas.
- Mostrar claramente no console que as classes filhas herdaram as propriedades da classe base.

### Desafios extras (opcional)

- Adicionar uma terceira classe filha, por exemplo, `FuncionarioAdministrativo : Pessoa`.
- Criar um método na classe base que retorne uma string com o nome e documento, e reutilizá-lo nas classes filhas.
- Colocar as classes em **arquivos separados** para deixar o código mais organizado.

