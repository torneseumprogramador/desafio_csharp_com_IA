### Exercício 02 - Formas Geométricas com Interfaces

**Objetivo**  
Praticar interfaces criando um conjunto de **formas geométricas** que compartilham o mesmo contrato para cálculo de área e perímetro.

### O que fazer

1. Defina uma **interface `IForma`** com os métodos:
   - `double CalcularArea();`
   - `double CalcularPerimetro();`
2. Crie **pelo menos 3 classes** que implementem a interface:
   - `Retangulo` (largura e altura)
   - `Circulo` (raio)
   - `Triangulo` (base e altura, e/ou três lados, você escolhe a fórmula)
3. Cada classe deve:
   - Ter propriedades necessárias (por exemplo, `Largura`, `Altura`, `Raio` etc.).
   - Ter **construtor** que receba os valores.
   - Implementar os métodos da interface retornando o valor calculado.
4. No `Program.cs`, crie um método:
   ```csharp
   static void MostrarForma(IForma forma)
   {
       Console.WriteLine($"Área: {forma.CalcularArea()}");
       Console.WriteLine($"Perímetro: {forma.CalcularPerimetro()}");
       Console.WriteLine("-----------------------------");
   }
   ```
5. Dentro de `Main`, instancie algumas formas e passe para `MostrarForma`:
   ```csharp
   MostrarForma(new Retangulo(3, 4));
   MostrarForma(new Circulo(5));
   MostrarForma(new Triangulo(3, 4, 5)); // ou outro tipo de triângulo que você definir
   ```

### Requisitos técnicos

- Definir interface `IForma` e implementá-la em todas as formas concretas.
- Usar **propriedades** e **construtores** para inicializar os dados.
- Usar **polimorfismo** via interface (`IForma`) para tratar todas as formas de maneira genérica.

### Desafios extras (opcional)

- Criar uma lista `List<IForma>` e percorrer exibindo área e perímetro de todas.
- Permitir que o usuário escolha o tipo de forma e informe as medidas via `Console.ReadLine`.
- Adicionar um método extra na interface, como `void Desenhar()`, e implementar mensagens diferentes em cada forma.

