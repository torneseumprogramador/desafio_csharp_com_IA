using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoClientes.Models;

namespace ProjetoPraticoClientes.Interfaces.Utils
{
    public static class TabelaClientesPrinter
    {
        public static void ImprimirTabelaClientes(IEnumerable<Cliente> clientes)
        {
            ImprimirTabelaClientes(clientes.ToList());
        }

        public static void ImprimirTabelaClientes(List<Cliente> clientes)
        {
            const int maxNome = 30;
            const int maxEmail = 35;
            const int maxTelefone = 20;

            var lista = clientes;
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            string Nome(string s) => Limitar(s, maxNome);
            string Email(string s) => Limitar(s, maxEmail);
            string Telefone(string s) => Limitar(s, maxTelefone);

            var ids = lista.Select(c => c.Id.ToString()).ToList();
            var nomes = lista.Select(c => Nome(c.Nome ?? string.Empty)).ToList();
            var emails = lista.Select(c => Email(c.Email ?? string.Empty)).ToList();
            var telefones = lista.Select(c => Telefone(c.Telefone ?? string.Empty)).ToList();

            int wId = Math.Max("ID".Length, ids.Max(s => s.Length));
            int wNome = Math.Max("Nome".Length, nomes.Max(s => s.Length));
            int wEmail = Math.Max("Email".Length, emails.Max(s => s.Length));
            int wTelefone = Math.Max("Telefone".Length, telefones.Max(s => s.Length));

            string Linha(string a, string b, string c, string d)
            {
                return $"| {a.PadRight(wId)} | {b.PadRight(wNome)} | {c.PadRight(wEmail)} | {d.PadRight(wTelefone)} |";
            }

            string Separador()
            {
                return "+" + new string('-', wId + 2) + "+" + new string('-', wNome + 2) + "+" +
                       new string('-', wEmail + 2) + "+" + new string('-', wTelefone + 2) + "+";
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Separador());
            Console.WriteLine(Linha("ID", "Nome", "Email", "Telefone"));
            Console.WriteLine(Separador());
            Console.ResetColor();

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(Linha(ids[i], nomes[i], emails[i], telefones[i]));
            }
        }

        private static string Limitar(string? texto, int max)
        {
            var s = (texto ?? string.Empty).Trim();
            if (s.Length <= max) return s;
            if (max <= 3) return s.Substring(0, max);
            return s.Substring(0, max - 3) + "...";
        }
    }
}

