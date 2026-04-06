using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int i = 0;
        await Task.Run(() =>
        {
            // processamento pesado
            for (i = 0; i < 1000000; i++) { }
        });

        Console.WriteLine($"Valor de i: {i}");

        // Chama o método async e pega a Task
        Task<string> operacaoTask = MinhaOperacaoAsync();

        Console.WriteLine($"Objeto Task: {operacaoTask}");
        Console.WriteLine($"Task status imediatamente após chamar o método: {operacaoTask.Status}");

        // Aguarda o resultado final da Task
        string resultado = await operacaoTask;

        Console.WriteLine($"Resultado da operação: {resultado}");
        Console.WriteLine($"Task status após await: {operacaoTask.Status}");

        var t1 = MinhaOperacaoAsync();
        var t2 = MinhaOperacaoAsync();
        var t3 = MinhaOperacaoAsync();

        string[] resultadoTres = await Task.WhenAll(t1, t2, t3);

        Console.WriteLine($"Resultado da operação: {string.Join(", ", resultadoTres)}");
        Console.WriteLine($"Task status após await: {operacaoTask.Status}");


        ExecutarTarefa();
    }

    static void ExecutarTarefa()
    {
        Console.WriteLine("Tarefa iniciada");
        var t1 = MinhaOperacaoAsync();
        
        // Espera a Task finalizar bloqueando a thread
        t1.Wait();
        
        // Para obter o resultado da Task após o Wait
        Console.WriteLine($"Resultado da tarefa 1: {t1.Result}");
    }

    static async Task<string> MinhaOperacaoAsync()
    {
        Console.WriteLine("Operação assíncrona iniciada, aguardando 2 segundos...");
        await Task.Delay(2000);
        return $"Operação finalizada! {Guid.NewGuid()}";
    }
}
