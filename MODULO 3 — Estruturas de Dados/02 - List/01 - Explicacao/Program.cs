Console.WriteLine("---------------List de alunos não obrigatório colocar o limite de elementos-----------------");
List<string> nomes = new List<string>();

nomes.Add("João");
nomes.Add("Maria");
nomes.Add("Pedro");

// Console.WriteLine(nomes[0]);
// Console.WriteLine(nomes[1]);
// Console.WriteLine(nomes[2]);

foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

if(nomes.Contains("João"))
{
    Console.WriteLine("João encontrado");
}
else
{
    Console.WriteLine("João não encontrado");
}

Console.WriteLine(nomes.IndexOf("Maria")); // 2
Console.WriteLine(nomes.Contains("João")); // true

nomes.Remove("Maria");
Console.WriteLine("---------------List de alunos após remover Maria-----------------");
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}


nomes.Clear();
Console.WriteLine("---------------List de alunos após limpar-----------------");
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

Console.WriteLine($"Quantidade de elementos na lista: {nomes.Count}");

Console.WriteLine("---------------alunos Array obrigatório colocar o limite de elementos-----------------");

string[] alunos = new string[]{"João", "Maria", "Pedro"};

Console.WriteLine(alunos.IndexOf("Pedro")); // 2
Console.WriteLine(alunos.Contains("João")); // true


Console.WriteLine($"Quantidade de elementos no array: {alunos.Length}");

for(int i = 0; i < alunos.Length; i++)
{
    alunos[i] = string.Empty;
}

Console.WriteLine($"Quantidade de elementos no array: {alunos.Length}");
Console.WriteLine("---------------alunos Array após limpar-----------------");
for (int i = 0; i < alunos.Length; i++)
{
    Console.WriteLine($"Indice: {i} - Nome: {alunos[i]}");
}
