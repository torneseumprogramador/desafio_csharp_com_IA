### Exercício 01 - Animais e Sons com Interfaces

**Objetivo**  
Praticar o uso de **interfaces** criando vários tipos de animais que implementam o mesmo contrato, semelhante ao exemplo com `IAnimal`, `Cachorro` e `Gato`.

### O que fazer

1. Defina uma **interface `IAnimal`** com, pelo menos, os métodos:
   - `void Comer();`
   - `void Dormir();`
   - `void EmitirSom();`
2. Crie **pelo menos 3 classes** que implementem essa interface:
   - `Cachorro`
   - `Gato`
   - `Passaro` (ou outro animal que preferir)
3. Cada classe deve:
   - Ter uma propriedade `Nome` (string).
   - Ter um **construtor** que receba o nome.
   - Implementar os métodos da interface exibindo mensagens diferentes no `Console.WriteLine`, por exemplo:
     - `"O cachorro Rex está comendo."`
     - `"O gato Miau está dormindo."`
     - `"O pássaro Azul está cantando."`
4. No `Program.cs`, crie um método:
   ```csharp
   static void Executar(IAnimal animal)
   {
       animal.Comer();
       animal.Dormir();
       animal.EmitirSom();
   }
   ```
5. Dentro de `Main`, chame `Executar` para diferentes animais:
   ```csharp
   Executar(new Cachorro("Rex"));
   Executar(new Gato("Miau"));
   Executar(new Passaro("Azul"));
   ```

### Requisitos técnicos

- Definir a interface `IAnimal` e implementar em todas as classes de animais.
- Usar **propriedades** e **construtores** nas classes concretas.
- Usar **polimorfismo** via interface (`Executar(IAnimal animal)`).

### Desafios extras (opcional)

- Adicionar uma propriedade `Idade` aos animais e um método opcional específico em uma das classes (por exemplo, `Brincar()` no cachorro).
- Criar uma lista `List<IAnimal>` e percorrê-la chamando `Comer`, `Dormir` e `EmitirSom` para cada item.
- Usar o padrão do exemplo para checar o tipo concreto com `is` (por exemplo, se `animal is Gato` então mostrar algo especial).

