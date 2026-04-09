
using System;
using System.Collections.Generic;
using System.Linq;

// Definindo classe Usuario para corrigir erro CS0246
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {

        // --- EXEMPLOS DE SOMA (RETORNANDO INT) ---

        // Exemplo de função de soma com expressão lambda (var)
        var SomarExpressaoLambda = (int a, int b) => a + b;

        // Exemplo de função de soma com expressão lambda (Func)
        // Func utilizo quando o retorno é um valor, o ultimo tipo é o retorno
        Func<int, int, int> SomarExpressaoLambdaFunc = (int a, int b) => a + b;

        // Exemplo de função de soma tradicional
        int Somar(int a, int b)
        {
            return a + b;
        }

        // --- EXEMPLOS VOID ---

        // Exemplo de função void com expressão lambda (Action)
        // Action utilizo somente quando o retorno é void
        Action<string> ExibirMensagemLambda1 = (mensagem) => Console.WriteLine(mensagem);

        // Exemplo de função void tradicional
        void ExibirMensagem1(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        // --- EXEMPLOS RETORNANDO STRING ---

        // Lambda que retorna string
        Func<string, string> CriarSaudacaoLambda = nome => $"Olá, {nome}!";

        // Tradicional que retorna string
        string CriarSaudacao(string nome)
        {
            return $"Olá, {nome}!";
        }

        // --- EXEMPLOS RETORNANDO BOOL ---

        // Lambda que retorna bool
        Func<int, bool> ParLambda = numero => numero % 2 == 0;

        // Tradicional que retorna bool
        bool Par(int numero)
        {
            return numero % 2 == 0;
        }

        // --- EXEMPLOS RETORNANDO DOUBLE ---

        // Lambda que retorna double
        Func<double, double, double> CalcularMediaLambda = (x, y) => (x + y) / 2;

        // Tradicional que retorna double
        double CalcularMedia(double x, double y)
        {
            return (x + y) / 2;
        }

        // --- EXEMPLO VOID USANDO LAMBDA SEM PARÂMETRO ---

        Action SemParametroLambda = () => Console.WriteLine("Teste sem parâmetro (lambda)");

        // Tradicional sem parâmetro
        void SemParametroTradicional()
        {
            Console.WriteLine("Teste sem parâmetro (tradicional)");
        }


        // --- EXEMPLO FILTRAR PARES ---
        var numeros = new List<int> { 1, 2, 3, 4, 5 };

        
        // Filtrar pares

        // Usando lambda
        var pares = numeros.Where(n => n % 2 == 0).ToList();

        // Usando função tradicional
        bool EhPar(int n)
        {
            return n % 2 == 0;
        }
   
        var paresTradicional = numeros.Where(EhPar).ToList();

        Console.WriteLine(string.Join(", ", pares)); // 2, 4



        var usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Danilo" },
            new Usuario { Id = 2, Nome = "Maria" }
        };

        // Buscar por ID
        var usuario = usuarios.FirstOrDefault(u => u.Id == 2);

        Console.WriteLine(usuario?.Nome); // Maria



        // Predicate utilizo somente quando o retorno é boolean
        Predicate<int> ehPar = x => x % 2 == 0;
        Console.WriteLine(ehPar(4)); // true


        // ==== tipos de lambda ====
        // Action - sem retorno void
        // Func - define o retorno e os parametros
        // Predicate - retorno boolean


        void ExibirMensagem(string mensagem)
        {
            Console.WriteLine("Mensagem 1: " + mensagem);
            Console.WriteLine("Mensagem 2: " + mensagem);
        }

        // quando tenho mais de uma linha de código, uso chaves e return
        Action<string> ExibirMensagemLambda = mensagem =>
        {
            Console.WriteLine("Mensagem 1: " + mensagem);
            Console.WriteLine("Mensagem 2: " + mensagem);
        };


        // ==== Exemplo de programação funcional utilizando lambda e função pura ====

        // Função pura: não altera estado externo, retorna sempre o mesmo resultado para os mesmos parâmetros
        int Dobrar(int n) => n * 2;

        // Lista de números
        var numeros2 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

        // Função de filtro usando lambda (programação funcional)
        Func<int, bool> ehImpar = x => x % 2 != 0;

        // Usando Where (filtro) + Select (projeção) + Aggregate (redução)
        var imparesDobrados = numeros2
            .Where(ehImpar)           // Filtra só ímpares
            .Select(Dobrar)           // Dobra cada ímpar usando função pura
            .ToList();

        Console.WriteLine("Ímpares Dobrados: " + string.Join(", ", imparesDobrados)); // 2, 6, 10, 14

        // Soma dos ímpares (com lambda inline)
        int somaImpares = numeros2.Where(x => x % 2 != 0).Sum();
        Console.WriteLine("Soma dos ímpares: " + somaImpares); // 16

        // Usando Aggregate para calcular o produto de todos os números da lista
        // O método Aggregate faz uma agregação/redução dos elementos da lista.
        // No exemplo abaixo, começa com valor inicial 1 e multiplica cada elemento da lista pelo acumulador (acc),
        // ou seja, calcula o produto de todos os números da lista.
        // O x representa cada elemento da lista (numeros2)
        // O acc representa o acumulador, que armazena o valor parcial da multiplicação a cada iteração
        var numerosParaAgregar = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        int produto = numerosParaAgregar.Aggregate(1, (acc, x) => acc * x);
        Console.WriteLine("Produto de todos os números: " + produto); // 5040

        // Exemplo de composição de funções
        Func<int, int> triplo = x => x * 3;
        Func<int, int> maisCinco = x => x + 5;

        // Compondo funções: triplo(maisCinco(x))
        Func<int, int> triploMaisCinco = x => triplo(maisCinco(x));

        var resultado = numeros2.Select(triploMaisCinco).ToList();
        Console.WriteLine("Triplo depois de somar 5: " + string.Join(", ", resultado));
    }
}