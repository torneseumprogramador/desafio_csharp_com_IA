using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploLinqAvancado
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }
        public List<string> Hobbies { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    Nome = "Ana", Idade = 28, Cidade = "SP", 
                    Hobbies = new List<string> { "Bicicleta", "Xadrez", "Futebol" },
                    Pedidos = new List<Pedido>
                    {
                        new Pedido { Id = 1, Data = DateTime.Today.AddDays(-2), Valor = 500, Ativo = true },
                        new Pedido { Id = 2, Data = DateTime.Today.AddDays(-10), Valor = 90, Ativo = false }
                    }
                },
                new Pessoa
                {
                    Nome = "Bruno", Idade = 34, Cidade = "RJ", 
                    Hobbies = new List<string> { "Cozinhar", "Videogame" },
                    Pedidos = new List<Pedido>
                    {
                        new Pedido { Id = 3, Data = DateTime.Today.AddDays(-1), Valor = 150, Ativo = true },
                        new Pedido { Id = 4, Data = DateTime.Today.AddDays(-8), Valor = 990, Ativo = true }
                    }
                },
                new Pessoa
                {
                    Nome = "Carla", Idade = 19, Cidade = "BH",
                    Hobbies = new List<string> { "Leitura", "Futebol", "Cozinhar" },
                    Pedidos = new List<Pedido>
                    {
                        new Pedido { Id = 5, Data = DateTime.Today.AddDays(-5), Valor = 350, Ativo = false }
                    }
                },
                new Pessoa
                {
                    Nome = "Daniel", Idade = 40, Cidade = "SP",
                    Hobbies = new List<string> { "Futebol", "Bicicleta", "Música" },
                    Pedidos = new List<Pedido>
                    {
                        new Pedido { Id = 6, Data = DateTime.Today.AddDays(-2), Valor = 1200, Ativo = true },
                        new Pedido { Id = 7, Data = DateTime.Today.AddDays(-50), Valor = 82, Ativo = false }
                    }
                }
            };

            // 1. Filtrar pessoas com ao menos 2 pedidos ativos e mais de um hobby, ordenando por idade desc, e projetando nome + total dos pedidos ativos.
            var consulta1 = pessoas
                .Where(p => p.Pedidos.Count(x => x.Ativo) >= 2 && p.Hobbies.Count > 1)
                .OrderByDescending(p => p.Idade)
                .Select(p => new
                {
                    p.Nome,
                    SomaPedidosAtivos = p.Pedidos.Where(q => q.Ativo).Sum(q => q.Valor),
                    QtdPedidosAtivos = p.Pedidos.Count(q => q.Ativo)
                });

            Console.WriteLine("Consulta 1 - Pessoas com >=2 pedidos ativos & >1 hobby (nome, soma pedidos ativos, qtd pedidos):");
            foreach (var item in consulta1)
                Console.WriteLine($"{item.Nome} - Total R${item.SomaPedidosAtivos} ({item.QtdPedidosAtivos} pedidos ativos)");

            Console.WriteLine(new string('-', 60));

            // 2. Flatten: Listar todos pedidos ativos de todas as pessoas, com nome da pessoa
            var consulta2 = pessoas
                .SelectMany(p => p.Pedidos
                                 .Where(ped => ped.Ativo)
                                 .Select(ped => new { p.Nome, PedidoId = ped.Id, ped.Valor, ped.Data }))
                .OrderBy(x => x.Data);

            Console.WriteLine("Consulta 2 - Todos os pedidos ativos (com nome do dono):");
            foreach (var item in consulta2)
                Console.WriteLine($"{item.Nome} - Pedido {item.PedidoId} - R${item.Valor} em {item.Data:dd/MM}");

            Console.WriteLine(new string('-', 60));

            // 3. GroupBy/Join: Agrupar pessoas por cidade e trazer média de idade e total gasto (pedidos ativos)
            var consulta3 = pessoas
                .GroupBy(p => p.Cidade)
                .Select(g => new
                {
                    Cidade = g.Key,
                    MediaIdade = g.Average(x => x.Idade),
                    TotalGasto = g.SelectMany(x => x.Pedidos.Where(ped => ped.Ativo)).Sum(ped => ped.Valor),
                    Pessoas = g.Select(x => x.Nome).ToList()
                });

            Console.WriteLine("Consulta 3 - Pessoas agrupadas por cidade (média idade, valor total ativo):");
            foreach (var grupo in consulta3)
            {
                Console.WriteLine($"{grupo.Cidade}: Media Idade={grupo.MediaIdade:F1} | Total Gastos Ativos=R${grupo.TotalGasto}");
                Console.WriteLine("-- Pessoas: " + string.Join(", ", grupo.Pessoas));
            }

            Console.WriteLine(new string('-', 60));

            // 4. Consulta cabulosa: Pessoas que tem pelo menos um hobby em comum com Daniel e pelo menos um pedido acima de R$ 500
            var hobbiesDaniel = pessoas.FirstOrDefault(p => p.Nome == "Daniel")?.Hobbies ?? new List<string>()  ;
            var consulta4 = pessoas
                .Where(p => p.Nome != "Daniel"
                            && p.Hobbies.Intersect(hobbiesDaniel).Any()
                            && p.Pedidos.Any(x => x.Valor > 500));
            Console.WriteLine("Consulta 4 - Pessoas com hobby em comum com Daniel e pedido > R$500:");
            foreach (var p in consulta4)
                Console.WriteLine($"{p.Nome} - Hobbies comuns: {string.Join(", ", p.Hobbies.Intersect(hobbiesDaniel))}");

            Console.WriteLine(new string('-', 60));

            // 5. Dictionary: Dicionário Nome -> Lista de datas dos pedidos ordenados
            var consulta5 = pessoas.ToDictionary(
                p => p.Nome,
                p => p.Pedidos.OrderBy(x => x.Data).Select(x => x.Data.ToShortDateString()).ToList()
            );
            Console.WriteLine("Consulta 5 - Datas de pedidos por pessoa:");
            foreach (var kvp in consulta5)
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");

            Console.WriteLine(new string('-', 60));

            // 6. Extrair ranking dos hobbies mais populares entre todas as pessoas
            var rankingHobbies = pessoas
                .SelectMany(p => p.Hobbies)
                .GroupBy(h => h)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Select(g => new { Hobby = g.Key, Quantidade = g.Count() });
            Console.WriteLine("Consulta 6 - Ranking de hobbies mais populares:");
            foreach (var item in rankingHobbies)
                Console.WriteLine($"{item.Hobby}: {item.Quantidade}");

            Console.WriteLine(new string('-', 60));

            // 7. Exemplo de Aggregate: Concatenar os nomes de todas as pessoas acima de 25 anos (separado por ' | ')
            var nomesConcat = pessoas
                .Where(p => p.Idade > 25)
                .Select(p => p.Nome)
                .Aggregate((acc, next) => acc + " | " + next);
            Console.WriteLine("Consulta 7 - Nomes (Idade>25) concatenados: " + nomesConcat);


            // 8. Agrupar pessoas por quantidade de hobbies e calcular a soma dos valores de pedidos ativos (>0) por grupo
            var agrupamentoPorQtdHobbies = pessoas
                .GroupBy(p => p.Hobbies.Count)
                .Select(g => new
                {
                    QtdHobbies = g.Key,
                    Pessoas = g.Select(p => p.Nome).ToList(),
                    SomaGastosAtivos = g.SelectMany(p => p.Pedidos).Where(x => x.Valor > 0).Sum(x => x.Valor)
                })
                .OrderByDescending(x => x.QtdHobbies);
            Console.WriteLine("Consulta 8 - Agrupados por quantidade de hobbies e soma de pedidos ativos:");
            foreach (var grupo in agrupamentoPorQtdHobbies)
            {
                Console.WriteLine($"Qtd Hobbies: {grupo.QtdHobbies} - Soma Gastos Ativos: R${grupo.SomaGastosAtivos:F2} | Pessoas: {string.Join(", ", grupo.Pessoas)}");
            }
            Console.WriteLine(new string('-', 60));

            // 9. Para cada pessoa, encontrar o(s) ano(s) em que ela fez mais pedidos e quantos pedidos foram feitos nesses anos (modo avançado, lida com empates)
            var anosMaisAtivos = pessoas
                .Select(p => new
                {
                    Pessoa = p.Nome,
                    MaisAtivos = p.Pedidos
                        .GroupBy(x => x.Data.Year)
                        .OrderByDescending(g => g.Count())
                        .GroupBy(g => g.Count()) // Em caso de empate, pega todos anos top
                        .OrderByDescending(g => g.Key)
                        .FirstOrDefault()
                        ?.Select(g => new { Ano = g.Key, Qtd = g.Count() })?.ToList()
                });
            Console.WriteLine("Consulta 9 - Ano(s) mais ativo(s) em pedidos de cada pessoa:");
            foreach (var linha in anosMaisAtivos)
            {
                if (linha.MaisAtivos == null || !linha.MaisAtivos.Any())
                {
                    Console.WriteLine($"{linha.Pessoa}: Nenhum pedido registrado");
                    continue;
                }
                var descricoes = linha.MaisAtivos.Select(a => $"{a.Ano}: {a.Qtd} pedidos");
                Console.WriteLine($"{linha.Pessoa}: {string.Join("; ", descricoes)}");
            }
            Console.WriteLine(new string('-', 60));

            // 10. Pessoas que têm todos os hobbies presentes numa "lista premium" e nunca fizeram pedidos abaixo de R$100
            var listaHobbiesPremium = new[] { "Futebol", "Trilha", "Cozinhar" };
            var consultaPremium = pessoas
                .Where(p => listaHobbiesPremium.All(h => p.Hobbies.Contains(h))
                            && p.Pedidos.All(px => px.Valor >= 100));
            Console.WriteLine("Consulta 10 - Pessoas 100% premium em hobbies e nos pedidos:");
            foreach (var p in consultaPremium)
                Console.WriteLine($"{p.Nome} [Hobbies: {string.Join(", ", p.Hobbies)}]");
            Console.WriteLine(new string('-', 60));


            // Exemplo de "LIKE" SQL em LINQ - utilizando sintaxe de consulta (query syntax)
            var consultaLike = from p in pessoas
                               where p.Nome.Contains("a", StringComparison.OrdinalIgnoreCase) // equivalente ao LIKE '%a%'
                               select p;

            Console.WriteLine("Consulta LIKE utilizando sintaxe LINQ (nomes contendo 'a'):");
            foreach (var p in consultaLike)
                Console.WriteLine($"{p.Nome}");
            Console.WriteLine(new string('-', 60));

            // Exemplo avançado 1: nomes que começam com 'J' e terminam com 'o' (LIKE 'J%o') - case insensitive
            var consultaLikeAvancado1 = from p in pessoas
                                        where p.Nome.StartsWith("J", StringComparison.OrdinalIgnoreCase)
                                           && p.Nome.EndsWith("o", StringComparison.OrdinalIgnoreCase)
                                        select p;

            Console.WriteLine("Consulta LIKE avançada 1 (nomes que começam com 'J' e terminam com 'o'):");
            foreach (var p in consultaLikeAvancado1)
                Console.WriteLine($"{p.Nome}");
            Console.WriteLine(new string('-', 60));

            // Exemplo avançado 2: pessoas cujo nome contém exatamente duas vogais 'a' e pelo menos um 'e'
            var consultaLikeAvancado2 = from p in pessoas
                                        let countA = p.Nome.Count(ch => char.ToLower(ch) == 'a')
                                        where countA == 2 && p.Nome.IndexOf('e', StringComparison.OrdinalIgnoreCase) >= 0
                                        select p;

            Console.WriteLine("Consulta LIKE avançada 2 (nomes com exatamente dois 'a' e pelo menos um 'e'):");
            foreach (var p in consultaLikeAvancado2)
                Console.WriteLine($"{p.Nome}");
            Console.WriteLine(new string('-', 60));

            // Exemplo avançado 3: nomes com qualquer letra repetida consecutivamente (ex: 'aa', 'ss', 'll', etc)
            var consultaLikeAvancado3 = from p in pessoas
                                        let nome = p.Nome.ToLower()
                                        where Enumerable.Range(1, p.Nome.Length - 1).Any(i => nome[i] == nome[i - 1])
                                        select p;

            Console.WriteLine("Consulta LIKE avançada 3 (nomes com letras repetidas consecutivas):");
            foreach (var p in consultaLikeAvancado3)
                Console.WriteLine($"{p.Nome}");
            Console.WriteLine(new string('-', 60));
        }
    }
}