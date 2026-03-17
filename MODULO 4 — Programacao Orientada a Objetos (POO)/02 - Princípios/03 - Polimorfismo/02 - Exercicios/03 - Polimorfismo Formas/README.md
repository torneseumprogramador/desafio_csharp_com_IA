### Exercício 03 - Polimorfismo com Formas Geométricas

**Objetivo**  
Praticar **polimorfismo** com uma classe base de forma geométrica e subclasses que calculam área de maneiras diferentes.

### O que fazer

1. Crie uma classe base `Forma` com:
   - Propriedade `Nome` (string).
   - Método `public virtual double CalcularArea()` que, por padrão, retorna `0`.
   - Método `public virtual void Desenhar()` que apenas escreve `"Desenhando forma genérica"`.
2. Crie subclasses:
   - `Retangulo` : `Forma`
     - Propriedades: `Largura`, `Altura`.
     - Construtor que define `Nome = "Retângulo"` e recebe largura/altura.
     - Sobrescreva `CalcularArea()` retornando `largura * altura`.
     - (Opcional) sobrescreva `Desenhar()` com uma mensagem específica.
   - `Circulo` : `Forma`
     - Propriedade: `Raio`.
     - Construtor que define `Nome = "Círculo"` e recebe raio.
     - Sobrescreva `CalcularArea()` usando `Math.PI * raio * raio`.
   - (Opcional) `Triangulo` : `Forma` com sua própria forma de calcular área.
3. No `Program.cs`:
   - Crie uma lista `List<Forma>` com instâncias de `Retangulo`, `Circulo` (e opcional `Triangulo`).
   - Percorra a lista e, para cada `Forma`, exiba:
     - `Nome`
     - `CalcularArea()`
     - Chame também `Desenhar()`.

### Requisitos técnicos

- Usar `virtual` na classe base e `override` nas subclasses.
- Tratar todas as formas como `Forma` (tipo base) em uma lista única.
- Mostrar que o cálculo da área muda conforme o tipo concreto, mesmo chamando o mesmo método (`CalcularArea`) via referência base.

### Desafios extras (opcional)

- Adicionar um método virtual `CalcularPerimetro()` e sobrescrever nas subclasses.
- Permitir que o usuário escolha qual forma criar e informe as medidas via console.
- Exibir o tipo real do objeto em tempo de execução usando `GetType().Name`.

