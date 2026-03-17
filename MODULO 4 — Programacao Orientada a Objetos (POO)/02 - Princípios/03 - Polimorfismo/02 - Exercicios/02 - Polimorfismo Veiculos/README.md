### Exercício 02 - Polimorfismo com Veículos

**Objetivo**  
Praticar **polimorfismo** sobrescrevendo métodos em subclasses de `Veiculo` e tratando todas como o mesmo tipo base.

### O que fazer

1. Crie uma classe base `Veiculo` com:
   - Propriedades: `Marca`, `Modelo`, `Ano`.
   - Método `public virtual string Tipo()` que retorna `"Veículo"`.
   - Método `public virtual void ExibirInformacoes()` que escreve no console as propriedades básicas.
2. Crie subclasses:
   - `Carro` : `Veiculo`
     - Propriedade extra: `QuantidadePortas`.
     - Sobrescreva `Tipo()` retornando `"Carro"`.
     - Sobrescreva `ExibirInformacoes()` para incluir também `QuantidadePortas`.
   - `Moto` : `Veiculo`
     - Propriedade extra: `Cilindrada`.
     - Sobrescreva `Tipo()` retornando `"Moto"`.
     - Sobrescreva `ExibirInformacoes()` para incluir a cilindrada.
   - (Opcional) `Caminhao` : `Veiculo` com suas próprias propriedades.
3. No `Program.cs`:
   - Crie uma lista `List<Veiculo>` e adicione instâncias de `Carro`, `Moto` (e opcional `Caminhao`).
   - Percorra a lista com `foreach (var veiculo in veiculos)` e chame `veiculo.ExibirInformacoes()`.

### Requisitos técnicos

- Usar `virtual` na classe base e `override` nas subclasses.
- Armazenar diferentes tipos de veículos em uma mesma lista de `Veiculo`.
- Mostrar no console que o método chamado depende do tipo concreto (cada veículo imprime algo diferente).

### Desafios extras (opcional)

- Adicionar um método virtual `double VelocidadeMaxima()` na classe base e sobrescrever em cada veículo, retornando valores diferentes.
- Exibir apenas veículos de um certo tipo (por exemplo, apenas motos) usando `is` ou filtrando com LINQ.
- Criar um método que receba um `Veiculo` como parâmetro e teste o polimorfismo chamando `ExibirInformacoes()` para diferentes tipos.

