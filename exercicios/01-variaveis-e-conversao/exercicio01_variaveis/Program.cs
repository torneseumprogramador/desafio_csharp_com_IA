string nome = "Reinaldo";
int idade = 20;

// Resultado 1 – usando Convert.ToString(idade) + " - " + nome
string resultado1 = Convert.ToString(idade) + " - " + nome;
Console.WriteLine("--------------------------------");
Console.WriteLine("Resultado 1: " + resultado1);
Console.WriteLine("--------------------------------");



// Variáveis dinâmicas (var)
var nome2 = "Santana";
var idade2 = 21;

// Resultado 2 – usando idade2.ToString() + " - " + nome2
string resultado2 = idade2.ToString() + " - " + nome2;
Console.WriteLine("--------------------------------");
Console.WriteLine("Resultado 2: " + resultado2);
Console.WriteLine("--------------------------------");

Console.WriteLine("Digite um numero: ");
string stringNumero = Console.ReadLine() ?? "0";
int idadeNova = int.Parse(stringNumero) + idade;
Console.WriteLine("--------------------------------");
Console.WriteLine($"A idade nova é: {idadeNova} anos");
Console.WriteLine("--------------------------------");

// Resultado 3 – usando int.Parse("2") + idade
int resultado3 = int.Parse("2") + idade;
Console.WriteLine("--------------------------------");
Console.WriteLine("Resultado 3 (idade + 2): " + resultado3);
Console.WriteLine("--------------------------------");