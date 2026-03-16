interface IAnimal
{
    void Comer();
    void Dormir();
}

class Cachorro : IAnimal
{
    public string Nome { get; set; }

    public Cachorro(string nome)
    {
        Nome = nome;
    }

    public void Comer()
    {
        Console.WriteLine($"O cachorro {Nome} está comendo.");
    }

    public void Dormir()
    {
        Console.WriteLine($"O cachorro {Nome} está dormindo.");
    }
}

class Gato : IAnimal
{
    public string Nome { get; set; }

    public Gato(string nome)
    {
        Nome = nome;
    }

    public string Idade()
    {
        return "10 anos";
    }

    public void Comer()
    {
        Console.WriteLine($"O gato {Nome} está comendo.");
    }

    public void Dormir()
    {
        Console.WriteLine($"O gato {Nome} está dormindo.");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Executar(new Cachorro("Rex"));
        Executar(new Gato("Miau"));
    }

    public static void Executar(IAnimal animal)
    {
        animal.Comer();
        animal.Dormir();
        
        if (animal is Gato gato)
        {
            Console.WriteLine(gato.Idade());
        }
    }
}