
// using System.Threading.Tasks;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         Console.WriteLine("Iniciando a busca de dados em paralelo...");

//         // Inicia duas tarefas assíncronas em paralelo
//         var tarefa1 = BuscarDadosAsync("Processo 1");
//         var tarefa2 = BuscarDadosAsync("Processo 2");

//         Console.WriteLine("Tarefas iniciadas! Enquanto isso, posso mostrar algo...");
//         Console.WriteLine("Mostrando algo adicional enquanto espera...");

//         for (int i = 0; i < 4; i++)
//         {
//             Console.WriteLine($"Processando... {i}");
//             await Task.Delay(1000);
//         }

//         // var dados = BuscarDados("*** Processo 3 ***");
//         // Console.WriteLine(dados);

//         // Aguarda ambas as tarefas terminarem
//         var resultados = await Task.WhenAll(tarefa1, tarefa2);

//         // Exibe os resultados das duas buscas
//         foreach (var resultado in resultados)
//         {
//             Console.WriteLine(resultado);
//         }

//         Console.WriteLine("Finalizando o programa...");
//     }

//     public static async Task<string> BuscarDadosAsync(string nomeProcesso)
//     {
//         await Task.Delay(5000); // Simula operação demorada
//         return $"{nomeProcesso}: Dados carregados!";
//     }


//     public static string BuscarDados(string nomeProcesso)
//     {
//         Task.Delay(5000); // Simula operação demorada
//         return $"{nomeProcesso}: Dados carregados!";
//     }
// }


// using System;
// using System.Diagnostics;
// using System.IO;

// class Program
// {
//     static void Main(string[] args)
//     {
//         var stopwatch = new Stopwatch();
//         stopwatch.Start();

//         string filePath = "numeros.txt";
//         using (var writer = new StreamWriter(filePath))
//         {
//             for (int i = 1; i <= 10; i++)
//             {
//                 writer.WriteLine(i);
//                 writer.Flush(); // Garante que cada número é realmente gravado no disco imediatamente
//                 Console.WriteLine($"Número {i} gravado no arquivo."); // Feedback em tempo real na tela
//                 System.Threading.Thread.Sleep(500);
//             }
//         }

//         stopwatch.Stop();
//         Console.WriteLine($"Tempo para escrever de 1 a 10 no arquivo de forma síncrona: {stopwatch.Elapsed.TotalSeconds:F2} s");
//     }
// }





// using System;
// using System.Diagnostics;
// using System.IO;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Collections.Concurrent;

// class Program
// {
//     const int maxDegreeOfParallelism = 5;
//     const int maxNumber = 10;
//     const int delayPerWriteMs = 500;

//     static async Task Main(string[] args)
//     {
//         var stopwatch = new Stopwatch();
//         stopwatch.Start();

//         string filePath = "numeros.txt";

//         // Thread-safe collection for numbers to write
//         var queue = new ConcurrentQueue<int>();
//         for (int i = 1; i <= maxNumber; i++) queue.Enqueue(i);

//         // Lista para armazenar os números gravados, para ordenar depois
//         var numerosGravados = new ConcurrentBag<int>();

//         var writeLock = new SemaphoreSlim(1, 1);

//         // Função para as tarefas paralelas
//         async Task Worker()
//         {
//             while (queue.TryDequeue(out int number))
//             {
//                 await Task.Delay(delayPerWriteMs); // Simula processamento

//                 // Escrita com lock para evitar problemas de concorrência com o StreamWriter
//                 await writeLock.WaitAsync();
//                 try
//                 {
//                     numerosGravados.Add(number);
//                     Console.WriteLine($"Número {number} processado."); // Feedback em tempo real
//                 }
//                 finally
//                 {
//                     writeLock.Release();
//                 }
//             }
//         }

//         // Criar e rodar até 5 tarefas paralelas
//         var tasks = new Task[maxDegreeOfParallelism];
//         for (int i = 0; i < maxDegreeOfParallelism; i++)
//             tasks[i] = Worker();

//         await Task.WhenAll(tasks);

//         // Após finalizar, escreve os números ordenados no arquivo
//         var numerosOrdenados = numerosGravados.ToArray();
//         Array.Sort(numerosOrdenados);

//         using (var writer = new StreamWriter(filePath))
//         {
//             foreach (var number in numerosOrdenados)
//             {
//                 await writer.WriteLineAsync(number.ToString());
//                 await writer.FlushAsync();
//             }
//         }

//         stopwatch.Stop();
//         Console.WriteLine($"Tempo para escrever de 1 a 10 no arquivo de forma assíncrona, paralela e ordenada: {stopwatch.Elapsed.TotalSeconds:F2} s");
//     }
// }



// Exemplo simples usando Thread em vez de async/await
using System.Threading;

// Thread tradicional
void ExemploComThread()
{
    string filePath = "numeros.txt";
    int delayPerWriteMs = 500;
    int[] numeros = Enumerable.Range(1, 10).ToArray();

    Thread thread = new Thread(() =>
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var numero in numeros)
            {
                writer.WriteLine(numero);
                writer.Flush();
                Console.WriteLine($"Número {numero} escrito pelo Thread.");
                Thread.Sleep(delayPerWriteMs); // Simula um processamento demorado
            }
        }
        Console.WriteLine("Thread terminou de escrever no arquivo.");
    });

    thread.Start();
    thread.Join(); // Espera a thread terminar
}

// Async/Await - EXEMPLO EQUIVALENTE
async Task ExemploComAsyncAwait()
{
    string filePath = "numeros.txt";
    int delayPerWriteMs = 500;
    int[] numeros = Enumerable.Range(1, 10).ToArray();

    using (var writer = new StreamWriter(filePath))
    {
        foreach (var numero in numeros)
        {
            await writer.WriteLineAsync(numero.ToString());
            await writer.FlushAsync();
            Console.WriteLine($"Número {numero} escrito pelo async/await.");
            await Task.Delay(delayPerWriteMs); // Simula um processamento demorado
        }
    }
    Console.WriteLine("Async/await terminou de escrever no arquivo.");
}

// Para rodar um dos exemplos, descomente uma das linhas abaixo:
// ExemploComThread();

// Para rodar async/await num contexto top-level, utilize:
// await ExemploComAsyncAwait();
