Console.Clear();
Console.WriteLine("Olá, bem vindo ao programa de verificação de candidatos");
System.Threading.Thread.Sleep(3000);
Console.Clear();

Console.WriteLine("Digite o nome do candidato: ");
string nome = Console.ReadLine() ?? "";
Console.WriteLine("Digite a idade do candidato: ");
int idade = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine($"Digite se o(a) {nome} tem carteira de motorista: true/false ");
bool carteira = bool.Parse(Console.ReadLine() ?? "false");
Console.Clear();

Console.WriteLine($"O(a) {nome} tem carteira de motorista: {carteira}");
Console.WriteLine($"O(a) {nome} é maior de idade: {idade >= 18}");
Console.WriteLine($"O(a) {nome} tem carteira de motorista e é maior de idade: {carteira && idade >= 18}");
Console.WriteLine($"O(a) {nome} tem carteira de motorista ou é maior de idade: {carteira || idade >= 18}");
Console.WriteLine("Digite mais alguns anos de idade para somar com a idade atual: ");
int maisAnos = int.Parse(Console.ReadLine() ?? "0");
idade += maisAnos;
Console.WriteLine($"A idade do candidato agora é: {idade}");
Console.WriteLine($"A idade do candidato está entre 18 e 35 anos: {idade >= 18 && idade <= 35}");