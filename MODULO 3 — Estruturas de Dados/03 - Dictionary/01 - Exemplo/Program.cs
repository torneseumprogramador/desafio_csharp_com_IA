Console.WriteLine("-------------Dictionary de alunos int,string -------------------");
Dictionary<int, string> alunos = new Dictionary<int, string>();

alunos.Add(1, "Danilo");
alunos.Add(2, "Maria");
alunos.Add(3, "Carlos");

foreach (var aluno in alunos)
{
    Console.WriteLine($"ID: {aluno.Key} - Nome: {aluno.Value}");
}

if (alunos.ContainsKey(2))
{
    Console.WriteLine("Aluno encontrado: " + alunos[2]);
}

// removendo um aluno
alunos.Remove(3);

Console.WriteLine($"Quantidade de alunos: {alunos.Count}");


Console.WriteLine("-------------Dictionary de nomes string,string-------------------");

Dictionary<string, string> nomes = new Dictionary<string, string>();

nomes.Add("A1", "Danilo");
nomes.Add("A2", "Maria");
nomes.Add("A3", "Carlos");

foreach (var nome in nomes)
{
    Console.WriteLine($"ID: {nome.Key} - Nome: {nome.Value}");
}

if (nomes.ContainsKey("A2"))
{
    Console.WriteLine("Aluno encontrado: " + nomes["A2"]);
}


Console.WriteLine("-------------Dictionary de clientes string,string-------------------");

Dictionary<string, string> cliente = new Dictionary<string, string>();

cliente.Add("ID", "1");
cliente.Add("Nome", "João");
cliente.Add("Email", "joao@gmail.com");
cliente.Add("Telefone", "11999999999");

Console.WriteLine("-------------Dados do cliente-------------------");
Console.WriteLine($"ID: {cliente["ID"]}");
Console.WriteLine($"Nome: {cliente["Nome"]}");
Console.WriteLine($"Email: {cliente["Email"]}");
Console.WriteLine($"Telefone: {cliente["Telefone"]}");
