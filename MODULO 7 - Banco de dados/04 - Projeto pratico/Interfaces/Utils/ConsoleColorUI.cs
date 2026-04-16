using System;

namespace ProjetoPraticoClientes.Interfaces.Utils
{
    public static class ConsoleColorUI
    {
        public static void EscreverCabecalho(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== {texto} ===");
            Console.ResetColor();
        }

        public static void EscreverLinhaMenu(string texto)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void EscreverPrompt(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(texto);
            Console.ResetColor();
        }

        public static void EscreverLinhaDetalhe(string texto)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void EscreverMensagemResultado(bool sucesso, string mensagem)
        {
            if (sucesso) EscreverMensagemSucesso(mensagem);
            else EscreverMensagemErro(mensagem);
        }

        public static void EscreverMensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void EscreverMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void Pausar()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}

