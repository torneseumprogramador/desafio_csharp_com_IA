object[] numeros = new object[5];
numeros[0] = "1";
numeros[1] = 2;
numeros[2] = 3.3;
numeros[3] = true;
numeros[4] = 5;

Console.WriteLine(numeros[0]);
Console.WriteLine(numeros[1]);
Console.WriteLine(numeros[2]);
Console.WriteLine(numeros[3]);
Console.WriteLine(numeros[4]);
Console.WriteLine("--------------------------------");

Console.WriteLine("---------------Media de notas-----------------");
double[] notas = { 10, 20, 30, 40, 50 };
double media = notas.Average();
Console.WriteLine($"Média: {media}");

int[] numeros2 = { 10, 20, 30, 40, 50 };

Console.WriteLine(numeros2[0]); // 10
Console.WriteLine(numeros2[2]); // 30

Console.WriteLine("--------------------------------");
Console.WriteLine(numeros2.Length);
Console.WriteLine("--------------------------------");

// quando preciso do indice
for (int i = 0; i < numeros2.Length; i++)
{
    Console.WriteLine($"Indice: {i}");
    Console.WriteLine($"Numero: {numeros2[i]}");
}
Console.WriteLine("--------------------------------");

// quando nao preciso do indice
foreach (int numero in numeros2)
{
    Console.WriteLine($"Numero: {numero}");
}


Console.WriteLine("---------------Matriz-----------------");

int[,] matriz =
{
    {1, 2},
    {3, 4}
};

Console.WriteLine(matriz[0,1]); // 2
Console.WriteLine(matriz[1,0]); // 3


Console.WriteLine("---------------Matriz de alunos/notas-----------------");

// Programa que vai armazenar o nome e a nota de 3 alunos em uma matriz e depois mostrar o nome e a nota de cada aluno
string[,] alunos = new string[3, 2];

//linha 1
alunos[0, 0] = "João";
alunos[0, 1] = "8"; // coluna 2

//linha 2
alunos[1, 0] = "Maria"; // coluna 1
alunos[1, 1] = "9"; // coluna 2

//linha 3
alunos[2, 0] = "Pedro"; // coluna 1
alunos[2, 1] = "7"; // coluna 2

Console.WriteLine($"Nome: {alunos[0, 0]} - Nota: {alunos[0, 1]}"); // João
Console.WriteLine($"Nome: {alunos[1, 0]} - Nota: {alunos[1, 1]}"); // Maria
Console.WriteLine($"Nome: {alunos[2, 0]} - Nota: {alunos[2, 1]}"); // Pedro

