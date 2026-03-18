/*

- Abstração: Abstract class vc pode ter propriedades e metodos para implementar e pode ter métodos e propriedades já implementados
- public, private, protected, internal: são modificadores de acesso
- sealed: é um modificador que impede que uma classe seja herdada, ou metodo seja sobrescrito
- partial class: é uma classe que pode ser dividida em partes
*/

abstract class Animal
{
    /*
    public: pode ser acessado de qualquer lugar
    private: pode ser acessado apenas dentro da classe
    protected: pode ser acessado dentro da classe e por classes filhas
    internal: pode ser acessado dentro do mesmo projeto
    */
    internal string Nome { get; set; }
    public string Idade { get; set; }

    // Para que um método possa ser sealed, ele deve primeiro ser virtual (ou override de um método virtual/abstract)
    public virtual string Mostrar()
    {
        return $"Nome: {Nome} - Idade: {Idade}";
    }

    public abstract void Comer();
    public abstract void Dormir();
}

class Cachorro : Animal
{
    public Cachorro(string nome)
    {
        base.Nome = nome;
    }

    // Sealed: impede que outras classes derivadas sobrescrevam
    public sealed override string Mostrar()
    {
        return $"Nome: {Nome} - Idade: {Idade} - sobrescrito";
    }

    public override void Comer()
    {
        Console.WriteLine($"O cachorro {Nome} está comendo.");
    }

    public override void Dormir()
    {
        Console.WriteLine($"O cachorro {Nome} está dormindo.");
    }
}

class Gato : Animal
{
    public Gato(string nome)
    {
        base.Nome = nome;
    }

    public override void Comer()
    {
        Console.WriteLine($"O gato {Nome} está comendo.");
    }

    public override void Dormir()
    {
        Console.WriteLine($"O gato {Nome} está dormindo.");
    }
}

///// Exemplo onde a classe CachorroBoxer não pode sobrescrever o método Mostrar da classe Cachorro pois o metodo é sealed
// class CachorroBoxer : Cachorro
// {
//     public override string Mostrar()
//     {
//         return $"Nome: {Nome} - Idade: {Idade} - boxe";
//     }
// }


/// Metaprogramação: é o processo de criar programas que criam ou modificam outros programas (geralmente durante a compilação)
partial class Veiculo // que esta classe permite inclusao de metodos e propriedades durante a compilação
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Ano { get; set; }
}

partial class Veiculo // fundir ou juntar as partes da classe Veiculo
{
    public void Acelerar()
    {
        Console.WriteLine($"O veiculo {Marca} {Modelo} está acelerando.");
    }
}

sealed class Celular // se crio uma classe como sealed, ela não pode ser herdada
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Ano { get; set; }
}

// class Iphone : Celular // se crio uma classe como sealed, ela não pode ser herdada
// {
//     public string Cor { get; set; }
//     public string Tamanho { get; set; }
//     public string Ano { get; set; }
// }

class Program
{
    public static void Main(string[] args)
    {
        var veiculo = new Veiculo();
        veiculo.Marca = "Ford";
        veiculo.Modelo = "Fiesta";
        veiculo.Ano = "2020";

        Console.WriteLine(veiculo.Marca);
        Console.WriteLine(veiculo.Modelo);
        Console.WriteLine(veiculo.Ano);

        veiculo.Acelerar();






        Executar(new Cachorro("Rex"));
        Executar(new Gato("Miau"));
    }

    public static void Executar(Animal animal)
    {
        animal.Nome = "Rex";
        animal.Idade = "10 anos";
        Console.WriteLine(animal.Mostrar());

        animal.Comer();
        animal.Dormir();
    }
}