
/*
Console.WriteLine("Digite o nome do aluno 1: ");
string nome1 = Console.ReadLine() ?? "";

Console.WriteLine("Digite a nome do aluno 2: ");
string nome2 = Console.ReadLine() ?? "";

Console.WriteLine("Digite a nome do aluno 3: ");
string nome3 = Console.ReadLine() ?? "";

Console.WriteLine(" --- Alunos: ");
Console.WriteLine(nome1);
Console.WriteLine(nome2);
Console.WriteLine(nome3);
Console.WriteLine(" -- Fim da Lista de Alunos -- ");
*/


// ================ WHILE ================
/*
int i = 1;
string nomesAlunos = string.Empty;
while (i <= 3)
{
    Console.WriteLine($"Digite o nome do aluno {i}: ");
    nomesAlunos += (Console.ReadLine() ?? "") + "\n";
    i++;
}

Console.WriteLine(" --- Alunos: ");
Console.WriteLine(nomesAlunos);
Console.WriteLine(" -- Fim da Lista de Alunos -- ");
*/

/*
int i = 1;
string nomes = string.Empty;
while (i <= 2)
{
    Console.WriteLine($"Digite o nome do aluno {i}: ");
    nomes += (Console.ReadLine() ?? "") + "\n";
    i++;
}

Console.WriteLine(" --- Alunos: ");
Console.WriteLine(nomes);
Console.WriteLine(" -- Fim da Lista de Alunos -- ");
*/  

// bool continuar = false;
// string nomes = string.Empty;
// int i = 1;
// while (continuar) // enquanto
// {
//     Console.WriteLine($"...Digite o nome do aluno {i}: ");
//     nomes += (Console.ReadLine() ?? "") + "\n";
//     i++;
//     Console.WriteLine("Deseja continuar? (true/false)");
//     continuar = bool.Parse(Console.ReadLine() ?? "false");
// } 

// Console.WriteLine(" --- Alunos: ");
// Console.WriteLine(nomes);
// Console.WriteLine(" -- Fim da Lista de Alunos -- ");


// ================ DO WHILE ================
/*
bool continuar = false;
string nomes = string.Empty;
int i = 1;
do // faça
{
    Console.WriteLine($"Digite o nome do aluno {i}: ");
    nomes += (Console.ReadLine() ?? "") + "\n";
    i++;
    Console.WriteLine("Deseja continuar? (true/false)");
    continuar = bool.Parse(Console.ReadLine() ?? "false");
} while (continuar); // enquanto

Console.WriteLine(" --- Alunos: ");
Console.WriteLine(nomes);
Console.WriteLine(" -- Fim da Lista de Alunos -- ");
*/

// ================ FOR ================

string nomes = string.Empty;
for (int i = 1; i <= 3; i++) // para (inicializacao; condicao; incremento)
{
    Console.WriteLine($"Digite o nome do aluno {i}: ");
    nomes += (Console.ReadLine() ?? "") + "\n";
}

Console.WriteLine(" --- Alunos: ");
Console.WriteLine(nomes);
Console.WriteLine(" -- Fim da Lista de Alunos -- ");

// ================ FOR EACH ================
// // utilizado para listas
// var nomes = "Danilo, João, Maria, Pedro, Ana".Split(',');
// foreach (string nome in nomes) // faça até acabar a lista
// {
//     Console.WriteLine(nome.Trim());
// }
