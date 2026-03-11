// LINQ - Language Integrated Query - Manipular / Filtrar colecoes de dados

List<int> numeros = new List<int> { 5, 10, 15, 20, 25 };

// filtro e ornação em linguagem natural do SQL
// select * from numeros where n > 10 and n < 20 order by n asc select n * 2

var resultado = numeros
    .Where(n => n > 10) // filtrando n maior que 10
    .Where(n => n < 20) // filtrando n menor que 20
    .OrderBy(n => n) // ordenando n em ordem crescente
    .Select(n => n * 2); // multiplicando n por 2

foreach (var n in resultado)
{
    Console.WriteLine($"O valor de n é: {n}");
}


// select * from numeros where n > 10 and n < 20 order by n asc select n * 2
//  Sintaxe alternativa (Query Syntax)
var resultado2 = from n in numeros
                 where n > 10 // filtrando n maior que 10
                 where n < 20 // filtrando n menor que 20
                 orderby n // ordenando n em ordem crescente
                 select n * 2; // multiplicando n por 2

foreach (var n in resultado2)
{
    Console.WriteLine($"O valor de n é: {n}");
}


Console.WriteLine("---------------Exemplo de lista de pais, filhos e idades-----------------");

// Criando a lista de pais, onde cada pai tem: nome, idade, e uma lista de filhos (nome, idade)
var pais = new List<(string Nome, int Idade, List<(string Nome, int Idade)> Filhos)>()
{
    (
        "Carlos",
        45,
        new List<(string, int)>
        {
            ("Ana", 20),
            ("João", 18)
        }
    ),
    (
        "Maria",
        40,
        new List<(string, int)>
        {
            ("Paulo", 15),
            ("Fernanda", 13)
        }
    ),
    (
        "Pedro",
        50,
        new List<(string, int)>
        {
            ("Lucas", 25)
        }
    )
};

Console.WriteLine("---------------Exemplo de exibição dos dados-----------------");
foreach (var pai in pais)
{
    Console.WriteLine($"Pai/Mãe: {pai.Nome} - Idade: {pai.Idade}");
    Console.WriteLine("Filhos:");
    foreach (var filho in pai.Filhos)
    {
        Console.WriteLine($"\tNome: {filho.Nome}, Idade: {filho.Idade}");
    }
    Console.WriteLine();
}

Console.WriteLine("---------------Exemplo de soma de idades dos pais-----------------");
var idadeDosPaisSomados = pais.Select(p => p.Idade).Sum();
Console.WriteLine($"A idade total dos pais é: {idadeDosPaisSomados}");


Console.WriteLine("---------------Exemplo de soma de idades dos pais like sql-----------------");
var idadeDosPaisSomadosSQL = (from p in pais select p.Idade).Sum();
Console.WriteLine($"A idade total dos pais é: {idadeDosPaisSomadosSQL}");


Console.WriteLine("---------------Exemplo de soma de idades dos filhos-----------------");
var idadeDosFilhosSomados = pais.Select(p => p.Filhos.Select(f => f.Idade).Sum()).Sum();
Console.WriteLine($"A idade total dos filhos é: {idadeDosFilhosSomados}");


Console.WriteLine("---------------Exemplo ofilhos like sql-----------------");
var idadeDosFilhosSomadosSQL = (
    from p in pais
    from f in p.Filhos
    select f.Idade
).Sum();
Console.WriteLine($"A idade total dos filhos é: {idadeDosFilhosSomadosSQL}");


Console.WriteLine("---------------Exemplo de soma de idades dos filhos agrupados por pai-----------------");
var idadeDosFilhosSomadosAgrupadosPorPai =
    pais.Select(p => new
    {
        Nome = p.Nome,
        SomaIdadeFilhos = p.Filhos.Sum(f => f.Idade)
    });

foreach (var item in idadeDosFilhosSomadosAgrupadosPorPai)
{
    Console.WriteLine($"Pai: {item.Nome} - Idade total dos filhos: {item.SomaIdadeFilhos}");
}


Console.WriteLine("---------------Exemplo de soma de idades dos filhos agrupados por pai like sql-----------------");
var idadeDosFilhosSomadosAgrupadosPorPaiSQL = (
    from p in pais
    from f in p.Filhos
    group f by p.Nome into g
    select new
    {
        Nome = g.Key,
        SomaIdadeFilhos = g.Sum(f => f.Idade)
    }
);

foreach (var item in idadeDosFilhosSomadosAgrupadosPorPaiSQL)
{
    Console.WriteLine($"Pai: {item.Nome} - Idade total dos filhos: {item.SomaIdadeFilhos}");
}

Console.WriteLine("---------------Exemplo LINQ like SQL com join por id-----------------");

// Nova lista de filhos em separado, associando explicitamente um PaiId
var filhosSeparados = new List<dynamic>
{
    new { Id = 1, Nome = "Lucas", Idade = 10, PaiId = 1 },
    new { Id = 2, Nome = "Julia", Idade = 8, PaiId = 1 },
    new { Id = 3, Nome = "Pedro", Idade = 12, PaiId = 2 },
    new { Id = 4, Nome = "Ana", Idade = 9, PaiId = 2 },
    new { Id = 5, Nome = "Carlos", Idade = 7, PaiId = 3 }
};

var paisDosFilhos = new List<dynamic>
{
    new { Id = 1, Nome = "Carlos", Idade = 45 },
    new { Id = 2, Nome = "Maria", Idade = 42 },
    new { Id = 3, Nome = "Pedro", Idade = 50 }
};

// Exemplo de join usando LINQ (sintaxe de consulta, join por Id)
// Agora, incluindo Idade do Pai no select.
var consultaJoin = from pai in paisDosFilhos
                   join filho in filhosSeparados
                   on pai.Id equals filho.PaiId
                   };

// Exibindo em formato de tabela (agora incluindo idade do pai)
Console.WriteLine("\n---------------------------------------------------------");
Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-15}", "Pai", "Idade Pai", "Filho", "Idade do Filho");
Console.WriteLine(new string('-', 60));
foreach (var item in consultaJoin)
{
    Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-15}", item.PaiNome, item.PaiIdade, item.FilhoNome, item.FilhoIdade);
}

Console.WriteLine("---------------Exemplo utilizando objeto encadeado-----------------");

// Exemplo de join utilizando sintaxe de métodos (encadeado), sem usar linq 'like sql'
var consultaJoinEncadeado = paisDosFilhos
    .Join(
        filhosSeparados,
        pai => pai.Id,
        filho => filho.PaiId,
        (pai, filho) => new
        {
            PaiNome = pai.Nome,
            PaiIdade = pai.Idade,
            FilhoNome = filho.Nome,
            FilhoIdade = filho.Idade
        }
    );

// Exibindo em formato de tabela (incluindo idade do pai, igual ao exemplo anterior)
Console.WriteLine("\n---------------------------------------------------------");
Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-15}", "Pai", "Idade Pai", "Filho", "Idade do Filho");
Console.WriteLine(new string('-', 60));
foreach (var item in consultaJoinEncadeado)
{
    Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-15}", item.PaiNome, item.PaiIdade, item.FilhoNome, item.FilhoIdade);
}
