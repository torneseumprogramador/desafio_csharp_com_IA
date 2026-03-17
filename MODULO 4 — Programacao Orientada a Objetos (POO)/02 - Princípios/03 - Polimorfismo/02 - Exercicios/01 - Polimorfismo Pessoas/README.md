### Exercício 03 - Polimorfismo com Pessoas

**Objetivo**  
Praticar **polimorfismo** sobrescrevendo métodos (`override`) em classes filhas, semelhante ao exemplo de `Pessoa`, `PessoaFisica` e `PessoaJuridica`.

### O que fazer

1. Crie uma classe base `Pessoa` com:
   - Propriedades: `Nome` (string), `Documento` (long).
   - Método `public virtual string TipoPessoa()` que retorna `"Pessoa"`.
   - Método `public virtual string Descricao()` que retorna algo como:  
     `$"Nome: {Nome} - Documento: {Documento} - Tipo: {TipoPessoa()}"`.
2. Crie duas classes filhas:
   - `PessoaFisica` : `Pessoa`
     - Propriedade extra: `RG` (string).
     - Sobrescreva `TipoPessoa()` retornando `"Pessoa Física"`.
     - (Opcional) sobrescreva `Descricao()` acrescentando o `RG` no texto.
   - `PessoaJuridica` : `Pessoa`
     - Propriedade extra: `InscricaoEstadual` (string).
     - Sobrescreva `TipoPessoa()` retornando `"Pessoa Jurídica"`.
     - (Opcional) sobrescreva `Descricao()` acrescentando a inscrição estadual.
3. No `Program.cs`:
   - Crie uma lista `List<Pessoa>` e adicione objetos de `PessoaFisica` e `PessoaJuridica`.
   - Percorra a lista e chame `Descricao()` para cada item.
   - Observe que o método chamado em tempo de execução depende do **tipo real** do objeto (polimorfismo).

### Requisitos técnicos

- Usar `virtual` na classe base e `override` nas classes filhas.
- Tratar todos os objetos como `Pessoa` (tipo da lista), mas com comportamentos diferentes ao chamar `Descricao()` e `TipoPessoa()`.
- Demonstrar no console que o comportamento muda conforme o tipo da classe filha.

### Desafios extras (opcional)

- Adicionar uma terceira classe filha (por exemplo, `Fornecedor`) com seu próprio `TipoPessoa()` e `Descricao()`.
- Criar um método que receba um parâmetro do tipo `Pessoa` e exiba suas informações, chamando esse método com diferentes tipos concretos.
- Utilizar `is` ou `as` para fazer lógica específica apenas para um dos tipos (por exemplo, mostrar o RG apenas se for `PessoaFisica`).

