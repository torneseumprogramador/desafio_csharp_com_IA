### Exercício 03 - Meios de Transporte com Interfaces

**Objetivo**  
Praticar o uso de interfaces modelando diferentes **meios de transporte** que compartilham comportamentos em comum.

### O que fazer

1. Defina uma **interface `ITransporte`** com, pelo menos, os métodos:
   - `void Acelerar();`
   - `void Frear();`
   - `void ExibirInformacoes();`
2. Crie **pelo menos 3 classes** que implementem `ITransporte`:
   - `Carro`
   - `Bicicleta`
   - `Onibus` (ou outro que você preferir, como `Moto`)
3. Cada classe deve ter propriedades adequadas, por exemplo:
   - `Carro`: `Modelo`, `Placa`, `VelocidadeAtual`
   - `Bicicleta`: `Modelo`, `TemMarcha` (bool), `VelocidadeAtual`
   - `Onibus`: `Linha`, `Capacidade`, `VelocidadeAtual`
4. Implemente os métodos:
   - `Acelerar()` — aumenta a velocidade atual (ex.: +10 para carro, +5 para bicicleta etc.) e mostra no console.
   - `Frear()` — reduz a velocidade atual (sem deixar ficar negativa) e mostra no console.
   - `ExibirInformacoes()` — mostra os dados principais do transporte (modelo, placa, linha, etc.).
5. No `Program.cs`, crie um método:
   ```csharp
   static void TestarTransporte(ITransporte transporte)
   {
       transporte.ExibirInformacoes();
       transporte.Acelerar();
       transporte.Acelerar();
       transporte.Frear();
       Console.WriteLine("-----------------------------");
   }
   ```
6. Dentro de `Main`, instancie diferentes transportes e teste:
   ```csharp
   TestarTransporte(new Carro("Gol", "ABC-1234"));
   TestarTransporte(new Bicicleta("Mountain Bike", true));
   TestarTransporte(new Onibus("Linha 123", 40));
   ```

### Requisitos técnicos

- Definir interface `ITransporte` e implementá-la nas classes concretas.
- Usar **propriedades** e **construtores** para inicializar os dados.
- Utilizar **polimorfismo**: o método `TestarTransporte` recebe `ITransporte` e funciona para qualquer implementação.

### Desafios extras (opcional)

- Adicionar um método `Parar()` na interface que zera a velocidade e mostrar isso no console.
- Criar uma lista `List<ITransporte>` e percorrer, chamando `TestarTransporte` para cada item.
- Fazer tratamento de limites, por exemplo, não deixar a velocidade passar de um máximo definido por classe (máx. para carro, máx. para ônibus etc.).

