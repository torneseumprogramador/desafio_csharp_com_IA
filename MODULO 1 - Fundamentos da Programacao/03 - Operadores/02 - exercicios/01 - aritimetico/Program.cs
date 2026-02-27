Console.Clear();
Console.WriteLine("Olá João bem vindo ao programa");
System.Threading.Thread.Sleep(3000);
Console.Clear();

Console.WriteLine("Digite o nome do produto: ");
string nome1 = Console.ReadLine() ?? "";
Console.WriteLine($"Digite o preço do produto {nome1}: ");
double preco1 = double.Parse(Console.ReadLine() ?? "0");
Console.WriteLine($"Digite a quantidade do produto {nome1}: ");
int quantidade1 = int.Parse(Console.ReadLine() ?? "0");
double valorTotal1 = preco1 * quantidade1;
Console.Clear();

Console.WriteLine("Digite o nome do produto: ");
string nome2 = Console.ReadLine() ?? "";
Console.WriteLine($"Digite o preço do produto {nome2}: ");
double preco2 = double.Parse(Console.ReadLine() ?? "0");
Console.WriteLine($"Digite a quantidade do produto {nome2}: ");
int quantidade2 = int.Parse(Console.ReadLine() ?? "0");
double valorTotal2 = preco2 * quantidade2;
Console.Clear();


Console.WriteLine("Digite o nome do produto: ");
string nome3 = Console.ReadLine() ?? "";
Console.WriteLine($"Digite o preço do produto {nome3}: ");
double preco3 = double.Parse(Console.ReadLine() ?? "0");
Console.WriteLine($"Digite a quantidade do produto {nome3}: ");
int quantidade3 = int.Parse(Console.ReadLine() ?? "0");
double valorTotal3 = preco3 * quantidade3;
Console.Clear();


Console.WriteLine("=== Carrinho de Compras ===");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Produto: {nome1}");
Console.WriteLine($"Preço: {preco1}");
Console.WriteLine($"Quantidade: {quantidade1}");
Console.WriteLine($"Valor Total: {valorTotal1.ToString("0.00")}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Produto: {nome2}");
Console.WriteLine($"Preço: {preco2}");
Console.WriteLine($"Quantidade: {quantidade2}");
Console.WriteLine($"Valor Total: {valorTotal2.ToString("0.00")}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Produto: {nome3}");
Console.WriteLine($"Preço: {preco3}");
Console.WriteLine($"Quantidade: {quantidade3}");
Console.WriteLine($"Valor Total: {valorTotal3.ToString("0.00")}");
Console.WriteLine("--------------------------------");

Console.WriteLine("--------------------------------");
Console.WriteLine($"Valor Total de todos os produtos: R$ {(valorTotal1 + valorTotal2 + valorTotal3).ToString("0.00")}");
Console.WriteLine("--------------------------------");