// Lista "aleatória" fixa, trocando a ordem manualmente (sem Random)
List<int> numeros = new List<int> { 15, 40, 0, 25, 5, 35, 10, 50, 20, 30, 45 };
IEnumerable<int> maioresQue10 = numeros.Where(n => (n >= 10 && n <= 20));
Console.WriteLine("--------------------------------");
Console.WriteLine("Maiores que 10: " + string.Join(", ", maioresQue10));

Console.WriteLine("--------------OrderBy ascendente------------------");
var ordenados = numeros.OrderBy(n => n);
Console.WriteLine("Ordenados: " + string.Join(", ", ordenados));

Console.WriteLine("--------------OrderBy descendente------------------");
var ordenadosDescendente = numeros.OrderByDescending(n => n);
Console.WriteLine("Ordenados descendente: " + string.Join(", ", ordenadosDescendente));

Console.WriteLine("---------------Transformar dados (Select)-----------------");
Console.WriteLine("Numeros sem transformacao: " + string.Join(", ", numeros));
var transformados = numeros.Select(n => n * 2);
Console.WriteLine("Transformados: " + string.Join(", ", transformados));

Console.WriteLine("---------------Transformar dados (Select) lista Upercase-----------------");
List<string> nomes = new List<string> { "joão", "maria", "pedro", "ana", "carlos" };
var transformadosUppercase = nomes.Select(n => n.ToUpper());
Console.WriteLine("Transformados uppercase: " + string.Join(", ", transformadosUppercase));

Console.WriteLine("---------------Transformar dados (Select) lista Lowercase-----------------");
List<string> nomesLowercase = new List<string> { "JOÃO", "MARIA", "PEDRO", "ANA", "CARLOS" };
var transformadosLowercase = nomesLowercase.Select(n => n.ToLower());
Console.WriteLine("Transformados lowercase: " + string.Join(", ", transformadosLowercase));

Console.WriteLine("---------------Retorna o primeiro elemento da lista-----------------");
List<int> numeros2 = new List<int> { 10, 20, 30, 40 };
int primeiro = numeros2.First();
Console.WriteLine($"Primeiro elemento da lista: {primeiro}");
int encontrado = numeros2.First(n => n > 25);
Console.WriteLine($"Primeiro elemento da lista de acordo com o criterio: {encontrado}");

Console.WriteLine("---------------Verifica se elemento existe na lista-----------------");
List<int> numeros3 = new List<int> { 10, 20, 30, 40 };
bool existe = numeros3.Contains(20);
Console.WriteLine($"O elemento 20 existe na lista: {existe}");

Console.WriteLine("---------------Verifica a quantidade de elementos na lista-----------------");
List<int> numeros4 = new List<int> { 10, 20, 30, 40 };
int quantidade = numeros4.Count;
Console.WriteLine($"Quantidade de elementos na lista: {quantidade}");
int quantidade2 = numeros4.Count(n => n > 25);
Console.WriteLine($"Quantidade de elementos na lista maiores que 25: {quantidade2}");

Console.WriteLine("---------------Soma dos elementos da lista-----------------");
List<int> numeros5 = new List<int> { 10, 20, 30, 40 };
int soma = numeros5.Sum();
Console.WriteLine($"Soma dos elementos da lista: {soma}");

Console.WriteLine("---------------Media dos elementos da lista-----------------");
List<int> numeros6 = new List<int> { 10, 20, 30, 40 };
double media = numeros6.Average();
Console.WriteLine($"Media dos elementos da lista: {media}");

// Exemplos adicionais:
Console.WriteLine("---------------Maior valor da lista-----------------");
int maximo = numeros5.Max();
Console.WriteLine($"Maior valor da lista: {maximo}");

Console.WriteLine("---------------Menor valor da lista-----------------");
int minimo = numeros5.Min();
Console.WriteLine($"Menor valor da lista: {minimo}");

Console.WriteLine("---------------Remover elementos menores que 25-----------------");
var maioresQue25 = numeros5.Where(n => n >= 25).ToList();
Console.WriteLine("Lista após remoção (apenas >= 25): " + string.Join(", ", maioresQue25));

Console.WriteLine("---------------Verificar se todos os elementos são maiores que 5-----------------");
bool todosMaioresQue5 = numeros5.All(n => n > 5);
Console.WriteLine("Todos os elementos são maiores que 5? " + (todosMaioresQue5 ? "Sim" : "Não"));

Console.WriteLine("---------------Encontrar o índice de um elemento específico-----------------");
int indice30 = numeros5.IndexOf(30);
Console.WriteLine($"O índice do elemento 30 é: {indice30}");

Console.WriteLine("---------------Transformar lista em dicionario-----------------");
List<string> nomes2 = new List<string>
{
    "Danilo",
    "Maria",
    "Carlos"
};

var dicionario = nomes2.ToDictionary(n => n, n => n.Length);

foreach (var item in dicionario)
{
    Console.WriteLine($"{item.Key} -> quantidade de caracteres: {item.Value}");
}

Console.WriteLine("---------------Remover elementos da lista-----------------");
List<int> numeros7 = new List<int> { 10, 20, 30, 40 };
numeros7.Remove(20);
Console.WriteLine("Lista após remoção (apenas >= 25): " + string.Join(", ", numeros7));

Console.WriteLine("---------------Agrupar elementos da lista por letra inicial-----------------");
List<string> nomesParaAgrupar = new List<string>
{
    "Ana",
    "André",
    "Carlos",
    "Carla"
};

var grupos = nomesParaAgrupar.GroupBy(n => n[0]);

foreach (var grupo in grupos)
{
    Console.WriteLine($"Letra: {grupo.Key}");
    Console.WriteLine("Nomes: " + string.Join(", ", grupo));
    Console.WriteLine("--------------------------------");
}

