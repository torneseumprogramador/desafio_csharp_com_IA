// public delegate int Operacao(int a, int b);

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Usando delegate para soma
//         Operacao somaDeDoisNumerosInteiros = Somar;
//         Operacao subtrairDeDoisNumerosInteiros = Subtrair;

//         int resultadoSoma = somaDeDoisNumerosInteiros(10, 5);
//         int resultadoSubtracao = subtrairDeDoisNumerosInteiros(10, 5);

//         Console.WriteLine($"Soma: {resultadoSoma}");
//         Console.WriteLine($"Subtração: {resultadoSubtracao}");
//     }

//     static int Somar(int a, int b)
//     {
//         return a + b;
//     }

//     static int Subtrair(int a, int b)
//     {
//         return a - b;
//     }
// }



// using System;

// public delegate decimal CalculoPreco(decimal valor);

// class Program
// {
//     static decimal AplicarDesconto(decimal valor) 
//     { 
//         return valor * 0.9m; 
//     }

//     static decimal AplicarTaxa(decimal valor)
//     { 
//         return valor * 1.1m; 
//     }

//     static void ExecutarCalculo(decimal valor, CalculoPreco estrategia)
//     {
//         var resultado = estrategia(valor);
//         Console.WriteLine($"Resultado: {resultado}");
//     }

//     static void Main(string[] args)
//     {
//         ExecutarCalculo(100, AplicarDesconto); // 90
//         ExecutarCalculo(100, AplicarTaxa);     // 110
//     }
// }

// using System;

// public interface IOperacao
// {
//     void Executar();
// }

// public class OperacaoA : IOperacao
// {
//     public void Executar()
//     {
//         Console.WriteLine("Operação A executada.");
//     }
// }

// public class OperacaoB : IOperacao
// {
//     public void Executar()
//     {
//         Console.WriteLine("Operação B executada.");
//     }
// }

// class ExemploInterface
// {
//     static void ExecutarOperacao(IOperacao operacao)
//     {
//         Console.WriteLine("Executando operação via método:");
//         operacao.Executar();
//     }

//     static void Main(string[] args)
//     {
//         var operacao1 = new OperacaoA();
//         var operacao2 = new OperacaoB();

//         ExecutarOperacao(operacao1); // Demonstra uso da interface como parâmetro
//         ExecutarOperacao(operacao2);
//     }
// }



// using System;

// public delegate void PixGeradoHandler(string pixId);

// public class PagamentoService
// {
//     // Aviso CS8618 corrigido declarando o evento como nullable
//     public event PixGeradoHandler? CallBackPixGerado;

//     public void GerarPix(string id)
//     {
//         Console.WriteLine("Pix gerado!");
//         CallBackPixGerado?.Invoke(id);
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         var service = new PagamentoService();

//         void EnviarNotificacaoPorEmail(string id)
//         {
//             Console.WriteLine($"Enviando notificação de Pix por EMAIL para {id}");
//         }

//         void EnviarNotificacaoPorSms(string id)
//         {
//             Console.WriteLine($"Enviando notificação de Pix por SMS para {id}");
//         }

//         service.CallBackPixGerado += EnviarNotificacaoPorEmail;
//         service.CallBackPixGerado += EnviarNotificacaoPorSms;

//         service.GerarPix("ABC123");
//     }
// }


// public delegate void Callback(string resultado);

// public class Program
// {
//     static void Processar(Callback callback)
//     {
//         Console.WriteLine("Processando... aguarde 2 segundos...");
//         System.Threading.Thread.Sleep(2000);

//         // Simula processamento
//         callback("Processado com sucesso");
//     }

//     public static void Main(string[] args)
//     {
//         // Exemplo de uso de callback (semelhante ao JavaScript)
//         Processar((msg) =>
//         {
//             Console.WriteLine($"Callback: {msg}");
//         });
//     }
// }


public delegate bool Filtro(int numero);

class Program
{
    static List<int> Filtrar(List<int> lista, Filtro filtro)
    {
        var resultado = new List<int>();

        foreach (var item in lista)
        {
            if (filtro(item))
                resultado.Add(item);
        }

        return resultado;
    }

    static bool ApenasPares(int x)
    {
        return x % 2 == 0;
    }
    static bool ApenasImpares(int x)
    {
        return x % 2 != 0;
    }

    static void Main(string[] args)
    {
        var numeros = new List<int> { 1, 2, 3, 4, 5 };
        var pares = Filtrar(numeros, ApenasPares);
        var impares = Filtrar(numeros, ApenasImpares);
        
        Console.WriteLine("Pares: " + string.Join(",", pares)); // 2,4
        Console.WriteLine("Impares: " + string.Join(",", impares)); // 1,3,5
    }
}
