using ProjetoPraticoClientes.Interfaces;
using ProjetoPraticoClientes.Repositorios;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repositorio = new ClienteRepositorio();
            var servico = new ClienteServico(repositorio);
            var interfaceConsole = new ClienteInterfaceConsole(servico);

            interfaceConsole.ExecutarMenuPrincipal();
        }
    }
}

