// using System;

// public class PedidoService
// {
//     // Declaração do evento usando EventHandler
//     public event EventHandler PedidoFinalizado;

//     public void FinalizarPedido()
//     {
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido iniciado!");
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido em processamento...");
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido quase finalizado...");
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido finalizado!");
//         // Dispara o evento
//         PedidoFinalizado?.Invoke(this, EventArgs.Empty);
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         var service = new PedidoService();

//         // Inscreve os manipuladores (handlers) de envio de Email, SMS e WhatsApp no evento
//         service.PedidoFinalizado += EnviarEmail;
//         service.PedidoFinalizado += EnviarSms;
//         service.PedidoFinalizado += EnviarWhatsApp;

//         // Finaliza o pedido (deve disparar os eventos)
//         service.FinalizarPedido();

//         // Você pode também adicionar mais handlers de forma dinâmica com lambda (exemplo)
//         service.PedidoFinalizado += (sender, e) =>
//         {
//             Console.WriteLine("Callback lambda extra em PedidoFinalizado!");
//         };

//         // Finaliza o pedido novamente para mostrar todos handlers
//         service.FinalizarPedido();
//     }

//     private static void EnviarEmail(object sender, EventArgs e)
//     {
//         Console.WriteLine("[EMAIL] Confirmação de pedido enviada por e-mail!");
//     }

//     private static void EnviarSms(object sender, EventArgs e)
//     {
//         Console.WriteLine("[SMS] Confirmação de pedido enviada por SMS!");
//     }

//     private static void EnviarWhatsApp(object sender, EventArgs e)
//     {
//         Console.WriteLine("[WHATSAPP] Confirmação de pedido enviada por WhatsApp!");
//     }
// }


// public class PedidoEventArgs : EventArgs
// {
//     public int PedidoId { get; set; }
// }

// public class PedidoService
// {
//     public event EventHandler<PedidoEventArgs> PedidoFinalizado;

//     public void FinalizarPedido()
//     {
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido iniciado!");
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido em processamento...");
//         System.Threading.Thread.Sleep(1000);
//         Console.WriteLine("Pedido quase finalizado...");
//         System.Threading.Thread.Sleep(1000);

//         int id = Random.Shared.Next(1000, 9999);
        
//         Console.WriteLine($"Pedido {id} finalizado!");
//         PedidoFinalizado?.Invoke(this, new PedidoEventArgs
//         {
//             PedidoId = id
//         });
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         var service = new PedidoService();

//         // Inscreve os handlers de envio de Email, SMS e WhatsApp no evento, agora usando paramêtros
//         service.PedidoFinalizado += EnviarEmail;
//         service.PedidoFinalizado += EnviarSms;
//         service.PedidoFinalizado += EnviarWhatsApp;

//         service.FinalizarPedido();

//         // Adiciona também um handler extra com lambda
//         service.PedidoFinalizado += (sender, e) =>
//         {
//             Console.WriteLine($"Callback lambda extra: Pedido {e.PedidoId} foi finalizado (lambda)!");
//         };

//         service.FinalizarPedido();
//     }

//     private static void EnviarEmail(object sender, PedidoEventArgs e)
//     {
//         Console.WriteLine($"[EMAIL] Confirmação do pedido {e.PedidoId} enviada por e-mail!");
//     }

//     private static void EnviarSms(object sender, PedidoEventArgs e)
//     {
//         Console.WriteLine($"[SMS] Confirmação do pedido {e.PedidoId} enviada por SMS!");
//     }

//     private static void EnviarWhatsApp(object sender, PedidoEventArgs e)
//     {
//         Console.WriteLine($"[WHATSAPP] Confirmação do pedido {e.PedidoId} enviada por WhatsApp!");
//     }
// }


using System;
using System.Threading;
using System.Threading.Tasks;

public class TrabalhoFinalizadoEventArgs : EventArgs
{
    public string Mensagem { get; set; }
}

public class ServicoDemorado
{
    // Declaração do evento usando EventHandler<T>
    public event EventHandler<TrabalhoFinalizadoEventArgs> TrabalhoFinalizado;

    // Método async que simula trabalho demorado
    public async Task ExecutarTrabalhoAsync()
    {
        Console.WriteLine("Trabalho iniciado... Aguarde (4 segundos)...");
        await Task.Delay(4000); // Simula tarefa demorada (4s)
        OnTrabalhoFinalizado(new TrabalhoFinalizadoEventArgs { Mensagem = "Trabalho concluído com sucesso!" });
    }

    protected virtual void OnTrabalhoFinalizado(TrabalhoFinalizadoEventArgs e)
    {
        // Dispara todos os assinantes do evento
        TrabalhoFinalizado?.Invoke(this, e);
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var servico = new ServicoDemorado();

        // Inscreve múltiplos handlers (callbacks) ao evento
        servico.TrabalhoFinalizado += (s, e) =>
        {
            // Simulando tratamento da mensagem e salvando no "banco de dados"
            string mensagemTratada = e.Mensagem.ToUpper(); // Exemplo de tratamento
            Console.WriteLine("[Handler #1] Mensagem tratada: " + mensagemTratada);

            // Simulação do salvamento no banco de dados
            SalvarNoBancoDeDados(mensagemTratada);

            // Função fictícia para simular o salvamento no banco
            void SalvarNoBancoDeDados(string mensagem)
            {
                Console.WriteLine("[Handler #1] (Simulado) Mensagem salva no banco de dados: " + mensagem);
            }
        };
        // servico.TrabalhoFinalizado += (s, e) =>
        // {
        //     Console.WriteLine("[Handler #2] Callback: Recebido às " + DateTime.Now.ToLongTimeString());
        // };

        // Inicia o trabalho demorado em background
        var tarefa = servico.ExecutarTrabalhoAsync();

        // Enquanto a tarefa roda, outras operações seguem normalmente
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Operação paralela {i + 1}");
            await Task.Delay(800);
        }

        // Aguarda o trabalho terminar (para evitar Main finalizar antes)
        await tarefa;

        Console.WriteLine("Programa principal acabou.");
    }
}