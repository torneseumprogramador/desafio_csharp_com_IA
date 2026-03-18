### Exercício 01 - Animais Abstratos + Override + Sealed

**Conteúdo da aula**  
`abstract class`, métodos `abstract`, métodos `virtual/override`, e `sealed override`.

### Objetivo

Criar uma hierarquia de animais usando **classe abstrata**, e praticar **sobrescrita** de métodos, incluindo um método sobrescrito como **`sealed`** para impedir novas sobrescritas.

### Regras do exercício

1. Crie uma classe abstrata `Animal` com:
   - Propriedades:
     - `Nome` (defina um modificador de acesso coerente com a aula: `internal` ou `protected`)
     - `Idade` (`public`)
   - Um método **virtual** `Mostrar()` que retorna uma string com nome e idade.
   - Dois métodos **abstratos**:
     - `Comer()`
     - `Dormir()`
2. Crie duas classes que herdam de `Animal`:
   - `Cachorro`
   - `Gato`
3. Cada classe deve implementar `Comer()` e `Dormir()` com mensagens no console.
4. Em `Cachorro`, sobrescreva o método `Mostrar()` e marque como:
   - `public sealed override string Mostrar()`
5. Tente criar uma terceira classe `CachorroBoxer : Cachorro` e **tentar sobrescrever** `Mostrar()` (deixe o código comentado) e observe o erro de compilação.

### O que exibir no console

- No `Main`, crie um método `Executar(Animal animal)` que:
  - Define `Nome` e `Idade`
  - Exibe `animal.Mostrar()`
  - Chama `animal.Comer()` e `animal.Dormir()`
- Chame `Executar` para um `Cachorro` e um `Gato`.

### Requisitos técnicos

- Usar `abstract`, `virtual`, `override` e `sealed override` conforme pedido.
- Usar polimorfismo passando `Animal` como parâmetro (tipo base).

### Desafios extras (opcional)

- Adicionar um terceiro animal (ex.: `Passaro`) e implementar seus métodos.
- Fazer com que `Animal` tenha um método não-abstrato extra (ex.: `Apresentar()`) que use `Mostrar()` internamente.

